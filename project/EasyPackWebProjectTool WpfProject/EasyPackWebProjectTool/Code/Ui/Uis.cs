using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// 所有的界面
    /// </summary>
    class Uis
    {
        #region [变量]
        private PackUi packUi;//[打包]的界面
        private LanguageUi languageUi;//[语言]的界面
        private WaitUi waitUi;//[等待]的界面
        #endregion



        #region [属性]
        /// <summary>
        /// [打包]的界面
        /// </summary>
        public PackUi PackUi
        {
            get { return packUi; }
        }

        /// <summary>
        /// [语言]的界面
        /// </summary>
        public LanguageUi LanguageUi
        {
            get { return languageUi; }
        }

        /// <summary>
        /// [等待]的界面
        /// </summary>
        public WaitUi WaitUi
        {
            get { return waitUi; }
        }
        #endregion



        #region [构造函数]
        public Uis()
        {
            packUi = new PackUi();
            languageUi = new LanguageUi();
            waitUi = new WaitUi();
        }
        #endregion
    }
}
