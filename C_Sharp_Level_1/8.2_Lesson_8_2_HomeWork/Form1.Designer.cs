namespace _8._2_Lesson_8_2_HomeWork
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb1Value = new System.Windows.Forms.TextBox();
            this.nud1Value = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud1Value)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1Value
            // 
            this.tb1Value.Location = new System.Drawing.Point(13, 13);
            this.tb1Value.Name = "tb1Value";
            this.tb1Value.Size = new System.Drawing.Size(775, 20);
            this.tb1Value.TabIndex = 0;
            // 
            // nud1Value
            // 
            this.nud1Value.Location = new System.Drawing.Point(13, 94);
            this.nud1Value.Name = "nud1Value";
            this.nud1Value.Size = new System.Drawing.Size(120, 20);
            this.nud1Value.TabIndex = 1;
            this.nud1Value.ValueChanged += new System.EventHandler(this.nud1Value_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nud1Value);
            this.Controls.Add(this.tb1Value);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nud1Value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb1Value;
        private System.Windows.Forms.NumericUpDown nud1Value;
    }
}

