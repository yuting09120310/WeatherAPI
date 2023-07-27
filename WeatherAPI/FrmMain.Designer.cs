namespace WeatherAPI
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Send = new Button();
            txt_result = new TextBox();
            btn_History = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // btn_Send
            // 
            btn_Send.Location = new Point(703, 30);
            btn_Send.Name = "btn_Send";
            btn_Send.Size = new Size(75, 23);
            btn_Send.TabIndex = 1;
            btn_Send.Text = "送出";
            btn_Send.UseVisualStyleBackColor = true;
            btn_Send.Click += btnSubmit_Click;
            // 
            // txt_result
            // 
            txt_result.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_result.Location = new Point(22, 72);
            txt_result.Multiline = true;
            txt_result.Name = "txt_result";
            txt_result.Size = new Size(756, 366);
            txt_result.TabIndex = 2;
            // 
            // btn_History
            // 
            btn_History.Location = new Point(703, 462);
            btn_History.Name = "btn_History";
            btn_History.Size = new Size(75, 23);
            btn_History.TabIndex = 3;
            btn_History.Text = "歷史紀錄";
            btn_History.UseVisualStyleBackColor = true;
            btn_History.Click += btn_History_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(22, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(675, 23);
            comboBox1.TabIndex = 4;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 497);
            Controls.Add(comboBox1);
            Controls.Add(btn_History);
            Controls.Add(txt_result);
            Controls.Add(btn_Send);
            Name = "FrmMain";
            Text = "Alex_Demo";
            Load += FrmMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_Send;
        private TextBox txt_result;
        private Button btn_History;
        private ComboBox comboBox1;
    }
}