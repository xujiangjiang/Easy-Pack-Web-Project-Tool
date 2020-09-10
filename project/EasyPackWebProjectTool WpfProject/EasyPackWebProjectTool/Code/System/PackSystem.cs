using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace EasyPackWebProjectTool.Code.System
{
    /// <summary>
    /// 打包的系统
    /// </summary>
    class PackSystem
    {
        #region [公开方法]
        /// <summary>
        /// 打包
        /// </summary>
        /// <param name="configData">配置文件的数据</param>
        /// <returns>是否打包成功？</returns>
        public bool Pack(ConfigData _configData)
        {
            /* 变量 */
            bool _isPackJsOk = false;//是否打包Js成功？
            bool _isPackCssOk = false;//是否打包css成功？
            bool _isPackHtmlOk = false;//是否打包html成功？

            /* 打包js文件 */
            _isPackJsOk = PackJsFile(_configData);

            /* 打包css文件 */
            if (_isPackJsOk == true)
            {
                _isPackCssOk = PackCssFile(_configData);

                if(_isPackCssOk == true)
                {
                    _isPackHtmlOk = PackHtmlFile(_configData);
                }
            }

            /* 返回值 */
            if (_isPackJsOk == true && _isPackCssOk == true && _isPackHtmlOk == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region [私有方法]
        /// <summary>
        /// 打包js文件
        /// </summary>
        /// <param name="_configData">配置文件</param>
        /// <returns>是否打包成功？</returns>
        private bool PackJsFile(ConfigData _configData)
        {
            //如果有js文件
            if (_configData.js.filePaths.Count > 0)
            {
                /* 合并文件 */
                //js的代码
                string _jsContent = "";

                //把.js文件合并在一起
                for (int i = 0; i < _configData.js.filePaths.Count; i++)
                {
                    //这个js文件的路径
                    string _jsFilePath = Path.Combine(Path.GetDirectoryName(_configData.configFilePath) + "/" + _configData.js.filePaths[i]);

                    //判断文件是否存在,如果不存在
                    if (File.Exists(_jsFilePath) == false)
                    {
                        //报错
                        MessageBox.Show("打包js文件时出现错误:\n" + _configData.js.filePaths[i] + "文件不存在!", "[错误]", MessageBoxButton.OK, MessageBoxImage.Error);

                        //返回
                        return false;
                    }

                    //把.js文件的内容,放到变量中
                    _jsContent += File.ReadAllText(_jsFilePath);
                }

                //如果要去掉注释
                if (_configData.js.isDeleteCommentedOutCode == true)
                {
                    //正则表达式 (匹配所有//和/**/的注释)
                    _jsContent = Regex.Replace(_jsContent, @"/\*{1,2}[\s\S]*?\*/", "", RegexOptions.Multiline);
                    _jsContent = Regex.Replace(_jsContent, @"//[\s\S]*?\n", "", RegexOptions.Multiline);

                    //去掉换行
                    _jsContent = Regex.Replace(_jsContent, @"^\s*\n", "", RegexOptions.Multiline);
                }


                /* 输出文件 */
                //输出的文件夹路径
                string _outputFilePath = Path.Combine(Path.GetDirectoryName(_configData.configFilePath) + "/" + _configData.js.outputPath);
                string _outputDirectoryPath = Path.GetDirectoryName(_outputFilePath);

                //如果文件夹不存在
                if (Directory.Exists(_outputDirectoryPath) == false)
                {
                    Directory.CreateDirectory(_outputDirectoryPath);
                }

                //导出打包好的文件
                File.WriteAllText(_outputFilePath, _jsContent);

            }

            /* 返回值 */
            return true;
        }

        /// <summary>
        /// 打包css文件
        /// </summary>
        /// <param name="_configData">配置文件</param>
        /// <returns>是否打包成功？</returns>
        private bool PackCssFile(ConfigData _configData)
        {
            //如果有css文件
            if (_configData.js.filePaths.Count > 0)
            {

                //css文件的内容
                string _cssContent = "";


                /* 合并文件 + 导出图片 */
                //遍历所有的css文件
                for (int i = 0; i < _configData.css.filePaths.Count; i++)
                {
                    //这个css文件的路径
                    string _cssFilePath = Path.Combine(Path.GetDirectoryName(_configData.configFilePath) + "/" + _configData.css.filePaths[i]);

                    //判断文件是否存在,如果不存在
                    if (File.Exists(_cssFilePath) == false)
                    {
                        //报错
                        MessageBox.Show("打包css文件时出现错误:\n" + _configData.css.filePaths[i] + "文件不存在!", "[错误]", MessageBoxButton.OK, MessageBoxImage.Error);

                        //返回
                        return false;
                    }

                    //读取文件
                    string _cssFileContent = File.ReadAllText(_cssFilePath);

                    //如果要导出文件
                    if (_configData.css.isOutputOtherFile == true)
                    {
                        //文件输出的路径
                        string _otherFileOutputPath = Path.Combine(Path.GetDirectoryName(_configData.configFilePath) + "/" + Path.GetDirectoryName(_configData.css.outputPath) + "/" + _configData.css.otherFileOutputPath);

                        //获取css文件中，所有的图片路径
                        MatchCollection _matchConllection = Regex.Matches(_cssFileContent, @"url(.*);", RegexOptions.Multiline);

                        //遍历所有的图片路径
                        for (int j = 0; j < _matchConllection.Count; j++)
                        {
                            //获取这个图片的路径(去掉前面的“url(”和后面的“);”)
                            string _urlPath = _matchConllection[j].Value;
                            _urlPath = Regex.Replace(_urlPath, @"^url\(", "", RegexOptions.Multiline);
                            _urlPath = Regex.Replace(_urlPath, @"\);$", "", RegexOptions.Multiline);

                            //图片文件的完整路径
                            string _filePath = Path.Combine(Path.GetDirectoryName(_cssFilePath) + "/" + _urlPath);

                            //图片文件的信息
                            FileInfo _fileInfo = new FileInfo(_filePath);

                            //如果有文件
                            if (_fileInfo.Exists == true)
                            {
                                //如果要转换为base64，并且大小小于我们的限制
                                if (_configData.css.isOtherFileConvertBase64 == true && _fileInfo.Length <= _configData.css.base64ConvertLimit)
                                {
                                    //读取这个图片
                                    byte[] _fileByte = File.ReadAllBytes(_filePath);

                                    //把这个图片，转换成base64
                                    string _fileBase64 = Convert.ToBase64String(_fileByte, Base64FormattingOptions.None);

                                    //获取这个图片的Mime类型
                                    string _fileMimeType = "data:" + AppManager.Systems.MimeSystem.GetFileMimeType(_fileInfo.Extension) + ";base64,";

                                    //修改css文件的中的图片路径
                                    _cssFileContent = _cssFileContent.Replace(_matchConllection[j].Value, "url(" + _fileMimeType + _fileBase64 + ");");
                                }

                                //如果不转换
                                else
                                {
                                    //如果图片的导出文件夹不存在，就创建
                                    if (Directory.Exists(_otherFileOutputPath) == false)
                                    {
                                        Directory.CreateDirectory(_otherFileOutputPath);
                                    }

                                    //复制这个图片
                                    File.Copy(_filePath, _otherFileOutputPath + Path.GetFileName(_filePath), true);

                                    //修改css文件的中的图片路径(导出的路径+图片的名字)
                                    _cssFileContent = _cssFileContent.Replace(_matchConllection[j].Value, "url(" + _configData.css.otherFileOutputPath + Path.GetFileName(_urlPath) + ");");
                                }
                            }

                        }

                    }


                    //把.js文件的内容,放到变量中
                    _cssContent += _cssFileContent;
                }

                //如果要去掉注释
                if (_configData.css.isDeleteCommentedOutCode == true)
                {
                    //正则表达式 (匹配所有/**/的注释)
                    _cssContent = Regex.Replace(_cssContent, @"/\*{1,2}[\s\S]*?\*/", "", RegexOptions.Multiline);

                    //去掉换行
                    _cssContent = Regex.Replace(_cssContent, @"^\s*\n", "", RegexOptions.Multiline);
                }



                /* 输出文件 */
                //输出的文件夹路径
                string _outputFilePath = Path.Combine(Path.GetDirectoryName(_configData.configFilePath) + "/" + _configData.css.outputPath);
                string _outputDirectoryPath = Path.GetDirectoryName(_outputFilePath);

                //如果文件夹不存在
                if (Directory.Exists(_outputDirectoryPath) != true)
                {
                    Directory.CreateDirectory(_outputDirectoryPath);
                }

                //导出打包好的文件
                File.WriteAllText(_outputFilePath, _cssContent);

            }

            /* 返回值 */
            return true;
        }

        /// <summary>
        /// 打包html文件
        /// </summary>
        /// <param name="_configData">配置文件</param>
        /// <returns>是否打包成功？</returns>
        private bool PackHtmlFile(ConfigData _configData)
        {
            //如果有html文件
            if (_configData.html.filePath!="")
            {
                /* 读取文件 */
                //这个html文件的路径
                string _htmlFilePath = Path.Combine(Path.GetDirectoryName(_configData.configFilePath) + "/" + _configData.html.filePath);

                //判断文件是否存在,如果不存在
                if (File.Exists(_htmlFilePath) == false)
                {
                    //报错
                    MessageBox.Show("打包html文件时出现错误:\n" + _configData.html.filePath + "文件不存在!", "[错误]", MessageBoxButton.OK, MessageBoxImage.Error);

                    //返回
                    return false;
                }

                //读取.html文件的内容
                string _htmlContent = File.ReadAllText(_htmlFilePath);

                //如果要去掉注释
                if (_configData.html.isDeleteCommentedOutCode == true)
                {
                    //正则表达式 (匹配所有//和/**/的注释)
                    _htmlContent = Regex.Replace(_htmlContent, @"<!-[\s\S]*?-->", "", RegexOptions.Multiline);

                    //去掉换行
                    _htmlContent = Regex.Replace(_htmlContent, @"^\s*\n", "", RegexOptions.Multiline);
                }


                /* 输出文件 */
                //输出的文件夹路径
                string _outputFilePath = Path.Combine(Path.GetDirectoryName(_configData.configFilePath) + "/" + _configData.html.outputPath);
                string _outputDirectoryPath = Path.GetDirectoryName(_outputFilePath);

                //如果文件夹不存在
                if (Directory.Exists(_outputDirectoryPath) == false)
                {
                    Directory.CreateDirectory(_outputDirectoryPath);
                }

                //导出打包好的文件
                File.WriteAllText(_outputFilePath, _htmlContent);

            }

            /* 返回值 */
            return true;
        }
        #endregion
    }
}
