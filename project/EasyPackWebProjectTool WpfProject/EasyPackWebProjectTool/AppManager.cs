/*
    App：Easy Pack Web Project Tool
    By：絮大王（XuDaWang）
    Email：xudawang@vip.163.com
    Github：https://github.com/xujiangjiang/
    Time：2020.09.08
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// App的所有属性和逻辑
    /// </summary>
    class AppManager
    {
        private static App mainApp;//App的逻辑
        private static MainWindow mainWindow;//窗口的逻辑

        /* 子系统 */
        private static Datas datas;//所有的数据
        private static Systems systems;//所有的系统
        private static Uis uis;//所有的界面


        #region [属性]
        /// <summary>
        /// App的逻辑
        /// </summary>
        public static App MainApp
        {
            get { return mainApp; }
            set { mainApp = value; }
        }

        /// <summary>
        /// 窗口的逻辑
        /// </summary>
        public static MainWindow MainWindow
        {
            get { return mainApp.MainWindow as MainWindow; }
        }




        /// <summary>
        /// 所有的数据
        /// </summary>
        public static Datas Datas
        {
            get { return datas; }
        }

        /// <summary>
        /// 所有的系统
        /// </summary>
        public static Systems Systems
        {
            get { return systems; }
        }

        /// <summary>
        /// 所有的界面
        /// </summary>
        public static Uis Uis
        {
            get { return uis; }
        }
        #endregion

        #region [构造方法]
        static AppManager()
        {
            datas = new Datas();
            systems = new Systems();
            uis = new Uis();
        }
        #endregion

        #region [初始化]
        /// <summary>
        /// 启动程序（在Start()之前）
        /// </summary>
        public static void Awake()
        {
        }


        /// <summary>
        /// 初始化程序
        /// </summary>
        public static void Start()
        {
            ///* 读取数据 */
            //Systems.SaveSystem.Load();

            /* 读取英文 */
            Systems.LanguageSystem.ChangeLanguage(LanguageType.English);
        }


        /// <summary>
        /// 退出程序
        /// </summary>
        public static void Exit()
        {
            ///* 保存数据 */
            //systems.SaveSystem.Save();//保存App数据
        }
        #endregion
    }
}
