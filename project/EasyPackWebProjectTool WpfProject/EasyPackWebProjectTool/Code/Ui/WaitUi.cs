using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// [等待]界面的逻辑
    /// </summary>
    class WaitUi
    {
        #region [打开和关闭]
        /// <summary>
        /// 打开或者关闭 这个界面
        /// </summary>
        /// <param name="_isOpen">是否打开？</param>
        public void OpenOrCloseUi(bool _isOpen)
        {
            if (_isOpen == true)
            {
                AppManager.MainWindow.WaitUiControl.Visibility = Visibility.Visible;
            }
            else
            {
                AppManager.MainWindow.WaitUiControl.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region [更新Ui]
        /// <summary>
        /// 更新Ui
        /// </summary>
        public void UpdateUi()
        {
            WaitUiControl _waitUiControl = AppManager.MainWindow.WaitUiControl;
            LanguageSystem _languageSystem = AppManager.Systems.LanguageSystem;

            /* 更新Ui */
            _waitUiControl.WaitTextBlock.Text = _languageSystem.waitInWaitUi;
        }
        #endregion
    }
}
