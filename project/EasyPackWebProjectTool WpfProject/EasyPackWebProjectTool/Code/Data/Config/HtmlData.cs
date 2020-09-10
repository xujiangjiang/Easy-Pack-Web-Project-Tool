using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// Html的数据
    /// </summary>
    class HtmlData
    {
        #region [变量]
        public string filePath;//所有要导出的html文件 (文件夹+文件名+文件后缀)（相对路径，相对于配置文件的路径）
        public bool isDeleteCommentedOutCode;//是否删除html中的注释代码?
        public string outputPath;//html文件要导出到哪里? (文件夹+文件名+文件后缀)（相对路径，相对于配置文件的路径）

        public bool isOutputOtherFile;//是否打包html文件中的其他文件 (比如图片文件\字体文件)
        public string otherFileOutputPath;//要将其他文件,导出到哪里? （文件夹+文件名+文件后缀）（1个文件夹）（相对路径，相对于OutputPath的路径）
        public bool isOtherFileConvertBase64;//是否把其他文件,转换为base64格式?
        public int base64ConvertLimit;//如果文件小于多少B,就把这个文件转换为base64格式 (单位B(1024B = 1KB))
        #endregion

        #region [构造函数]
        public HtmlData()
        {
            filePath = "";
            isDeleteCommentedOutCode = false;
            outputPath = "";

            isOutputOtherFile = false;
            otherFileOutputPath = "";
            isOtherFileConvertBase64 = false;
            base64ConvertLimit = 10240;
        }
        #endregion
    }
}
