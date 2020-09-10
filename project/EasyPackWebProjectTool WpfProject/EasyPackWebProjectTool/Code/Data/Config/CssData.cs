using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// [css相关的配置文件]的数据
    /// </summary>
    class CssData
    {
        #region [变量]
        public List<string> filePaths;//所有要导出的css文件 (文件夹+文件名+文件后缀)（相对路径，相对于配置文件的路径）
        public bool isDeleteCommentedOutCode;//是否删除css中的注释代码?
        public string outputPath;//css文件要导出到哪里? (文件夹+文件名+文件后缀)（相对路径，相对于配置文件的路径）

        public bool isOutputOtherFile;//是否打包css文件中的其他文件 (比如图片文件\字体文件)
        public string otherFileOutputPath;//要将其他文件,导出到哪里?（文件夹+文件名+文件后缀）（1个文件夹）（相对路径，相对于OutputPath的路径）
        public bool isOtherFileConvertBase64;//是否把其他文件,转换为base64格式?
        public int base64ConvertLimit;//如果文件小于多少B,就把这个文件转换为base64格式 (单位B(1024B = 1KB))
        #endregion


        #region [构造函数]
        public CssData()
        {
            filePaths = new List<string>();
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
