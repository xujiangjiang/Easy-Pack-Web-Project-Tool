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
    /// PackUiControl.xaml 的交互逻辑
    /// </summary>
    public partial class PackUiControl : UserControl
    {

        /* 属性: 无
       
           事件: OnClickChooseFileButton(当点击[选择文件]按钮的时候)
                 OnClickOkButton(当点击[确认]按钮的时候)
                 OnClickIntroductionButton(当点击[介绍]按钮的时候)*/

        public PackUiControl()
        {
            InitializeComponent();
        }




        #region 路由事件：ClickChooseFileButton
        /// <summary>
        /// 路由事件：ClickChooseFileButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickChooseFileButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickChooseFileButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickChooseFileButton
        {
            //添加一条事件
            add { AddHandler(ClickChooseFileButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickChooseFileButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickChooseFileButton 路由事件
        /// </summary>
        private void OnClickChooseFileButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = PackUiControl.ClickChooseFileButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：ClickOkButton
        /// <summary>
        /// 路由事件：ClickOkButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickOkButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickOkButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickOkButton
        {
            //添加一条事件
            add { AddHandler(ClickOkButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickOkButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickOkButton 路由事件
        /// </summary>
        private void OnClickOkButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = PackUiControl.ClickOkButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：ClickIntroductionButton
        /// <summary>
        /// 路由事件：ClickIntroductionButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickIntroductionButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickIntroductionButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickIntroductionButton
        {
            //添加一条事件
            add { AddHandler(ClickIntroductionButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickIntroductionButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickIntroductionButton 路由事件
        /// </summary>
        private void OnClickIntroductionButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = PackUiControl.ClickIntroductionButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion



        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static PackUiControl()
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
            //注册ClickEvent
            ClickChooseFileButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickChooseFileButton", //事件的名字
                RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
                typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
                typeof(PackUiControl) //这个路由事件属于哪个控件？
            );

            //注册ClickEvent
            ClickOkButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickOkButton", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<bool>), typeof(PackUiControl)
            );

            //注册ClickEvent
            ClickIntroductionButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickIntroductionButton", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<bool>), typeof(PackUiControl)
            );

        }
        #endregion



        #region 事件 -[点击按钮]
        //当鼠标在[选择文件]按钮上按下的时候，触发此方法
        private void ChooseFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            //触发点击事件
            OnClickChooseFileButton();
        }

        //当鼠标在[确认]按钮上按下的时候，触发此方法
        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            //触发点击事件
            OnClickOkButton();
        }

        //当鼠标在[介绍]按钮上按下的时候，触发此方法
        private void IntroductionButton_OnClick(object sender, RoutedEventArgs e)
        {
            //触发点击事件
            OnClickIntroductionButton();
        }
        #endregion

    }
}
