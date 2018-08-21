/**************************************************************** 
* 作    者 ：姜  彦 
* 项目名称 ：Utility.Tool.Controls.View
* 控件名称 ：IconButton 
* 命名空间 ：Utility.Tool.Controls.View
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2017/8/4 9:10:14 
* 当前版本 ：1.0.0.1 
* My  Email：771078740@qq.com 
* 描述说明： 
* 
* 修改历史： 
* 
****************************************************************
* Copyright @ JiangYan 2018 All rights reserved 
****************************************************************/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Utility.Tool.Controls.View
{

    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中 隐藏该窗体 20170804 姜彦
    public partial class IconButton : UserControl
    {
        public IconButton()
        {
            InitializeComponent();

            this.button.Click += delegate
            {
                RoutedEventArgs newEvent = new RoutedEventArgs(IconButton.ClickEvent, this);
                this.RaiseEvent(newEvent);
            };
        }

        #region 图标
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon",
            typeof(string),
            typeof(IconButton),
            new PropertyMetadata(string.Empty, OnIconChanged));
        public string Icon
        {
            set { SetValue(IconProperty, value); }
            get { return (string)GetValue(IconProperty); }
        }
        private static void OnIconChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            IconButton btn = obj as IconButton;
            if (btn == null)
            {
                return;
            }
            btn.icon.Source = new BitmapImage(new Uri((string)args.NewValue, UriKind.Relative));
        }
        #endregion

        #region 命令

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command",
            typeof(ICommand),
            typeof(IconButton),
            new PropertyMetadata(null, OnSelectCommandChanged));
        public ICommand Command
        {
            set { SetValue(CommandProperty, value); }
            get { return (ICommand)GetValue(CommandProperty); }
        }
        private static void OnSelectCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            IconButton btn = obj as IconButton;
            if (btn == null)
            {
                return;
            }
            btn.button.Command = (ICommand)args.NewValue;
        }

        #endregion

        #region 点击事件
        public static readonly RoutedEvent ClickEvent =
          EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
          typeof(RoutedEventHandler), typeof(IconButton));

        public event RoutedEventHandler Click
        {
            add
            {
                base.AddHandler(ClickEvent, value);
            }
            remove
            {
                base.RemoveHandler(ClickEvent, value);
            }

        }
        #endregion
        
    }
}
