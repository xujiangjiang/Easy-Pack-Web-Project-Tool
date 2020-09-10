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
        /// <returns>Mime类型 (如果为""，就是没找到)</returns>
        public string GetFileMimeType(string _extensionName)
        {
            //Mime的类型
            string _mimeType = "";

            //查找这个后缀名对应的Mime类型
            if (mimeTypes!=null)
            {
                //遍历所有的mimeType
                for(int i=0; i<mimeTypes.Length; i++)
                {
                    if(mimeTypes[i].ExtensionName == _extensionName)
                    {
                        _mimeType = mimeTypes[i].MimeType;
                        break;
                    }
                }
            }

            //返回值
            return _mimeType;
        }
        #endregion

    }
}
