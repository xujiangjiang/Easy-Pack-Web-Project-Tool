using EasyPackWebProjectTool.Code.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// 所有的系统
    /// </summary>
    class Systems
    {
        #region [变量]
        private ConfigSystem configSystem;//[配置文件]的系统
        private MimeSystem mimeSystem;//[Mime类型]的系统
        private PackSystem packSystem;//[打包]的系统
        private LanguageSystem languageSystem;//[语言]的系统
        #endregion



        #region [属性]
        /// <summary>
        /// [配置文件]的系统
        /// </summary>
        public ConfigSystem ConfigSystem
        {
            get { return configSystem; }
        }

        /// <summary>
        /// [Mime类型]的系统
        /// </summary>
        public MimeSystem MimeSystem
        {
            get { return mimeSystem; }
        }

        /// <summary>
        /// [打包]的系统
        /// </summary>
        public PackSystem PackSystem
        {
            get { return packSystem; }
        }

        /// <summary>
        /// [语言]的系统
        /// </summary>
        public LanguageSystem LanguageSystem
        {
            get { return languageSystem; }
        }
        #endregion



        #region [构造函数]
        public Systems()
        {
            configSystem = new ConfigSystem();
            mimeSystem = new MimeSystem();
            packSystem = new PackSystem();
            languageSystem = new LanguageSystem();
        }
        #endregion
    }
}
