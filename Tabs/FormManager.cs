using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TanHungHa.Common;

namespace TanHungHa.Tabs
{
    public partial class FormManager : MaterialForm
    {
        private static FormManager _instance;
        private static readonly object _lock = new object();
        public static FormManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FormManager();
                    }
                }
            }
            return _instance;
        }

        public FormManager()
        {
            InitializeComponent();
            InitGUI();
        }

        void InitGUI()
        {
            this.Text = MyDefine.title;
            materialTabControlManager.SelectedTab = tabPageParameter;
            materialTabControlManager.Selected += MaterialTabControlManager_Selected;


            MyParam.tabManagerParam.TopLevel = false;
            MyParam.tabManagerParam.FormBorderStyle = FormBorderStyle.None;
            MyParam.tabManagerParam.Dock = DockStyle.Fill;

            MyParam.tabManagerTheme.TopLevel = false;
            MyParam.tabManagerTheme.FormBorderStyle = FormBorderStyle.None;
            MyParam.tabManagerTheme.Dock = DockStyle.Fill;

            
            tabPageParameter.Controls.Add(MyParam.tabManagerParam);
            tabPageParameter.Tag = (MyParam.tabManagerParam);


            tabPageTheme.Controls.Add(MyParam.tabManagerTheme);
            tabPageTheme.Tag = (MyParam.tabManagerTheme);

            MyParam.tabManagerParam.BringToFront();
            MyParam.tabManagerParam.Show();

            MyParam.tabManagerTheme.BringToFront();
            MyParam.tabManagerTheme.Show();


        }

      

        private void MaterialTabControlManager_Selected(object sender, TabControlEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action);
            messageBoxCS.AppendLine();
            Console.WriteLine(messageBoxCS.ToString());

            switch (e.TabPage.Name)
            {


                case "tabPageParameter":
                    MyParam.curManagerView = eManagerView.MANAGER_PARAMTER_VIEW;
                    MyParam.tabManagerParam.InitTreeView();
                    break;
                
                case "tabPageTheme":
                    MyParam.curManagerView = eManagerView.MANAGER_THEME_VIEW;
                    break;


            }
        }

    }
}
