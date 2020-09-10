using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }





        #region [初始化]
        //当窗口初始化时，触发此方法
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //初始化
            AppManager.Start();
        }
        #endregion



        #region [事件 - 打包界面]
        /// <summary>
        /// 按下[选择文件]按钮时
        /// </summary>
        private void PackUiControl_ClickChooseFileButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //触发事件
            AppManager.Uis.PackUi.ClickChooseFileButton();
        }

        /// <summary>
        /// 按下[确认]按钮时
        /// </summary>
        private void PackUiControl_ClickOkButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //触发事件
            AppManager.Uis.PackUi.ClickOkButton();
        }

        /// <summary>
        /// 按下[介绍]按钮时
        /// </summary>
        private void PackUiControl_ClickIntroductionButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //触发事件
            AppManager.Uis.PackUi.ClickIntroductionButton();
        }
        #endregion

        #region [事件 - 语言界面]
        /// <summary>
        /// 按下[中文]按钮时
        /// </summary>
        private void LanguageUiControl_ClickChineseButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //触发事件
            AppManager.Uis.LanguageUi.ClickChineseButton();
        }

        /// <summary>
        /// 按下[英文]按钮时
        /// </summary>
        private void LanguageUiControl_ClickEnglishButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            //触发事件
            AppManager.Uis.LanguageUi.ClickEnglishButton();
        }
        #endregion

    }
}
