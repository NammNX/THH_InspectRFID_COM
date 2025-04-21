using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TanHungHa.Common.TaskLoopCustomize
{
    public enum eTaskStatus
    {
        Task_Create,
        Task_StopLoop,
        Task_ResetToken,
        Task_Cancel,
        Task_Running,
        Task_Destroy
    }
    public class TaskLoop
    {
        private string TAG = "Taskloop";
        private eTaskStatus taskStatus = eTaskStatus.Task_Create;
        private CancellationTokenSource _cancelSource;
        private readonly AsyncLock _lock = new AsyncLock();

        public eTaskStatus TaskStatus { get => taskStatus; set => taskStatus = value; }
        public CancellationTokenSource CancelSource { get => _cancelSource; set => _cancelSource = value; }

        public TaskLoop()
        {
            TaskStatus = eTaskStatus.Task_Create;
            CancelSource = new CancellationTokenSource();
        }

        ~TaskLoop()
        {
            TaskStatus = eTaskStatus.Task_Destroy;
            CancelSource?.Dispose();
        }


        public void ResetToken()
        {
            MyLib.log(TAG, "ResetToken...");
            CancelSource?.Dispose();
            CancelSource = new CancellationTokenSource();
            TaskStatus = eTaskStatus.Task_ResetToken;
        }

        public void StopLoop()
        {
            if (TaskStatus == eTaskStatus.Task_Running)
            {
                MyLib.log(TAG, "Task_Running -> StopLoop...");
                TaskStatus = eTaskStatus.Task_StopLoop;
                CancelSource?.Cancel();

            }
            else
            {
                MyLib.log(TAG, "StopLoop..." + TaskStatus);
            }    
        }



        public async Task RunLoop(int interval, Action action)
        {
            if(TaskStatus == eTaskStatus.Task_Running)
            {
                MyLib.log(TAG, "Not implement RunLoop, cause task is running...");
                return;
            }    
            ResetToken();
            if (action == null)
            {
                MyLib.log(TAG, "Not implement RunLoop, cause action is null...");
                return;
            }    

            
            using (await _lock.LockAsync())
            {
                MyLib.log(TAG, "Start Implement RunLoop...");
                TaskStatus = eTaskStatus.Task_Running;
                while (!CancelSource.IsCancellationRequested)
                {
                    await Task.Run(() => action());
                    await Task.Delay(interval);
                }
            }
        }

    }

    public sealed class AsyncLock
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public async Task<IDisposable> LockAsync()
        {
            await _semaphore.WaitAsync();
            return new Handler(_semaphore);
        }

        private sealed class Handler : IDisposable
        {
            private readonly SemaphoreSlim _semaphore;
            private bool _disposed = false;

            public Handler(SemaphoreSlim semaphore)
            {
                _semaphore = semaphore;
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    _semaphore.Release();
                    _disposed = true;
                }
            }
        }
    }

}
