using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// 配置文件的系统
    /// </summary>
    class ConfigSystem
    {
        #region [读取]
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="_filePath">配置文件的路径</param>
        /// <returns>是否读取成功？</returns>
        public bool ReadConfigFile(string _filePath)
        {
            //读取这个.json文件
            string _json = File.ReadAllText(_filePath);

            //配置文件的数据
            ConfigData _configData = null;

            //把.json文件解析成对象
            try
            {
                _configData = JsonMapper.ToObject<ConfigData>(_json);
            }
            catch
            {
                return false;
            }

            //如果转换成功
            if (_configData != null && 
                (_configData.js.filePaths.Count > 0 || _configData.css.filePaths.Count > 0 || _configData.html.filePath!=""))
            {
                //赋值
                AppManager.Datas.ConfigData = _configData;
                AppManager.Datas.ConfigData.configFilePath = _filePath;

                //返回值
                return true;
            }
            else
            {
                //返回值
                return false;
            }
        }
        #endregion
    }
}
