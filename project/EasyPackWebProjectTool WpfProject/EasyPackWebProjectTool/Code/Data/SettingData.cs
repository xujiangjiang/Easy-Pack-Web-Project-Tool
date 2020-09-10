using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// 设置的数据
    /// </summary>
    class SettingData
    {
        /// <summary>
        /// 语言的类型
        /// </summary>
        public LanguageType LanguageType{ get; set; }


        #region [构造函数]
        public SettingData()
        {
            LanguageType = LanguageType.English;
        }
        #endregion
    }
}
