using MaterialSkin.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanHungHa.Common;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TanHungHa.Tabs.ManualTab
{
    public partial class ManParamForm : MaterialForm
    {
        private static ManParamForm _instance;
        private static readonly object _lock = new object();
        public static ManParamForm GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ManParamForm();
                    }
                }
            }
            return _instance;
        }

        public ManParamForm()
        {
            InitializeComponent();
            InitTreeView();
        }


        public void InitTreeView()
        {
            treeView.Nodes.Clear();
            treeView.BeginUpdate();
            TreeNode treeNodeRunParam = new TreeNode(Text = MyDefine.treenodeRunParam);
            TreeNode treeNodeTime = new TreeNode(Text = MyDefine.treenodeTime);
            //TreeNode treeNodeRS232 = new TreeNode(Text = MyDefine.treenodeRS232);
            TreeNode treeNodeTheme = new TreeNode(Text = MyDefine.treenodeTheme);
            TreeNode treeNodeDev = new TreeNode(Text = MyDefine.treenodeDev);

            treeView.Nodes.Add(treeNodeRunParam);
            treeView.Nodes.Add(treeNodeDev);
            treeView.Nodes.Add(treeNodeTime);
           // treeView.Nodes.Add(treeNodeRS232);
            treeView.EndUpdate();
            treeView.SelectedNode = treeNodeRunParam;
        }


        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNodeText = e.Node.Text;
            Console.WriteLine(selectedNodeText);
            switch (selectedNodeText)
            {
                //Run param
                case MyDefine.treenodeRunParam:
                    propertyGrid.SelectedObject = MyParam.runParam;
                    break;

                //Time
                case MyDefine.treenodeTime:
                    propertyGrid.SelectedObject = MyParam.commonParam.timeDelay;
                    break;


                //RS232
                case MyDefine.treenodeRS232:
                    propertyGrid.SelectedObject = MyParam.commonParam.myComport;
                    break;

                case MyDefine.treenodeTheme:
                    propertyGrid.SelectedObject = MyParam.uIParam;
                    break;

                case MyDefine.treenodeDev:
                    propertyGrid.SelectedObject = MyParam.commonParam.devParam;
                    break;
            }
            

        }

        private void propertyGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            propertyGrid.Update();
        }


        private void btnSaveParam_Click(object sender, EventArgs e)
        {
            MyLib.SaveParamter();
            MyLib.showDlgInfo("Save parameter success");
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.propertyGrid.Refresh();
        }
    }
}
