namespace AssetsInterface
{
    partial class CommonFieldControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameTB = new System.Windows.Forms.TextBox();
            this.ValueTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(3, 3);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(175, 22);
            this.NameTB.TabIndex = 0;
            this.NameTB.TextChanged += new System.EventHandler(this.NameTB_TextChanged);
            // 
            // ValueTB
            // 
            this.ValueTB.Location = new System.Drawing.Point(184, 3);
            this.ValueTB.Name = "ValueTB";
            this.ValueTB.Size = new System.Drawing.Size(160, 22);
            this.ValueTB.TabIndex = 1;
            this.ValueTB.TextChanged += new System.EventHandler(this.ValueTB_TextChanged);
            // 
            // CommonFieldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueTB);
            this.Controls.Add(this.NameTB);
            this.Name = "CommonFieldControl";
            this.Size = new System.Drawing.Size(350, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox ValueTB;
    }
}
