namespace WeatherAPI
{
    partial class FrmList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lst_History = new ListBox();
            txt_Result = new TextBox();
            cmb_Date = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lst_History
            // 
            lst_History.FormattingEnabled = true;
            lst_History.ItemHeight = 15;
            lst_History.Location = new Point(12, 42);
            lst_History.Name = "lst_History";
            lst_History.Size = new Size(185, 394);
            lst_History.TabIndex = 0;
            lst_History.SelectedIndexChanged += lst_History_SelectedIndexChanged;
            // 
            // txt_Result
            // 
            txt_Result.Location = new Point(222, 42);
            txt_Result.Multiline = true;
            txt_Result.Name = "txt_Result";
            txt_Result.Size = new Size(466, 394);
            txt_Result.TabIndex = 1;
            // 
            // cmb_Date
            // 
            cmb_Date.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Date.FormattingEnabled = true;
            cmb_Date.Location = new Point(58, 8);
            cmb_Date.Name = "cmb_Date";
            cmb_Date.Size = new Size(630, 23);
            cmb_Date.TabIndex = 2;
            cmb_Date.SelectedIndexChanged += cmb_Date_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 3;
            label1.Text = "時間 : ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 448);
            Controls.Add(label1);
            Controls.Add(cmb_Date);
            Controls.Add(txt_Result);
            Controls.Add(lst_History);
            Name = "FrmList";
            Text = "FrmList";
            Load += FrmList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lst_History;
        private TextBox txt_Result;
        private ComboBox cmb_Date;
        private Label label1;
    }
}