using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TanHungHa.Common
{
    public class MongoDBService
    {
        private static MongoDBService _instance;
        private static readonly object _lock = new object();
        public static MongoDBService GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MongoDBService();
                    }
                }
            }
            return _instance;
        }
        private MongoDBService()
        {
            
        }
        private static MongoClient _client;
        private static IMongoDatabase _database;
        private static IMongoCollection<BsonDocument> iqcCollection;
        private static IMongoCollection<BsonDocument> oqcCollection;

        private static readonly List<BsonDocument> iqcBuffer = new List<BsonDocument>();
        private static readonly List<BsonDocument> oqcBuffer = new List<BsonDocument>();

        private static readonly object iqcLock = new object();
        private static readonly object oqcLock = new object();
        private static int totalIqcFlushed = 0;
        private static int totalOqcFlushed = 0;


        public bool ConnectMongoDb(string connectionString, string databaseName)
        {
            try
            {
                if (_client == null)
                {
                    _client = new MongoClient(connectionString);
                }

                _database = _client.GetDatabase(databaseName);

                var ping = _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Result;
                Console.WriteLine($"Connected to MongoDB: {databaseName}");

                iqcCollection = _database.GetCollection<BsonDocument>("iqcData");
                oqcCollection = _database.GetCollection<BsonDocument>("oqcData");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("MongoDB connection error: " + ex.Message);
                MyLib.showDlgError("MongoDB connection error: " + ex.Message + "\r\n" + "Kiểm tra lại kết nối MongoDB");
                return false;
            }
        }
        public bool ConnectMongoDb(string connectionString)
        {
            try
            {
                if (_client == null)
                {
                    _client = new MongoClient(connectionString);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("MongoDB connection error: " + ex.Message);
                MyLib.showDlgError("MongoDB connection error: " + ex.Message + "\r\n" + "Kiểm tra lại kết nối MongoDB");
                return false;
            }

        }
        public List<string> GetDatabasesWithLogsOnDate(DateTime selectedDate)
        {
            var result = new List<string>();

            var dbNames = _client.ListDatabaseNames().ToList();

            DateTime start = selectedDate.Date;
            DateTime end = start.AddDays(1);

            foreach (var dbName in dbNames)
            {
                try
                {
                    var db = _client.GetDatabase(dbName);

                    // Kiểm tra IQC
                    var iqcNames = db.ListCollectionNames().ToList();
                    if (iqcNames.Contains("iqcData"))
                    {
                        var iqcCol = db.GetCollection<BsonDocument>("iqcData");
                        var count = iqcCol.CountDocuments(Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Gte("Timestamp", start),
                            Builders<BsonDocument>.Filter.Lt("Timestamp", end)
                        ));

                        if (count > 0)
                        {
                            result.Add(dbName);
                            continue;
                        }
                    }

                    // Kiểm tra OQC nếu IQC không có
                    if (iqcNames.Contains("oqcData"))
                    {
                        var oqcCol = db.GetCollection<BsonDocument>("oqcData");
                        var count = oqcCol.CountDocuments(Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Gte("Timestamp", start),
                            Builders<BsonDocument>.Filter.Lt("Timestamp", end)
                        ));

                        if (count > 0)
                        {
                            result.Add(dbName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DB {dbName} lỗi khi kiểm tra: {ex.Message}");
                }
            }

            return result;
        }
        public List<string> SearchDatabaseNamesByKeyword(string keyword)
        {
            var allDatabaseNames = _client.ListDatabaseNames().ToList();
            var matchedNames = allDatabaseNames
                .Where(name => name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
            if (matchedNames.Count == 0)
            {
                MyLib.showDlgInfo("Không tìm thấy database nào chứa từ khóa: " + keyword);
            }
            return matchedNames;
        }


        //public static IMongoDatabase ConnectMongoDb(string connectionString, string databaseName)
        //{
        //    try
        //    {
        //        if (_client == null)
        //        {
        //            _client = new MongoClient(connectionString);
        //        }

        //        _database = _client.GetDatabase(databaseName);

        //        // Kiểm tra kết nối
        //        var ping = _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Result;
        //        Console.WriteLine($"Connected to MongoDB: {databaseName}");

        //        iqcCollection = _database.GetCollection<BsonDocument>("iqcData");
        //        oqcCollection = _database.GetCollection<BsonDocument>("oqcData");

        //        return _database;
        //    }
        //    catch (MongoConnectionException ex)
        //    {
        //        // Lỗi kết nối MongoDB
        //        Console.WriteLine("MongoDB connection failed: " + ex.Message);
        //        MyLib.showDlgError("MongoDB connection failed: " + ex.Message);
        //    }
        //    catch (TimeoutException ex)
        //    {
        //        // Lỗi timeout kết nối
        //        Console.WriteLine("MongoDB connection timeout: " + ex.Message);
        //        MyLib.showDlgError("Lỗi timeout kết nối MongoDB: " + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Lỗi chung
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //        MyLib.showDlgError("MongoDB connection failed: " + ex.Message);
        //    }

        //    return false; // Trả về null nếu không thể kết nối
        //}

        public void AddToBuffer(string epc, string tid, DateTime timestamp, string type, string collectionName)
        {


            var doc = new BsonDocument
    {
        { "Timestamp", BsonDateTime.Create(timestamp) },
        { "EPC", epc },
        { "TID", tid }, // Có thể là null nếu TID bị disable
        { "Type", type }
    };

            // Lưu vào buffer tùy theo collection name
            if (collectionName == "IQC")
            {
                lock (iqcLock)
                {
                    iqcBuffer.Add(doc);
                }

            }
            else if (collectionName == "OQC")
            {
                lock (oqcLock)
                {
                    oqcBuffer.Add(doc);
                }
            }
        }

        public void AddToBuffer2(string data, DateTime timestamp, string type, string collectionName)
        {
            var doc = new BsonDocument
        {
            { "Timestamp", BsonDateTime.Create(timestamp) },
            { "Data", data },
            {"Type",type }
        };

            if (collectionName == "IQC")
            {
                lock (iqcLock)
                {
                    iqcBuffer.Add(doc);
                    //  File.AppendAllText("iqc_temp.json", doc.ToJson() + Environment.NewLine);
                }
            }
            else if (collectionName == "OQC")
            {
                lock (oqcLock)
                {
                    oqcBuffer.Add(doc);
                    //    File.AppendAllText("oqc_temp.json", doc.ToJson() + Environment.NewLine);
                }
            }
        }
        public void FlushBuffersIQC()
        {
            try
            {
                lock (iqcLock)
                {
                    if (iqcBuffer.Count > 0)
                    {
                        iqcCollection.InsertMany(iqcBuffer);
                        totalIqcFlushed += iqcBuffer.Count;
                        iqcBuffer.Clear();
                        //  File.WriteAllText("iqc_temp.json", string.Empty);
                        MainProcess.AddLogAuto("IQC buffer đã flush lên MongoDB", eIndex.Index_MongoDB_Log);
                        Console.WriteLine($"IQC buffer đã flush lên MongoDB.Tổng: {totalIqcFlushed}");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Flush lỗi: " + ex.Message);
                MyLib.showDlgError("Flush lỗi: " + ex.Message);
                // ????
            }
        }
        public void FlushBuffersOQC()
        {
            try
            {
                lock (oqcLock)
                {
                    if (oqcBuffer.Count > 0)
                    {
                        oqcCollection.InsertMany(oqcBuffer);
                        totalOqcFlushed += oqcBuffer.Count;
                        oqcBuffer.Clear();
                        //   File.WriteAllText("oqc_temp.json", string.Empty);
                        MainProcess.AddLogAuto("OQC buffer đã flush lên MongoDB", eIndex.Index_MongoDB_Log);
                        Console.WriteLine($"OQC buffer đã flush lên MongoDB. Tổng: {totalOqcFlushed}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Flush lỗi: " + ex.Message);
                MyLib.showDlgError("Flush lỗi: " + ex.Message);
                //  StopFlushLoop();
            }
        }

        //public static void StartFlushLoop()
        //{
        //    _cancellationTokenSource = new CancellationTokenSource();
        //    Task.Run(async () =>
        //    {
        //        while (!_cancellationTokenSource.Token.IsCancellationRequested)
        //        {
        //            FlushBuffers();
        //            await Task.Delay(3000);
        //        }
        //    });
        //}

        //public static void StopFlushLoop()
        //{
        //    _cancellationTokenSource?.Cancel();
        //}
        public int GetIqcBufferCount()
        {
            lock (iqcLock)
            {
                return iqcBuffer.Count;
            }
        }

        public int GetOqcBufferCount()
        {
            lock (oqcLock)
            {
                return oqcBuffer.Count;
            }
        }
        public bool IsFlushingCompleted()
        {
            return GetIqcBufferCount() == 0 && GetOqcBufferCount() == 0;
        }

        public static int GetTotalIqcFlushed() => totalIqcFlushed;
        public static int GetTotalOqcFlushed() => totalOqcFlushed;
        public static void ClearDBFlushed()
        {
            totalIqcFlushed = 0;
            totalOqcFlushed = 0;
        }
        public static bool isFlushLoop = false;
        public static void StopFlushLoop()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersIQC].StopLoop();
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersOQC].StopLoop();

            isFlushLoop = false;
        }
        public void RunFlushLoop()
        {
            if (isFlushLoop)
            {
                MyLib.showDlgInfo("Loop Flush Mongo is running!");
                return;
            }
            //IQC
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersIQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersIQC].RunLoop(MyParam.runParam.mongoFlushIntervalMs, FlushBuffersIQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task FlushBuffersIQC!");
            });
            //OQC
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersOQC].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_FlushBuffersOQC].RunLoop(MyParam.runParam.mongoFlushIntervalMs, FlushBuffersOQC).ContinueWith((a) =>
            {
                MyLib.log($"Done task FlushBuffersOQC!");
            });
            isFlushLoop = true;
        }

        // Query data by date range
        public List<BsonDocument> QueryByDateRange(string collectionName, DateTime date)
        {
            var startOfDay = date.Date;
            var startOfNextDay = startOfDay.AddDays(1);
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Gte("Timestamp", startOfDay),
                Builders<BsonDocument>.Filter.Lt("Timestamp", startOfNextDay)
            );

            var collection = collectionName == "IQC" ? iqcCollection : oqcCollection;
            return collection.Find(filter).ToList();
        }
        public List<BsonDocument> QueryAllData(string collectionName)
        {
            var collection = collectionName == "IQC" ? iqcCollection : oqcCollection;
            return collection.Find(new BsonDocument()).ToList();
        }


        // Query data by type
        public List<BsonDocument> QueryByType(string collectionName, string type)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Type", type);
            var collection = collectionName == "IQC" ? iqcCollection : oqcCollection;
            return collection.Find(filter).ToList();
        }
        // Query data by type and date range
        public List<BsonDocument> QueryByTypeAndDateRange(string collectionName, string type, DateTime date)
        {
            var startOfDay = date.Date;
            var startOfNextDay = startOfDay.AddDays(1);
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Type", type),
                Builders<BsonDocument>.Filter.Gte("Timestamp", startOfDay),
                Builders<BsonDocument>.Filter.Lt("Timestamp", startOfNextDay)
            );

            var collection = collectionName == "IQC" ? iqcCollection : oqcCollection;
            return collection.Find(filter).ToList();
        }
        public List<string> GetAllDatabaseNames()
        {
            try
            {
                return _client.ListDatabaseNames().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách database: " + ex.Message);
                MyLib.showDlgError("Lỗi khi lấy danh sách database: " + ex.Message);
                return new List<string>();
            }
        }

    }
}
