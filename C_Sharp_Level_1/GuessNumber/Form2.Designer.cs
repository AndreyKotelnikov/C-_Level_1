namespace GuessNumber
{
    partial class Form2
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
            this.tbUserNumberValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbUserNumberValue
            // 
            this.tbUserNumberValue.Location = new System.Drawing.Point(22, 22);
            this.tbUserNumberValue.Margin = new System.Windows.Forms.Padding(6);
            this.tbUserNumberValue.Name = "tbUserNumberValue";
            this.tbUserNumberValue.Size = new System.Drawing.Size(214, 29);
            this.tbUserNumberValue.TabIndex = 0;
            this.tbUserNumberValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUserNumberValue_KeyPress);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 109);
            this.Controls.Add(this.tbUserNumberValue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Введите число:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUserNumberValue;
    }
}