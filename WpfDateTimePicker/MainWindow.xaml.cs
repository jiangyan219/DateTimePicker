/**************************************************************** 
* 作    者 ：姜  彦 
* 项目名称 ：WpfDateTimePicker
* 控件名称 ：MainWindow 
* 命名空间 ：WpfDateTimePicker
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2017/8/4 9:10:14 
* 当前版本 ：1.0.0.1 
* My  Email：771078740@qq.com ;jiangyan2008.521@gmail.com
* 描述说明： 
* 
* 修改历史： 
* 
****************************************************************
* Copyright @ JiangYan 2018 All rights reserved 
****************************************************************/
using System.Windows;

namespace WpfDateTimePicker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("所选择的日期时间是： " + dateTimePicker1.DateTime.ToString());
        }
    }
}
