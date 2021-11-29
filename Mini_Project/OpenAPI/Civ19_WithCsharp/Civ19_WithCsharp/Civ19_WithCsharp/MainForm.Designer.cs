﻿namespace Civ19_WithCsharp
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
            this.Top_Bar = new System.Windows.Forms.Panel();
            this.lb_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnMinmon = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Main_Content = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.Week_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Btn_Search = new FontAwesome.Sharp.IconButton();
            this.Top_Bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Main_Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Week_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Top_Bar
            // 
            this.Top_Bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.Top_Bar.Controls.Add(this.lb_Title);
            this.Top_Bar.Controls.Add(this.pictureBox1);
            this.Top_Bar.Controls.Add(this.BtnMinmon);
            this.Top_Bar.Controls.Add(this.BtnClose);
            this.Top_Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Bar.Location = new System.Drawing.Point(0, 0);
            this.Top_Bar.Name = "Top_Bar";
            this.Top_Bar.Padding = new System.Windows.Forms.Padding(5);
            this.Top_Bar.Size = new System.Drawing.Size(800, 40);
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
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Civ19_WithCsharp.Properties.Resources.Daelim_Symbol;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BtnMinmon
            // 
            this.BtnMinmon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinmon.Image = global::Civ19_WithCsharp.Properties.Resources.minimize;
            this.BtnMinmon.Location = new System.Drawing.Point(729, 5);
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
            this.BtnClose.Location = new System.Drawing.Point(765, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(30, 30);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // Main_Content
            // 
            this.Main_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            this.Main_Content.Controls.Add(this.iconButton1);
            this.Main_Content.Controls.Add(this.Week_chart);
            this.Main_Content.Controls.Add(this.Btn_Search);
            this.Main_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Content.Location = new System.Drawing.Point(0, 40);
            this.Main_Content.Name = "Main_Content";
            this.Main_Content.Padding = new System.Windows.Forms.Padding(5);
            this.Main_Content.Size = new System.Drawing.Size(800, 385);
            this.Main_Content.TabIndex = 1;
            // 
            // iconButton1
            // 
            this.iconButton1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.iconButton1.Location = new System.Drawing.Point(547, 335);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(117, 45);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "기간고르기";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // Week_chart
            // 
            this.Week_chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            this.Week_chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            this.Week_chart.BorderSkin.BackColor = System.Drawing.Color.Empty;
            chartArea1.Name = "ChartArea1";
            this.Week_chart.ChartAreas.Add(chartArea1);
            this.Week_chart.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.Week_chart.Legends.Add(legend1);
            this.Week_chart.Location = new System.Drawing.Point(5, 5);
            this.Week_chart.Name = "Week_chart";
            this.Week_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            series1.IsXValueIndexed = true;
            series1.LabelForeColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.Name = "확진자";
            series1.ShadowColor = System.Drawing.Color.Empty;
            this.Week_chart.Series.Add(series1);
            this.Week_chart.Size = new System.Drawing.Size(790, 324);
            this.Week_chart.TabIndex = 1;
            this.Week_chart.Visible = false;
            // 
            // Btn_Search
            // 
            this.Btn_Search.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Search.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.Btn_Search.IconColor = System.Drawing.Color.Black;
            this.Btn_Search.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_Search.IconSize = 30;
            this.Btn_Search.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Btn_Search.Location = new System.Drawing.Point(678, 335);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(117, 45);
            this.Btn_Search.TabIndex = 0;
            this.Btn_Search.Text = "불러오기";
            this.Btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Search.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 425);
            this.Controls.Add(this.Main_Content);
            this.Controls.Add(this.Top_Bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Top_Bar.ResumeLayout(false);
            this.Top_Bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Main_Content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Week_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Top_Bar;
        private System.Windows.Forms.Button BtnMinmon;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel Main_Content;
        private System.Windows.Forms.DataVisualization.Charting.Chart Week_chart;
        private FontAwesome.Sharp.IconButton Btn_Search;
        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}

