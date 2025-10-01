using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanHungHa.Common.Parameter;
using TanHungHa.Common;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using System.Diagnostics;

namespace TanHungHa.Tabs.ManagerTab
{
    public partial class ManModelForm : MaterialForm
    {
        private static ManModelForm _instance;
        private static readonly object _lock = new object();
        public static ManModelForm GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ManModelForm();
                    }
                }
            }
            return _instance;
        }

        public ManModelForm()
        {
            InitializeComponent();
            InitToolblockUI();
        }

     
        MyModel myModel = new MyModel();
        public void InitToolblockUI()
        {
            updateListViewTB();
        }

        public void updateListViewTB()
        {
            try
            {
                lvModels.Items.Clear();
                int tbLength = MyParam.list_models.Count;
                if (tbLength == 0)
                {
                    lvModels.Items.Add(new ListViewItem(new string[] { "0", "N/A", "Empty Model", "N/A" }));
                }
                else
                {

                    for (int i = 0; i < tbLength; i++)
                    {
                        string _no = (i + 1).ToString();
                        string _name = MyParam.list_models[i].Name;
                        string _path = MyParam.list_models[i].SolPath;
                        string _active = MyParam.list_models[i].IsActive.ToString();
                        lvModels.Items.Add(new ListViewItem(new string[] { _no, _active, _name, _path }));
                        if (MyParam.list_models[i].IsActive)
                        {
                            lvModels.Items[i].Selected = true;
                        }
                    }
                }
                lvModels.Invalidate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updateListViewTB: " + ex.Message);
            }
        }

        private List<ListViewItem> allItems = new List<ListViewItem>();
        void UpdateListViewModel()
        {
            allItems.Clear();
            foreach (ListViewItem item in lvModels.Items)
            {
                allItems.Add((ListViewItem)item.Clone()); // Clone để tránh tham chiếu cùng một đối tượng
            }
        }

        private void ManModelForm_Load(object sender, EventArgs e)
        {
            UpdateListViewModel();
        }
        void genPathOnUI()
        {
            txtPathJob.Text = $"{MyDefine.path_model}\\{txtModelName.Text}\\{MyDefine.NAME_JOB}";
            txtPathJob.Invalidate();
        }
        void updateModelParam()
        {
            myModel.Name = txtModelName.Text;
            myModel.SolPath = txtPathJob.Text;
            myModel.IsActive = swStatus.Checked;
        }
        void updateModelUI()
        {
            txtModelName.Text = myModel.Name;
            txtModelName.Invalidate();

            txtPathJob.Text = myModel.SolPath;
            txtPathJob.Invalidate();

            swStatus.Checked = myModel.IsActive;
            swStatus.Invalidate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtModelName.Text == string.Empty)
            {
                MyLib.showDlgWarning("Model Name empty");
                return;
            }
            

            genPathOnUI();
            updateModelParam();
            var addModel = MyParam.list_models.Find(model => model.Name.Equals(myModel.Name));
            //Diff name => create new model
            if (addModel == null)
            {
                if (myModel.IsActive)
                {
                    //Care actived
                    var activedModel = MyParam.list_models.Find(model => model.IsActive == true);
                    if (activedModel != null)
                    {
                        activedModel.IsActive = false;
                        MyLib.showDlgWarning($"Model {activedModel.Name} => Deactive \r\nModel {myModel.Name} => Active");
                    }
                }
                else
                {
                    myModel.IsActive = true;
                    var activedModel = MyParam.list_models.Find(model => model.IsActive == true);
                    if (activedModel != null)
                    {
                        activedModel.IsActive = false;
                        MyLib.showDlgWarning($"Model {activedModel.Name} => Deactive \r\nModel {myModel.Name} => Active");
                    }
                }
                //new model >> clone old model param
                MyParam.list_models.Add(myModel.Clone());
                updateListViewTB();

                string exePath = AppContext.BaseDirectory;

                Console.WriteLine("Exe Path: " + exePath);


                var pathTemplateModel = MyDefine.path_template_model;
                var pathNewModel = $"{MyDefine.path_model}\\{myModel.Name}";
                CreateNewModel(pathTemplateModel, pathNewModel);

                SaveLoadParameter.Save_Parameter(MyParam.list_models, MyDefine.file_model);
                UpdateListViewModel();



            }
            else
            {
                MyLib.showDlgWarning($"Can't add model same name {addModel.Name}");
            }
        }
        public void CreateNewModel(string pathTemplateModel, string newFolderPath)
        {

            if (Directory.Exists(pathTemplateModel))
            {
                Directory.CreateDirectory(newFolderPath);
                CopyAll(new DirectoryInfo(pathTemplateModel), new DirectoryInfo(newFolderPath));
            }
            else
            {
                MyLib.showDlgWarning("Template Model not Exists");
            }
        }
        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }
            foreach (DirectoryInfo subDirectory in source.GetDirectories())
            {
                CopyAll(subDirectory, target.CreateSubdirectory(subDirectory.Name));
            }
        }

        private void lvModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvModels.SelectedItems.Count == 0)
                return; // Không có mục nào được chọn

            // Lấy tên model từ item được chọn
            string selectedModelName = lvModels.SelectedItems[0].SubItems[2].Text; // Giả sử tên model ở cột thứ 3

            // Tìm model trong danh sách MyParam.list_models
            var selectedModel = MyParam.list_models.FirstOrDefault(model => model.Name.Equals(selectedModelName));

            if (selectedModel != null)
            {
                myModel = selectedModel.Clone(); // Nhân bản model
                updateModelUI(); // Cập nhật giao diện người dùng với thông tin model
            }
        }

        private void txtPathJob_LeadingIconClick(object sender, EventArgs e)
        {
            //try
            //{
            //    var x = txtPathJob.Text;
            //    if (Directory.Exists(x))
            //    {
            //        Process.Start(x);
            //    }
            //    else
            //    {
            //        MyLib.showDlgWarning($"{x} not exist!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MyLib.showDlgError(ex.Message);
            //    MyLib.log(ex.Message, SvLogger.LogType.ERROR);
            //}
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            updateModelParam();

            //Check file sol is exist
            string dataInfo = "";
            if (!MyLib.fileIsExists(myModel.SolPath))
            {
                dataInfo = $"{Path.GetFileName(myModel.SolPath)} not exist!;";
            }
            else
            {
                dataInfo = $"{Path.GetFileName(myModel.SolPath)} is exist!;";
            }
            MyLib.showDlgInfo($"{myModel.Name} ({myModel.IsActive}): {dataInfo}");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            MaterialDialog materialDialogDel = new MaterialDialog(MyParam.mainForm, "Delete Model", $"Are you sure want to delete model {txtModelName.Text}?", "OK", true, "Cancel");
            DialogResult resultDel = materialDialogDel.ShowDialog(MyParam.mainForm);

            if (resultDel != DialogResult.OK)
            {
                return;
            }

            if (MyParam.list_models.Count == 1)
            {
                MyLib.showDlgWarning($"Can't delete last model");
                return;
            }

            var delModel = MyParam.list_models.Find(model => model.Name.Equals(myModel.Name));
            if (delModel != null)
            {
                if (delModel.IsActive)
                {
                    MyLib.showDlgWarning($"Can't delete actived model");
                    return;
                }

                MyParam.list_models.Remove(delModel);
                var pathFolder = $"{MyDefine.path_model}\\{txtModelName.Text}";

                MyLib.DeleteFolder(pathFolder);
                updateListViewTB();
                SaveLoadParameter.Save_Parameter(MyParam.list_models, MyDefine.file_model);
                UpdateListViewModel();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLoadParameter.Save_Parameter(MyParam.list_models, MyDefine.file_model);
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            updateModelParam();
            foreach (var model in MyParam.list_models)
                model.IsActive = false;

            var activeModel = MyParam.list_models.Find(model => model.Name.Equals(myModel.Name));
            if (activeModel != null)
            {
                activeModel.IsActive = true;
                updateListViewTB();
                MyLib.ShowInfo($"Active model {activeModel.Name}");
                UpdateListViewModel();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var isActiveModel = myModel.IsActive;
            if (!isActiveModel)
            {
                MyLib.showDlgInfo("Active Model trước khi update!");
                return;
            }
            var indexModel = MyParam.list_models.FindIndex(model => model.Name.Equals(myModel.Name));
            if (indexModel < 0)
                return;
            MaterialDialog materialDialog = new MaterialDialog(MyParam.mainForm, "Update Model", $"Are you sure want to update model {MyParam.list_models[indexModel].Name} to {txtModelName.Text}?", "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(MyParam.mainForm);

            if (result != DialogResult.OK)
            {
                return;
            }

            var pathCurrentModel = $"{MyDefine.path_model}\\{MyParam.list_models[indexModel].Name}";

            var updateModel = MyParam.list_models[indexModel].Clone();
            if (updateModel != null)
            {

                if (updateModel.Name != txtModelName.Text)
                {
                    var temp = MyParam.list_models.Find(model => model.Name.Equals(txtModelName.Text));
                    if (temp != null)
                    {
                        MyLib.showDlgWarning($"Can't add model same name {txtModelName.Text}");
                        return;
                    }

                    genPathOnUI();
                    updateModel.Name = txtModelName.Text;
                    updateModel.SolPath = txtPathJob.Text;
                    updateModel.IsActive = swStatus.Checked;

                    var pathUpdateModel = $"{MyDefine.path_model}\\{updateModel.Name}";
                    /*change name folder*/
                    try
                    {
                        if (Directory.Exists(pathCurrentModel))
                        {
                            Directory.Move(pathCurrentModel, pathUpdateModel);
                            MyParam.list_models[indexModel] = updateModel.Clone();
                            updateListViewTB();
                            SaveLoadParameter.Save_Parameter(MyParam.list_models, MyDefine.file_model);
                            UpdateListViewModel();
                        }
                        else
                        {
                            // Handle the error, e.g., log an error message
                            Console.WriteLine("Source directory does not exist.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MyLib.showDlgWarning($"Can't update model same name {txtModelName.Text}\r\n" + ex.ToString());
                    }

                }
            }
        }

            
        }
}