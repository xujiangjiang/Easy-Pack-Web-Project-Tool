using LitJson;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// [打包]界面的逻辑
    /// </summary>
    class PackUi
    {

        #region [打开和关闭]
        /// <summary>
        /// 打开或者关闭 这个界面
        /// </summary>
        /// <param name="_isOpen">是否打开？</param>
        public void OpenOrCloseUi(bool _isOpen)
        {
            if(_isOpen == true)
            {
                AppManager.MainWindow.PackUiControl.Visibility = Visibility.Visible;
            }
            else
            {
                AppManager.MainWindow.PackUiControl.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 打开或者关闭 配置文件的面板
        /// </summary>
        /// <param name="_isOpen">是否打开？</param>
        public void OpenOrCloseConfigPanel(bool _isOpen)
        {
            if (_isOpen == true)
            {
                AppManager.MainWindow.PackUiControl.ConfigStackPanel.Visibility = Visibility.Visible;
                AppManager.MainWindow.PackUiControl.OkStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                AppManager.MainWindow.PackUiControl.ConfigStackPanel.Visibility = Visibility.Collapsed;
                AppManager.MainWindow.PackUiControl.OkStackPanel.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region [更新Ui]
        /// <summary>
        /// 更新Ui
        /// </summary>
        /// <param name="_configData">配置文件的数据</param>
        public void UpdateUi(ConfigData _configData)
        {
            PackUiControl _packUiControl = AppManager.MainWindow.PackUiControl;
            LanguageSystem _languageSystem = AppManager.Systems.LanguageSystem;

            /* 更新Ui */
            //配置文件
            _packUiControl.TitleTextBlock.Text = _languageSystem.titleInPackUi;
            _packUiControl.Content1TextBlock.Text = _languageSystem.content1InPackUi;
            _packUiControl.Content2TextBlock.Text = _languageSystem.content2InPackUi;
            _packUiControl.Content3TextBlock.Text = _languageSystem.content3InPackUi;
            _packUiControl.IntroductionButton.Content = _languageSystem.introductionButtonInPackUi;
            _packUiControl.ChooseConfigButton.Content = _languageSystem.chooseConfigButtonInPackUi;
            _packUiControl.OkButton.Content = _languageSystem.okButtonInPackUi;
            _packUiControl.FilePathTextBox.Text = _configData.configFilePath;
            _packUiControl.NoteTextBlock.Text = Path.GetFileName(_configData.configFilePath) + _languageSystem.noteInPackUi;

            //Js文件
            _packUiControl.JsTitleTextBlock.Text = _languageSystem.jsTitleInPackUi;
            _packUiControl.JsFilePathsInfoControl.Title = _languageSystem.jsFilePathsTitleInPackUi;
            string _jsFilePaths = "";
            for(int i = 0; i<_configData.js.filePaths.Count;i++)
            {
                //如果是最后1个
                if (i == _configData.js.filePaths.Count - 1)
                {
                    _jsFilePaths += _configData.js.filePaths[i];
                }
                //如果不是最后1个
                else
                {
                    _jsFilePaths += _configData.js.filePaths[i]+"\n";
                }
            }
            _packUiControl.JsFilePathsInfoControl.Content = _jsFilePaths;
            _packUiControl.JsOutputPathInfoControl.Title = _languageSystem.jsOutputPathTitleInPackUi;
            _packUiControl.JsOutputPathInfoControl.Content = _configData.js.outputPath;
            _packUiControl.JsIsDeleteCommentedOutCodeInfoControl.Title = _languageSystem.jsIsDeleteCommentedOutCodeTitleInPackUi;
            _packUiControl.JsIsDeleteCommentedOutCodeInfoControl.Content = _configData.js.isDeleteCommentedOutCode+"";

            //Css文件
            _packUiControl.CssTitleTextBlock.Text = _languageSystem.cssTitleInPackUi;
            _packUiControl.CssFilePathsInfoControl.Title = _languageSystem.cssFilePathsTitleInPackUi;
            string _cssFilePaths = "";
            for (int i = 0; i < _configData.css.filePaths.Count; i++)
            {
                //如果是最后1个
                if (i == _configData.css.filePaths.Count - 1)
                {
                    _cssFilePaths += _configData.css.filePaths[i];
                }
                //如果不是最后1个
                else
                {
                    _cssFilePaths += _configData.css.filePaths[i] + "\n";
                }
            }
            _packUiControl.CssFilePathsInfoControl.Content = _cssFilePaths;
            _packUiControl.CssOutputPathInfoControl.Title = _languageSystem.cssOutputPathTitleInPackUi;
            _packUiControl.CssOutputPathInfoControl.Content = _configData.css.outputPath;
            _packUiControl.CssIsDeleteCommentedOutCodeInfoControl.Title = _languageSystem.cssIsDeleteCommentedOutCodeTitleInPackUi;
            _packUiControl.CssIsDeleteCommentedOutCodeInfoControl.Content = _configData.css.isDeleteCommentedOutCode + "";
            _packUiControl.CssIsOutputOtherFileInfoControl.Title = _languageSystem.cssIsOutputOtherFileTitleInPackUi;
            _packUiControl.CssIsOutputOtherFileInfoControl.Content = _configData.css.isOutputOtherFile+"";
            _packUiControl.CssOtherFileOutputPathInfoControl.Title = _languageSystem.cssOtherFileOutputPathTitleInPackUi;
            _packUiControl.CssOtherFileOutputPathInfoControl.Content = _configData.css.otherFileOutputPath;
            _packUiControl.CssIsOtherFileConvertBase64InfoControl.Title = _languageSystem.cssIsOtherFileConvertBase64TitleInPackUi;
            _packUiControl.CssIsOtherFileConvertBase64InfoControl.Content = _configData.css.isOtherFileConvertBase64+"";
            _packUiControl.CssBase64ConvertLimitInfoControl.Title = _languageSystem.cssBase64ConvertLimitTitleInPackUi;
            _packUiControl.CssBase64ConvertLimitInfoControl.Content = _configData.css.base64ConvertLimit + " B";

            //Html文件
            _packUiControl.HtmlTitleTextBlock.Text = _languageSystem.htmlTitleInPackUi;
            _packUiControl.HtmlFilePathInfoControl.Title = _languageSystem.htmlFilePathTitleInPackUi;
            _packUiControl.HtmlFilePathInfoControl.Content = _configData.html.filePath;
            _packUiControl.HtmlOutputPathInfoControl.Title = _languageSystem.htmlOutputPathTitleInPackUi;
            _packUiControl.HtmlOutputPathInfoControl.Content = _configData.html.outputPath;
            _packUiControl.HtmlIsDeleteCommentedOutCodeInfoControl.Title = _languageSystem.htmlIsDeleteCommentedOutCodeTitleInPackUi;
            _packUiControl.HtmlIsDeleteCommentedOutCodeInfoControl.Content = _configData.html.isDeleteCommentedOutCode + "";
            _packUiControl.HtmlIsOutputOtherFileInfoControl.Title = _languageSystem.htmlIsOutputOtherFileTitleInPackUi;
            _packUiControl.HtmlIsOutputOtherFileInfoControl.Content = _configData.html.isOutputOtherFile + "";
            _packUiControl.HtmlOtherFileOutputPathInfoControl.Title = _languageSystem.htmlOtherFileOutputPathTitleInPackUi;
            _packUiControl.HtmlOtherFileOutputPathInfoControl.Content = _configData.html.otherFileOutputPath;
            _packUiControl.HtmlIsOtherFileConvertBase64InfoControl.Title = _languageSystem.htmlIsOtherFileConvertBase64TitleInPackUi;
            _packUiControl.HtmlIsOtherFileConvertBase64InfoControl.Content = _configData.html.isOtherFileConvertBase64 + "";
            _packUiControl.HtmlBase64ConvertLimitInfoControl.Title = _languageSystem.htmlBase64ConvertLimitTitleInPackUi;
            _packUiControl.HtmlBase64ConvertLimitInfoControl.Content = _configData.html.base64ConvertLimit + " B";
        }
        #endregion

        #region [事件]

        /// <summary>
        /// 当点击[选择文件]按钮时
        /// </summary>
        public void ClickChooseFileButton()
        {
            //OpenFileDialog对象 用于创建 [打开文件] 对话框
            OpenFileDialog _openFileDialog = new OpenFileDialog();

            //设置文件过略
            _openFileDialog.Filter = "配置文件|*.json";

            //显示[打开文件对话框]
            bool? _isChooseFile = _openFileDialog.ShowDialog();

            //如果用户没有选择文件
            if(_isChooseFile == null || _isChooseFile == false)
            {
                
            }
            //如果用户选择了文件
            else
            {
                //获取这个文件的路径
                string _filePath = _openFileDialog.FileName;

                //读取这个配置文件
                bool _isOk = AppManager.Systems.ConfigSystem.ReadConfigFile(_filePath);

                //更新UI
                if(_isOk == true)
                {
                    //如果读取成功,就更新Ui
                    UpdateUi(AppManager.Datas.ConfigData);
                    //打开界面
                    OpenOrCloseConfigPanel(true);
                }
                //如果读取失败
                else
                {
                    //关闭界面，并弹出消息
                    OpenOrCloseConfigPanel(false);
                    MessageBox.Show("读取失败，配置文件有错误！","[错误]",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                
            }
        }
        
        /// <summary>
        /// 当点击[Ok]按钮时
        /// </summary>
        public void ClickOkButton()
        {
            /* 显示正在导出界面 */
            AppManager.Uis.WaitUi.OpenOrCloseUi(true);

            /* 配置文件 */
            bool _isOk = AppManager.Systems.PackSystem.Pack(AppManager.Datas.ConfigData);

            /* 关闭正在导出界面 */
            AppManager.Uis.WaitUi.OpenOrCloseUi(false);

            /* 显示导出成功 */
            if (_isOk == true) {
                MessageBox.Show("导出成功！","[成功]",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// 当点击[介绍]按钮时
        /// </summary>
        public void ClickIntroductionButton()
        {
            //打开Github的界面（调用系统默认的浏览器）
            System.Diagnostics.Process.Start("https://github.com/xujiangjiang/Easy-Pack-Web-Project-Tool");
        }

        #endregion

    }
}
