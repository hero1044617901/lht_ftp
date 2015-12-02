using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListViewEx
{
    public partial class ListViewEx : ListView
    {
        /// <summary>  
        /// 进度条列索引  
        /// </summary>  
        private int _progressColumnIndex = -1;
        public int ProgressColumnIndex
        {
            get
            {
                return _progressColumnIndex;
            }
            set
            {
                _progressColumnIndex = value;
            }
        }
        public delegate void MyDelegate();
        [Browsable(true)]
        [Category("自定义")]
        public event MyDelegate OnTest;
        /// <summary>  
        /// 进度条最大值  
        /// </summary>  
        private int _progressMaximun = 100;
        public int ProgressMaximun
        {
            get
            {
                return _progressMaximun;
            }
        }

        private Color _processTextColor = Color.Black;
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        [Category("自定义")]
        public Color ProcessTextColor
        {
            get { return _processTextColor; }
            set { _processTextColor = value; }
        }

        private Color _processEdgeColor = Color.Blue;
        [Browsable(true), DefaultValue(typeof(Color), "Blue")]
        [Category("自定义")]
        public Color ProcessEdgeColor
        {
            get { return _processEdgeColor; }
            set { _processEdgeColor = value; }
        }

        private Color _processColor = Color.Green;
        [Browsable(true), DefaultValue(typeof(Color), "Green")]
        [Category("自定义")]
        public Color ProcessColor
        {
            get { return _processColor; }
            set { _processColor = value; }
        }

        public ListViewEx()
        {
            InitializeComponent();
            this.View = System.Windows.Forms.View.Details;
            base.OwnerDraw = true;
        }

        public ListViewEx(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawColumnHeader(e);
        }


        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == ProgressColumnIndex)
            {
                var item = e.Item.SubItems[e.ColumnIndex];
                var rect = item.Bounds;

                //绘制进度条  
                var g = e.Graphics;
                var progressRect = new Rectangle(rect.X + 1, rect.Y + 3, rect.Width - 2, rect.Height - 5);
                g.DrawRectangle(new Pen(new SolidBrush(_processEdgeColor), 1), progressRect);

                //绘制进度  
                var progressMaxWidth = progressRect.Width - 1;
                var unit = (progressMaxWidth * 1.0) / (_progressMaximun * 100);
                var fValue = float.Parse(item.Text);
                var percent = fValue * unit * 100;
                if (percent >= progressMaxWidth) percent = progressMaxWidth;
                g.FillRectangle(new SolidBrush(_processColor), new RectangleF(progressRect.X + 1, progressRect.Y + 1, float.Parse(percent.ToString()), progressRect.Height - 1));

                //绘制进度百分比  
                percent = fValue;
                var percentText = string.Format("{0}% ...", percent);
                if (fValue >= _progressMaximun) percentText = "已完成";
                var size = TextRenderer.MeasureText(percentText.ToString(), Font);
                var x = rect.X + (progressRect.Width - size.Width) / 2.0;
                var y = rect.Y + (progressRect.Height - size.Height) / 2.0 + 3;
                g.DrawString(percentText, this.Font, new SolidBrush(_processTextColor), float.Parse(x.ToString()), float.Parse(y.ToString()));
            }
            else
            {
                e.DrawDefault = true;
            }
            base.OnDrawSubItem(e);
        }

        public void SetProgress(int itemIndex, int value)
        {
            var columnWidth = this.Columns[ProgressColumnIndex].Width;
            var progressSubItem = this.Items[itemIndex].SubItems[ProgressColumnIndex];
            progressSubItem.Text = value.ToString();
        } 
    }
}
