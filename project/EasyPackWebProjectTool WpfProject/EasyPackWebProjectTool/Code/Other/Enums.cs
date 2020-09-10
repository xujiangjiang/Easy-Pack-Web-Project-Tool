using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPackWebProjectTool
{
    /*所有的枚举类型*/


    /// <summary>
    /// 语言类型
    /// </summary>
    public enum LanguageType : byte
    {
        None,
        English,//英语
        Chinese//中文
    }

    /// <summary>
    /// 文件类型
    /// </summary>
    public enum FileType : byte
    {
        None,
        Text,//文本
        Image,//图片
        Audio,//音频
        Video//视频
    }
}
