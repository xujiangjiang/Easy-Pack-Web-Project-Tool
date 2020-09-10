using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// 语言的系统
    /// </summary>
    class LanguageSystem
    {
        /* 变量 */
        //打包界面
        public string noteInPackUi = " 配置文件的信息如下：";
        public string titleInPackUi = "打开配置文件";
        public string content1InPackUi = "请选择配置文件。";
        public string content2InPackUi = "如果你不知道如何使用这个软件，请";
        public string content3InPackUi = "，查看教程。";
        public string introductionButtonInPackUi = "点击这里";
        public string chooseConfigButtonInPackUi = "选择配置文件";
        public string okButtonInPackUi = "开始打包";

        public string jsTitleInPackUi = "Js文件";
        public string jsFilePathsTitleInPackUi = "将下列js文件，打包为1个js文件：";
        public string jsOutputPathTitleInPackUi = "要把打包后的.js文件,保存到哪里？";
        public string jsIsDeleteCommentedOutCodeTitleInPackUi = "是否去掉注释？";

        public string cssTitleInPackUi = "Css文件";
        public string cssFilePathsTitleInPackUi = "将下列css文件，打包为1个css文件：";
        public string cssOutputPathTitleInPackUi = "要把打包后的.css文件,保存到哪里？";
        public string cssIsDeleteCommentedOutCodeTitleInPackUi = "是否去掉注释？";
        public string cssIsOutputOtherFileTitleInPackUi = "是否导出图片（和其他文件）？";
        public string cssOtherFileOutputPathTitleInPackUi = "图片（和其他文件）的导出位置：";
        public string cssIsOtherFileConvertBase64TitleInPackUi = "是否要把文件自动转换为base64字符串？";
        public string cssBase64ConvertLimitTitleInPackUi = "文件小于多少，就转换为base64字符串？";

        public string htmlTitleInPackUi = "Html文件";
        public string htmlFilePathTitleInPackUi = "将下列html文件进行打包：";
        public string htmlOutputPathTitleInPackUi = "要把打包后的.html文件,保存到哪里？";
        public string htmlIsDeleteCommentedOutCodeTitleInPackUi = "是否去掉注释？";

        //等待界面
        public string waitInWaitUi = "打包中...";



        #region [公开方法]
        /// <summary>
        /// 修改语言
        /// </summary>
        /// <param name="_languageType">语言的类型</param>
        public void ChangeLanguage(LanguageType _languageType)
        {
            //修改数据
            AppManager.Datas.SettingData.LanguageType = _languageType;

            //如果是中文
            if(_languageType == LanguageType.Chinese)
            {
                noteInPackUi = " 配置文件的信息如下：";
                titleInPackUi = "打开配置文件";
                content1InPackUi = "请选择配置文件。";
                content2InPackUi = "如果你不知道如何使用这个软件，请";
                content3InPackUi = "，查看教程。";
                introductionButtonInPackUi = "点击这里";
                chooseConfigButtonInPackUi = "选择配置文件";
                okButtonInPackUi = "开始打包";

                jsTitleInPackUi = "Js文件";
                jsFilePathsTitleInPackUi = "将下列js文件，打包为1个js文件：";
                jsOutputPathTitleInPackUi = "要把打包后的.js文件,保存到哪里？";
                jsIsDeleteCommentedOutCodeTitleInPackUi = "是否去掉注释？";

                cssTitleInPackUi = "Css文件";
                cssFilePathsTitleInPackUi = "将下列css文件，打包为1个css文件：";
                cssOutputPathTitleInPackUi = "要把打包后的.css文件,保存到哪里？";
                cssIsDeleteCommentedOutCodeTitleInPackUi = "是否去掉注释？";
                cssIsOutputOtherFileTitleInPackUi = "是否导出图片（和其他文件）？";
                cssOtherFileOutputPathTitleInPackUi = "图片（和其他文件）的导出位置：";
                cssIsOtherFileConvertBase64TitleInPackUi = "是否要把文件自动转换为base64字符串？";
                cssBase64ConvertLimitTitleInPackUi = "文件小于多少，就转换为base64字符串？";

                htmlTitleInPackUi = "Html文件";
                htmlFilePathTitleInPackUi = "将下列html文件进行打包：";
                htmlOutputPathTitleInPackUi = "要把打包后的.html文件,保存到哪里？";
                htmlIsDeleteCommentedOutCodeTitleInPackUi = "是否去掉注释？";

                waitInWaitUi = "打包中...";
            }

            //如果是英文
            else
            {
                noteInPackUi = " configuration file:";
                titleInPackUi = "Open the configuration file";
                content1InPackUi = "Please open the configuration file.";
                content2InPackUi = "If you don't know how to use, please";
                content3InPackUi = " to view the tutorial.";
                introductionButtonInPackUi = "click here";
                chooseConfigButtonInPackUi = "Open a configured file";
                okButtonInPackUi = "Start packing";

                jsTitleInPackUi = "Js File";
                jsFilePathsTitleInPackUi = "Pack the following js files into 1 js file:";
                jsOutputPathTitleInPackUi = "Where should I save the packaged .js file?";
                jsIsDeleteCommentedOutCodeTitleInPackUi = "Do you remove the commented-out code?";

                cssTitleInPackUi = "Css File";
                cssFilePathsTitleInPackUi = "Pack the following js files into 1 css file:";
                cssOutputPathTitleInPackUi = "Where should I save the packaged .css file?";
                cssIsDeleteCommentedOutCodeTitleInPackUi = "Do you remove the commented-out code?";
                cssIsOutputOtherFileTitleInPackUi = "Do you want to export image files (and other files)?";
                cssOtherFileOutputPathTitleInPackUi = "Where to export image files (and other files):";
                cssIsOtherFileConvertBase64TitleInPackUi = "Do you want to automatically convert the file to base64 string?";
                cssBase64ConvertLimitTitleInPackUi = "When the file is smaller than how much, convert the file to base64 string?";

                htmlTitleInPackUi = "Html File";
                htmlFilePathTitleInPackUi = "Package the following html files:";
                htmlOutputPathTitleInPackUi = "Where should I save the packaged .html file?";
                htmlIsDeleteCommentedOutCodeTitleInPackUi = "Do you remove the commented-out code?";

                waitInWaitUi = "Packing...";
            }

            //TODO：保存


            //更新Ui
            AppManager.Uis.PackUi.UpdateUi(AppManager.Datas.ConfigData);
            AppManager.Uis.WaitUi.UpdateUi();
        }
        #endregion

    }
}
