using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyPackWebProjectTool
{
    /// <summary>
    /// LanguageUiControl.xaml 的交互逻辑
    /// </summary>
    public partial class LanguageUiControl : UserControl
    {

        /* 属性: 无

           事件: OnClickEnglishButton(当点击[英文]按钮的时候)
                 OnClickChineseButton(当点击[中文]按钮的时候)*/

        public LanguageUiControl()
        {
            InitializeComponent();
        }



        #region 路由事件：ClickEnglishButton
        /// <summary>
        /// 路由事件：ClickEnglishButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickEnglishButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickEnglishButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickEnglishButton
        {
            //添加一条事件
            add { AddHandler(ClickEnglishButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickEnglishButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickEnglishButton 路由事件
        /// </summary>
        private void OnClickEnglishButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = LanguageUiControl.ClickEnglishButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：ClickChineseButton
        /// <summary>
        /// 路由事件：ClickChineseButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickChineseButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickChineseButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickChineseButton
        {
            //添加一条事件
            add { AddHandler(ClickChineseButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickChineseButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickChineseButton 路由事件
        /// </summary>
        private void OnClickChineseButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = LanguageUiControl.ClickChineseButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion



        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static LanguageUiControl()
        {
            /*注册依赖项属性*/
            ////注册ConfigFilePathProperty
            //ConfigFilePathProperty = DependencyProperty.Register(
            //    "ConfigFilePath", //属性的名字
            //    typeof(string), //属性的类型
            //    typeof(PackUiControl), //这个属性属于哪个控件？
            //    new FrameworkPropertyMetadata( //属性的初始值和回调函数
            //        //初始值
            //        "",
            //        //当属性的值发生改变时，调用什么方法？
            //        new PropertyChangedCallback(OnConfigFilePathChanged))
            //);



            /*注册路由事件*/
            //注册ClickEnglishButtonEvent
            ClickEnglishButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickEnglishButton", //事件的名字
                RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
                typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
                typeof(LanguageUiControl) //这个路由事件属于哪个控件？
            );

            //注册ClickChineseButtonEvent
            ClickChineseButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickChineseButton", //事件的名字
                RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
                typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
                typeof(LanguageUiControl) //这个路由事件属于哪个控件？
            );

        }
        #endregion



        #region 事件 -[点击按钮]
        //当鼠标在[英文]按钮上按下的时候，触发此方法
        private void EnglishButton_OnClick(object sender, RoutedEventArgs e)
        {
            //触发点击事件
            OnClickEnglishButton();
        }

        //当鼠标在[中文]按钮上按下的时候，触发此方法
        private void ChineseButton_OnClick(object sender, RoutedEventArgs e)
        {
            //触发点击事件
            OnClickChineseButton();
        }
        #endregion

    }
}
