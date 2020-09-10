using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// 用于存放所有的数据
    /// （里面存放着所有要绑定的数据）
    /// </summary>
    class Datas
    {
        /*变量*/
        private ConfigData configData;//配置的数据
        private SettingData settingData;//设置的数据


        #region [属性]
        /// <summary>
        /// 配置的数据
        /// </summary>
        public ConfigData ConfigData
        {
            get { return configData; }
            set
            {
                configData = value;
            }
        }

        /// <summary>
        /// 设置的数据
        /// </summary>
        public SettingData SettingData
        {
            get { return settingData; }
            set
            {
                settingData = value;
            }
        }
        #endregion

        #region [构造函数]
        public Datas()
        {
            configData = new ConfigData();
            settingData = new SettingData();
        }
        #endregion
    }
}
