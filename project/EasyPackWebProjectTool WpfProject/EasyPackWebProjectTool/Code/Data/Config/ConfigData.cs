using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// [配置文件]的数据
    /// </summary>
    class ConfigData
    {
        #region [变量]
        public string configFilePath;//配置文件的路径
        public JsData js;//js的配置数据(我们要如何打包js文件?)
        public CssData css;//css的配置数据(我们要如何打包css文件?)
        public HtmlData html;//html的配置数据（我们要如何打包html文件?）
        #endregion


        #region [构造函数]
        public ConfigData()
        {
            configFilePath = "";
            js = new JsData();
            css = new CssData();
            html = new HtmlData();
        }
        #endregion

    }
}
