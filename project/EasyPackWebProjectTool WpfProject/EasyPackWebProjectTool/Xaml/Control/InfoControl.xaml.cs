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
    /// InfoControl.xaml 的交互逻辑
    /// </summary>
    public partial class InfoControl : UserControl
    {
        /* 属性: Title(标题)
                 Content(内容)

           事件: 无*/


        public InfoControl()
        {
            InitializeComponent();
        }





        #region 依赖项属性：Title
        /// <summary>
        /// 依赖项属性：标题
        /// </summary>
        public static DependencyProperty TitleProperty;

        /// <summary>
        /// 公开属性：标题
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当TitleProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnTitleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion

        #region 依赖项属性：Content
        /// <summary>
        /// 依赖项属性：标题
        /// </summary>
        public static DependencyProperty ContentProperty;

        /// <summary>
        /// 公开属性：标题
        /// </summary>
        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当ContentProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnContentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion



        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static InfoControl()
        {
            /*注册依赖项属性*/
            //注册TitleProperty
            TitleProperty = DependencyProperty.Register(
                "Title", //属性的名字
                typeof(string), //属性的类型
                typeof(InfoControl), //这个属性属于哪个控件？
                new FrameworkPropertyMetadata( //属性的初始值和回调函数
                                               //初始值
                    "",
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnTitleChanged))
            );

            //注册ContentProperty
            ContentProperty = DependencyProperty.Register(
                "Content", typeof(string), typeof(InfoControl),
                new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnContentChanged)));





            /*注册路由事件*/
            //注册ClickEvent
            //ClickEvent = System.Windows.EventManager.RegisterRoutedEvent(
            //    "Click", //事件的名字
            //    RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
            //    typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
            //    typeof(ColorButtonControl) //这个路由事件属于哪个控件？
            //);

        }
        #endregion
    }
}
