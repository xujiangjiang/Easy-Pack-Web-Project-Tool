using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// [js相关的配置文件]的数据
    /// </summary>
    class JsData
    {
        #region [变量]
        public List<string> filePaths;//所有要导出的js文件  (文件夹+文件名+文件后缀)（相对路径，相对于配置文件的路径）
        public bool isDeleteCommentedOutCode;//是否删除js中的注释代码?
        public string outputPath;//js文件要导出到哪里?  (文件夹+文件名+文件后缀)（相对路径，相对于配置文件的路径）
        #endregion


        #region [构造函数]
        public JsData()
        {
            filePaths = new List<string>();
            isDeleteCommentedOutCode = false;
            outputPath = "";
        }
        #endregion

    }
}
