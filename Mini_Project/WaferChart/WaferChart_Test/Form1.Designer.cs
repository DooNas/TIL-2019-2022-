namespace WaferChart_Test
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bn_Start = new System.Windows.Forms.Button();
            this.pn_Wafer = new System.Windows.Forms.Panel();
            this.tm_Coating = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bn_Start
            // 
            this.bn_Start.Location = new System.Drawing.Point(100, 42);
            this.bn_Start.Name = "bn_Start";
            this.bn_Start.Size = new System.Drawing.Size(162, 48);
            this.bn_Start.TabIndex = 0;
            this.bn_Start.Text = "button1";
            this.bn_Start.UseVisualStyleBackColor = true;
            // 
            // pn_Wafer
            // 
            this.pn_Wafer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Wafer.Location = new System.Drawing.Point(80, 111);
            this.pn_Wafer.Name = "pn_Wafer";
            this.pn_Wafer.Size = new System.Drawing.Size(197, 197);
            this.pn_Wafer.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(343, 352);
            this.Controls.Add(this.pn_Wafer);
            this.Controls.Add(this.bn_Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bn_Start;
        private System.Windows.Forms.Panel pn_Wafer;
        private System.Windows.Forms.Timer tm_Coating;
    }
}

