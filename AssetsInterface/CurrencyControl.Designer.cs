namespace AssetsInterface
{
    partial class CurrencyControl
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
            this.ValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.FieldName = new System.Windows.Forms.Label();
            this.CurrencyCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ValueNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ValueNumeric
            // 
            this.ValueNumeric.Location = new System.Drawing.Point(3, 20);
            this.ValueNumeric.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ValueNumeric.Name = "ValueNumeric";
            this.ValueNumeric.Size = new System.Drawing.Size(175, 22);
            this.ValueNumeric.TabIndex = 0;
            // 
            // FieldName
            // 
            this.FieldName.AutoSize = true;
            this.FieldName.Location = new System.Drawing.Point(3, 0);
            this.FieldName.Name = "FieldName";
            this.FieldName.Size = new System.Drawing.Size(141, 17);
            this.FieldName.TabIndex = 1;
            this.FieldName.Text = "Валютное значение";
            // 
            // CurrencyCB
            // 
            this.CurrencyCB.FormattingEnabled = true;
            this.CurrencyCB.Location = new System.Drawing.Point(184, 18);
            this.CurrencyCB.Name = "CurrencyCB";
            this.CurrencyCB.Size = new System.Drawing.Size(160, 24);
            this.CurrencyCB.TabIndex = 2;
            // 
            // CurrencyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CurrencyCB);
            this.Controls.Add(this.FieldName);
            this.Controls.Add(this.ValueNumeric);
            this.Name = "CurrencyControl";
            this.Size = new System.Drawing.Size(350, 50);
            ((System.ComponentModel.ISupportInitialize)(this.ValueNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ValueNumeric;
        private System.Windows.Forms.Label FieldName;
        private System.Windows.Forms.ComboBox CurrencyCB;
    }
}
