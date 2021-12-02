namespace Civ19_WithCsharp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Top_Bar = new System.Windows.Forms.Panel();
            this.lb_Title = new System.Windows.Forms.Label();
            this.Pic_Title = new System.Windows.Forms.PictureBox();
            this.BtnMinmon = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Main_Content = new System.Windows.Forms.Panel();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_EndDate = new System.Windows.Forms.Label();
            this.lb_StartDate = new System.Windows.Forms.Label();
            this.lb_tilde = new System.Windows.Forms.Label();
            this.bothidden = new System.Windows.Forms.Panel();
            this.tophidden = new System.Windows.Forms.Panel();
            this.tb_Term = new System.Windows.Forms.TrackBar();
            this.Week_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Btn_Search = new FontAwesome.Sharp.IconButton();
            this.Top_Bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Title)).BeginInit();
            this.Main_Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Term)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Week_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Top_Bar
            // 
            this.Top_Bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.Top_Bar.Controls.Add(this.lb_Title);
            this.Top_Bar.Controls.Add(this.Pic_Title);
            this.Top_Bar.Controls.Add(this.BtnMinmon);
            this.Top_Bar.Controls.Add(this.BtnClose);
            this.Top_Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Bar.Location = new System.Drawing.Point(0, 0);
            this.Top_Bar.Name = "Top_Bar";
            this.Top_Bar.Padding = new System.Windows.Forms.Padding(5);
            this.Top_Bar.Size = new System.Drawing.Size(776, 40);
            this.Top_Bar.TabIndex = 0;
            // 
            // lb_Title
            // 
            this.lb_Title.AutoSize = true;
            this.lb_Title.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Title.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lb_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.lb_Title.Location = new System.Drawing.Point(35, 5);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(595, 28);
            this.lb_Title.TabIndex = 2;
            this.lb_Title.Text = "문제 해결을 위한 C# 프로그램 기획하기 - 코로나 확진자 수 파악";
            // 
            // Pic_Title
            // 
            this.Pic_Title.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pic_Title.Image = global::Civ19_WithCsharp.Properties.Resources.Daelim_Symbol;
            this.Pic_Title.InitialImage = null;
            this.Pic_Title.Location = new System.Drawing.Point(5, 5);
            this.Pic_Title.Name = "Pic_Title";
            this.Pic_Title.Size = new System.Drawing.Size(30, 30);
            this.Pic_Title.TabIndex = 2;
            this.Pic_Title.TabStop = false;
            // 
            // BtnMinmon
            // 
            this.BtnMinmon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinmon.Image = global::Civ19_WithCsharp.Properties.Resources.minimize;
            this.BtnMinmon.Location = new System.Drawing.Point(705, 5);
            this.BtnMinmon.Name = "BtnMinmon";
            this.BtnMinmon.Size = new System.Drawing.Size(30, 30);
            this.BtnMinmon.TabIndex = 1;
            this.BtnMinmon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMinmon.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.Image = global::Civ19_WithCsharp.Properties.Resources.Close;
            this.BtnClose.Location = new System.Drawing.Point(741, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(30, 30);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // Main_Content
            // 
            this.Main_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            this.Main_Content.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Main_Content.Controls.Add(this.lb_date);
            this.Main_Content.Controls.Add(this.lb_EndDate);
            this.Main_Content.Controls.Add(this.lb_StartDate);
            this.Main_Content.Controls.Add(this.lb_tilde);
            this.Main_Content.Controls.Add(this.bothidden);
            this.Main_Content.Controls.Add(this.tophidden);
            this.Main_Content.Controls.Add(this.tb_Term);
            this.Main_Content.Controls.Add(this.Week_chart);
            this.Main_Content.Controls.Add(this.Btn_Search);
            this.Main_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Content.Location = new System.Drawing.Point(0, 40);
            this.Main_Content.Name = "Main_Content";
            this.Main_Content.Padding = new System.Windows.Forms.Padding(5);
            this.Main_Content.Size = new System.Drawing.Size(776, 428);
            this.Main_Content.TabIndex = 1;
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.BackColor = System.Drawing.Color.Transparent;
            this.lb_date.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.lb_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.lb_date.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lb_date.Location = new System.Drawing.Point(607, 354);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(46, 25);
            this.lb_date.TabIndex = 8;
            this.lb_date.Text = " 7일";
            this.lb_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_EndDate
            // 
            this.lb_EndDate.AutoSize = true;
            this.lb_EndDate.BackColor = System.Drawing.Color.Transparent;
            this.lb_EndDate.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lb_EndDate.ForeColor = System.Drawing.Color.White;
            this.lb_EndDate.Location = new System.Drawing.Point(502, 361);
            this.lb_EndDate.Name = "lb_EndDate";
            this.lb_EndDate.Size = new System.Drawing.Size(93, 20);
            this.lb_EndDate.TabIndex = 4;
            this.lb_EndDate.Text = "0000-00-00";
            // 
            // lb_StartDate
            // 
            this.lb_StartDate.AutoSize = true;
            this.lb_StartDate.BackColor = System.Drawing.Color.Transparent;
            this.lb_StartDate.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lb_StartDate.ForeColor = System.Drawing.Color.White;
            this.lb_StartDate.Location = new System.Drawing.Point(392, 361);
            this.lb_StartDate.Name = "lb_StartDate";
            this.lb_StartDate.Size = new System.Drawing.Size(93, 20);
            this.lb_StartDate.TabIndex = 3;
            this.lb_StartDate.Text = "0000-00-00";
            // 
            // lb_tilde
            // 
            this.lb_tilde.AutoSize = true;
            this.lb_tilde.BackColor = System.Drawing.Color.Transparent;
            this.lb_tilde.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lb_tilde.ForeColor = System.Drawing.Color.White;
            this.lb_tilde.Location = new System.Drawing.Point(468, 361);
            this.lb_tilde.Name = "lb_tilde";
            this.lb_tilde.Size = new System.Drawing.Size(50, 20);
            this.lb_tilde.TabIndex = 5;
            this.lb_tilde.Text = "   ~   ";
            // 
            // bothidden
            // 
            this.bothidden.Location = new System.Drawing.Point(377, 406);
            this.bothidden.Name = "bothidden";
            this.bothidden.Size = new System.Drawing.Size(282, 10);
            this.bothidden.TabIndex = 7;
            // 
            // tophidden
            // 
            this.tophidden.Location = new System.Drawing.Point(377, 375);
            this.tophidden.Name = "tophidden";
            this.tophidden.Size = new System.Drawing.Size(282, 10);
            this.tophidden.TabIndex = 6;
            // 
            // tb_Term
            // 
            this.tb_Term.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.tb_Term.LargeChange = 1;
            this.tb_Term.Location = new System.Drawing.Point(377, 375);
            this.tb_Term.Maximum = 30;
            this.tb_Term.Minimum = 1;
            this.tb_Term.Name = "tb_Term";
            this.tb_Term.RightToLeftLayout = true;
            this.tb_Term.Size = new System.Drawing.Size(282, 45);
            this.tb_Term.TabIndex = 1;
            this.tb_Term.TickFrequency = 7;
            this.tb_Term.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tb_Term.Value = 10;
            // 
            // Week_chart
            // 
            this.Week_chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Week_chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            this.Week_chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            this.Week_chart.BorderlineWidth = 0;
            this.Week_chart.BorderSkin.BackColor = System.Drawing.Color.Empty;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("맑은 고딕", 10F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.Size = 2F;
            chartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("맑은 고딕", 10F);
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("맑은 고딕", 10F);
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            chartArea1.BorderColor = System.Drawing.Color.Empty;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.CursorY.AxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chartArea1.Name = "ChartArea1";
            this.Week_chart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.Title = "코로나 확진자 수";
            this.Week_chart.Legends.Add(legend1);
            this.Week_chart.Location = new System.Drawing.Point(5, 5);
            this.Week_chart.Name = "Week_chart";
            this.Week_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelForeColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.Name = "확진자";
            series1.ShadowColor = System.Drawing.Color.Empty;
            series1.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.DodgerBlue;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.Week_chart.Series.Add(series1);
            this.Week_chart.Size = new System.Drawing.Size(766, 338);
            this.Week_chart.TabIndex = 1;
            this.Week_chart.Visible = false;
            // 
            // Btn_Search
            // 
            this.Btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Search.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Search.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.Btn_Search.IconColor = System.Drawing.Color.Black;
            this.Btn_Search.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_Search.IconSize = 30;
            this.Btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Search.Location = new System.Drawing.Point(665, 349);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(106, 67);
            this.Btn_Search.TabIndex = 0;
            this.Btn_Search.Text = "불러오기";
            this.Btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Search.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(776, 468);
            this.ControlBox = false;
            this.Controls.Add(this.Main_Content);
            this.Controls.Add(this.Top_Bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(778, 441);
            this.Name = "MainForm";
            this.Top_Bar.ResumeLayout(false);
            this.Top_Bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Title)).EndInit();
            this.Main_Content.ResumeLayout(false);
            this.Main_Content.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Term)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Week_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel Top_Bar;
        public System.Windows.Forms.Button BtnMinmon;
        public System.Windows.Forms.Button BtnClose;
        public System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.Panel Main_Content;
        private System.Windows.Forms.DataVisualization.Charting.Chart Week_chart;
        private FontAwesome.Sharp.IconButton Btn_Search;
        private System.Windows.Forms.PictureBox Pic_Title;
        private System.Windows.Forms.TrackBar tb_Term;
        private System.Windows.Forms.Label lb_tilde;
        private System.Windows.Forms.Label lb_EndDate;
        private System.Windows.Forms.Label lb_StartDate;
        private System.Windows.Forms.Panel bothidden;
        private System.Windows.Forms.Panel tophidden;
        private System.Windows.Forms.Label lb_date;
    }
}

