namespace AssetsInterface
{
    partial class EditForm
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
            this.AssetTypeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AssetTypeCB
            // 
            this.AssetTypeCB.FormattingEnabled = true;
            this.AssetTypeCB.Items.AddRange(new object[] {
            "Актив банковского счёта",
            "Денежный актив",
            "Неденежный актив"});
            this.AssetTypeCB.Location = new System.Drawing.Point(23, 29);
            this.AssetTypeCB.Name = "AssetTypeCB";
            this.AssetTypeCB.Size = new System.Drawing.Size(175, 24);
            this.AssetTypeCB.TabIndex = 0;
            this.AssetTypeCB.SelectedValueChanged += new System.EventHandler(this.AssetTypeCB_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип актива";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(203, 30);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(164, 23);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 63);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AssetTypeCB);
            this.Name = "EditForm";
            this.Text = "Редактор актива";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AssetTypeCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveBtn;
    }
}