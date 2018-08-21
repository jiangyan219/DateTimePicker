/**************************************************************** 
* 作    者 ：姜  彦 
* 项目名称 ：Utility.Tool.Controls.View
* 控件名称 ：TMinSexView 
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
    /// TMinSexView.xaml 的交互逻辑
    /// </summary>
    public partial class TMinSexView : UserControl
    {
        public TMinSexView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="txt"></param>
        public TMinSexView(string txt)
            : this()
        {           
            this.formerMinStr = txt;
        }

        #region 全局变量

        /// <summary>
        /// 从 TDateTimeView 传入的 分钟数据 字符串
        /// </summary>
        public  string formerMinStr = string.Empty;

        #endregion

        #region 类

        /// <summary>
        /// 类：分钟数据
        /// </summary>
        public class Min
        {
            public int C0 { get; set; }
            public int C1 { get; set; }
            public int C2 { get; set; }
            public int C3 { get; set; }
            public int C4 { get; set; }
            public int C5 { get; set; }
            public int C6 { get; set; }
            public int C7 { get; set; }
            public int C8 { get; set; }
            public int C9 { get; set; }




            public Min(int c0, int c1, int c2, int c3, int c4, int c5, int c6, int c7, int c8, int c9)
            {
                 C0 = c0;
                 C1 = c1;
                 C2 = c2;
                 C3 = c3;
                 C4 = c4;
                 C5 = c5;
                 C6 = c6;
                 C7 = c7;
                 C8 = c8;
                 C9 = c9;


            }

        }

        #endregion

        #region 方法

        /// <summary>
        /// dgMinSex控件 绑定类Min 加载初始化数据 
        /// </summary>
        public void LoadMin()
        {
            Min[] min = new Min[6];

            min[0] = new Min(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            min[1] = new Min(10, 11, 12, 13, 14, 15, 16, 17, 18, 19);
            min[2] = new Min(20, 21, 22, 23, 24, 25, 26, 27, 28, 29);
            min[3] = new Min(30, 31, 32, 33, 34, 35, 36, 37, 38, 39);
            min[4] = new Min(40, 41, 42, 43, 44, 45, 46, 47, 48, 49);
            min[5] = new Min(50, 51, 52, 53, 54, 55, 56, 57, 58, 59);

            dgMinSex.Items.Clear();
            dgMinSex.ItemsSource = min;

        }

        #endregion

        #region 事件

        /// <summary>
        /// TMinSexView 窗体登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMin();
        }

        /// <summary>
        /// dgMinSex控件 单元格点击（选择）事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgMinSex_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            DataGridCellInfo cell = dgMinSex.CurrentCell;
            if (cell.Column == null)
            {
                return;
            }

            Min min = cell.Item as Min;

            //string str = cell.Column.DisplayIndex.ToString();

            string str1 = string.Empty; ;
            switch (cell.Column.DisplayIndex)// 通过所在列 获取类Min的坐标 确定具体的min数据
            {
                case 0:
                    str1 = min.C0.ToString();
                    break;

                case 1:
                    str1 = min.C1.ToString();
                    break;

                case 2:
                    str1 = min.C2.ToString();
                    break;

                case 3:
                    str1 = min.C3.ToString();
                    break;

                case 4:
                    str1 = min.C4.ToString();
                    break;

                case 5:
                    str1 = min.C5.ToString();
                    break;

                case 6:
                    str1 = min.C6.ToString();
                    break;

                case 7:
                    str1 = min.C7.ToString();
                    break;

                case 8:
                    str1 = min.C8.ToString();
                    break;

                case 9:
                    str1 = min.C9.ToString();
                    break;

                default: break;

            }

            str1 = str1.PadLeft(2, '0');
            OnMinClickContent(str1);
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBtnCloseView_Click(object sender, RoutedEventArgs e)
        {
            OnMinClickContent(this.formerMinStr);
        }

        #endregion

        #region Action 交互

        /// <summary>
        /// 分钟数据点击（确定）后 的传递事件
        /// </summary>
        public Action<string> MinClick;

        /// <summary>
        /// 分钟数据点击（确定）后 传递的时间内容
        /// </summary>
        /// <param name="minStr"></param>
        protected void OnMinClickContent(string minStr)
        {
            if (MinClick != null)
                MinClick(minStr);
        }

        #endregion


       

        



    }
}
