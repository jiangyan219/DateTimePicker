/**************************************************************** 
* 作    者 ：姜  彦 
* 项目名称 ：Utility.Tool.Controls.View
* 控件名称 ：THourView 
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

namespace Utility.Tool.Controls.View
{
    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中 隐藏该窗体 20170804 姜彦
    /// <summary>
    /// THourGrid.xaml 的交互逻辑
    /// </summary>
    public partial class THourView : UserControl
    {
        public THourView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="txt"></param>
        public THourView(string txt)
            : this()
        {          
            this.formerHourStr = txt;
        }

        #region 全局变量

        /// <summary>
        /// 从 TDateTimeView 传入的 小时数据 字符串
        /// </summary>
        private string formerHourStr = string.Empty;

        #endregion

        #region  类

        /// <summary>
        /// 类：小时数据
        /// </summary>
        public class Hour
        {
            /// <summary>
            /// 第1列 小时数据
            /// </summary>
            public int Hour1 { get; set; }
            public int Hour2 { get; set; }
            public int Hour3 { get; set; }
            public int Hour4 { get; set; }
            public int Hour5 { get; set; }

            /// <summary>
            /// 第6列 小时数据
            /// </summary>
            public int Hour6 { get; set; }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="hour1"></param>
            /// <param name="hour2"></param>
            /// <param name="hour3"></param>
            /// <param name="hour4"></param>
            /// <param name="hour5"></param>
            /// <param name="hour6"></param>
            public Hour(int hour1, int hour2, int hour3, int hour4, int hour5, int hour6)
            {
                Hour1 = hour1;
                Hour2 = hour2;
                Hour3 = hour3;
                Hour4 = hour4;
                Hour5 = hour5;
                Hour6 = hour6;

            }

        }

        #endregion    

        #region 方法

        /// <summary>
        /// dgHour控件 绑定类Hour 加载初始化数据
        /// </summary>
        public void LoadHour()
        {
            Hour[] hour = new Hour[4];

            hour[0] = new Hour(0, 1, 2, 3, 4, 5);
            hour[1] = new Hour(6, 7, 8, 9, 10, 11);
            hour[2] = new Hour(12, 13, 14, 15, 16, 17);
            hour[3] = new Hour(18, 19, 20, 21, 22, 23);

            dgHour.Items.Clear();
            dgHour.ItemsSource = hour;

        }

        #endregion

        #region 事件

        /// <summary>
        /// THourView 窗体登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadHour();
        }

        /// <summary>
        /// dgHour控件 单元格点击（选择）事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgHour_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGridCellInfo cell = dgHour.CurrentCell;
            if (cell.Column == null)
            {
                return;
            }

            Hour hour = cell.Item as Hour;

           // string str = cell.Column.DisplayIndex.ToString();

            string str1 = string.Empty; ;
            switch (cell.Column.DisplayIndex)// 通过所在列 获取类Hour的坐标 确定具体的hour数据
            {
                case 0:
                    str1 = hour.Hour1.ToString();
                    break;

                case 1:
                    str1 = hour.Hour2.ToString();
                    break;

                case 2:
                    str1 = hour.Hour3.ToString();
                    break;

                case 3:
                    str1 = hour.Hour4.ToString();
                    break;

                case 4:
                    str1 = hour.Hour5.ToString();
                    break;

                case 5:
                    str1 = hour.Hour6.ToString();
                    break;

                default: break;
            }           

            str1 = str1.PadLeft(2, '0');
            OnHourClickContentEdit(str1);

        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBtnCloseView_Click(object sender, RoutedEventArgs e)
        {
            OnHourClickContentEdit(this.formerHourStr);
        }

        #endregion

        #region Action 交互
       
        /// <summary>
        /// 小时数据点击（确定）后 的传递事件
        /// </summary>
        public Action<string> HourClick;  
       
        /// <summary>
        /// 小时数据点击（确定）后 传递的时间内容
        /// </summary>
        /// <param name="hourstr"></param>
        protected void OnHourClickContentEdit(string hourstr)
        {
            if (HourClick != null)
                HourClick(hourstr);
        }       

        #endregion


        


       

       

    }
}
