using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// 语言的界面
    /// </summary>
    class LanguageUi
    {
        #region [事件]
        /// <summary>
        /// 当点击[英文]按钮时
        /// </summary>
        public void ClickEnglishButton() 
        {
            //如果当前是英文，就不运行后面的代码啦
            if (AppManager.Datas.SettingData.LanguageType == LanguageType.English) return;

            //把中文按钮的背景设置为透明，把英文按钮的背景设置为灰色
            AppManager.MainWindow.LanguageUiControl.EnglishButton.Background = new SolidColorBrush(Color.FromRgb(211,211,211));
            AppManager.MainWindow.LanguageUiControl.ChineseButton.Background = new SolidColorBrush(Color.FromArgb(0,0,0,0));

            //修改语言
            AppManager.Systems.LanguageSystem.ChangeLanguage(LanguageType.English);
        }

        /// <summary>
        /// 当点击[中文]按钮时
        /// </summary>
        public void ClickChineseButton() 
        {
            //如果当前是中文，就不运行后面的代码啦
            if (AppManager.Datas.SettingData.LanguageType == LanguageType.Chinese) return;

            //把英文按钮的背景设置为透明，把中文按钮的背景设置为灰色
            AppManager.MainWindow.LanguageUiControl.ChineseButton.Background = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            AppManager.MainWindow.LanguageUiControl.EnglishButton.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            //修改语言
            AppManager.Systems.LanguageSystem.ChangeLanguage(LanguageType.Chinese);
        }
        #endregion
    }
}
