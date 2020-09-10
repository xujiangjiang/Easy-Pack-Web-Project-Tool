using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// Mime类型的系统
    /// </summary>
    class MimeSystem
    {
        //所有的Mime类型
        private MimeData[] mimeTypes;



        #region [构造函数]
        public MimeSystem()
        {
            //如果文件存在
            if(File.Exists(System.Environment.CurrentDirectory + "/Asset/MimeType.json") == true)
            {
                //读取MimeType.json文件
                string _json = File.ReadAllText(System.Environment.CurrentDirectory + "/Asset/MimeType.json");

                //把json转换成对象
                mimeTypes = JsonMapper.ToObject<MimeData[]>(_json);
            }
        }
        #endregion

        #region [公开方法]
        /// <summary>
        /// 获取文件的Mime类型
        /// </summary>
        /// <param name="_extensionName">文件的后缀名</param>
        /// <param name="_fileType">文件的类型</param>
        /// <returns>Mime类型 (如果为""，就是没找到)</returns>
        public string GetFileMimeType(string _extensionName, FileType _fileType = FileType.None)
        {
            //Mime的类型
            string _mimeType = "";

            //查找这个后缀名对应的Mime类型
            switch (_fileType)
            {
                //如果没有指定文件的类型
                case FileType.None:
                    if (mimeTypes != null)
                    {
                        //遍历所有的mimeType
                        for (int i = 0; i < mimeTypes.Length; i++)
                        {
                            if (mimeTypes[i].ExtensionName == _extensionName)
                            {
                                _mimeType = mimeTypes[i].MimeType;
                                break;
                            }
                        }
                    }
                    break;

                //如果文件是音频
                case FileType.Audio:
                    if(_extensionName == ".wav")
                    {
                        _mimeType = "audio/wav";
                    }
                    else if (_extensionName == ".ogg")
                    {
                        _mimeType = "audio/ogg";
                    }
                    else if (_extensionName == ".mp3")
                    {
                        _mimeType = "audio/mpeg";
                    }
                    break;

                //如果文件是视频
                case FileType.Video:
                    if (_extensionName == ".mp4")
                    {
                        _mimeType = "video/mp4";
                    }
                    else if (_extensionName == ".ogg")
                    {
                        _mimeType = "video/ogg";
                    }
                    else if (_extensionName == ".webm")
                    {
                        _mimeType = "video/webm";
                    }
                    break;
            }


            //返回值
            return _mimeType;
        }
        #endregion

    }
}
