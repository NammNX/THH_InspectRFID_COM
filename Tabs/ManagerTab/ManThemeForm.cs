using MaterialSkin;
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
using TanHungHa.Common;

namespace TanHungHa.Tabs.ManualTab
{
    public partial class ManThemeForm : MaterialForm
    {
        private static ManThemeForm _instance;
        private static readonly object _lock = new object();
        public static ManThemeForm GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ManThemeForm();
                    }
                }
            }
            return _instance;
        }


        public ManThemeForm()
        {
            InitializeComponent();
            initFormStyte();
            bindingUI();
        }

        #region tab Theme


        private void initFormStyte()
        {
            materialListBoxFormStyle.Clear();
            foreach (var FormStyleItem in Enum.GetNames(typeof(MaterialForm.FormStyles)))
            {
                materialListBoxFormStyle.AddItem(FormStyleItem);
                if (FormStyleItem == MyParam.uIParam.styles.ToString())
                    materialListBoxFormStyle.SelectedIndex = materialListBoxFormStyle.Items.Count - 1;
            }

            materialListBoxFormStyle.SelectedIndexChanged += (sender, args) =>
            {
                if (MyParam.mainForm == null) { return; }
                MaterialForm.FormStyles SelectedStyle = (MaterialForm.FormStyles)Enum.Parse(typeof(MaterialForm.FormStyles), args.Text);
                if (MyParam.mainForm.FormStyle != SelectedStyle)
                {
                    MyParam.mainForm.FormStyle = SelectedStyle;
                    MyParam.uIParam.styles = SelectedStyle;
                }
            };
        }

        private void bindingUI()
        {
            swUserColors.DataBindings.Add("Checked", MyParam.uIParam, "swAutoShow", true, DataSourceUpdateMode.OnPropertyChanged);
            swHighlightWithAccent.DataBindings.Add("Checked", MyParam.uIParam, "swHighlightWithAccent", true, DataSourceUpdateMode.OnPropertyChanged);
            swBackgroundWithAccent.DataBindings.Add("Checked", MyParam.uIParam, "swBackgroundWithAccent", true, DataSourceUpdateMode.OnPropertyChanged);
            swDisplayIconWhenHidden.DataBindings.Add("Checked", MyParam.uIParam, "swDisplayIconWhenHidden", true, DataSourceUpdateMode.OnPropertyChanged);
            swAutoShow.DataBindings.Add("Checked", MyParam.uIParam, "swAutoShow", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            MyParam.uIParam.colorSchemeIndex++;
            if (MyParam.uIParam.colorSchemeIndex > 2)
                MyParam.uIParam.colorSchemeIndex = 0;
            MyLib.updateColor();
            Invalidate();
        }




        private void btnChangeTheme_Click(object sender, EventArgs e)
        {
            MyParam.materialSkinManager.Theme = MyParam.materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            MyParam.uIParam.themes = MyParam.materialSkinManager.Theme;
            MyLib.updateColor();
            Invalidate();
        }



        private void sw_CheckedChanged(object sender, EventArgs e)
        {
            MaterialSwitch materialSwitch = (MaterialSwitch)sender;
            switch (materialSwitch.Name)
            {
                case "swUserColors":
                    MyParam.mainForm.DrawerUseColors = swUserColors.Checked;

                    break;

                case "swHighlightWithAccent":
                    MyParam.mainForm.DrawerHighlightWithAccent = swHighlightWithAccent.Checked;
                    break;

                case "swBackgroundWithAccent":
                    MyParam.mainForm.DrawerBackgroundWithAccent = swBackgroundWithAccent.Checked;
                    break;

                case "swDisplayIconWhenHidden":
                    MyParam.mainForm.DrawerShowIconsWhenHidden = swDisplayIconWhenHidden.Checked;
                    break;

                case "swAutoShow":
                    MyParam.mainForm.DrawerAutoShow = swAutoShow.Checked;
                    break;

            }
        }

        private void btnSaveTheme_Click(object sender, EventArgs e)
        {
            SaveLoadParameter.Save_Parameter(MyParam.uIParam, MyDefine.file_uiParam);
        }

        #endregion
    }
}
