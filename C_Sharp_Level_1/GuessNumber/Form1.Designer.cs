namespace GuessNumber
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
            this.tbHello = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblNumberTitle = new System.Windows.Forms.Label();
            this.lblTryCount = new System.Windows.Forms.Label();
            this.lblTryCountValue = new System.Windows.Forms.Label();
            this.lblUserNumber = new System.Windows.Forms.Label();
            this.tbUserNumberValue = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.cbSeparateForm = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbHello
            // 
            this.tbHello.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbHello.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbHello.Enabled = false;
            this.tbHello.Location = new System.Drawing.Point(13, 13);
            this.tbHello.Multiline = true;
            this.tbHello.Name = "tbHello";
            this.tbHello.ReadOnly = true;
            this.tbHello.Size = new System.Drawing.Size(743, 81);
            this.tbHello.TabIndex = 0;
            this.tbHello.Text = "Добро пожаловать! \r\nПравила игры: Компьютер загадывает число от 1 до 100. \r\nИ Вам" +
    " нужно его угадать за минимальное число попыток.";
            this.tbHello.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(314, 100);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 36);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblNumberTitle
            // 
            this.lblNumberTitle.AutoSize = true;
            this.lblNumberTitle.Location = new System.Drawing.Point(13, 13);
            this.lblNumberTitle.Name = "lblNumberTitle";
            this.lblNumberTitle.Size = new System.Drawing.Size(325, 24);
            this.lblNumberTitle.TabIndex = 2;
            this.lblNumberTitle.Text = "Компьютер загадал число.  Какое?";
            this.lblNumberTitle.Visible = false;
            // 
            // lblTryCount
            // 
            this.lblTryCount.AutoSize = true;
            this.lblTryCount.Location = new System.Drawing.Point(13, 50);
            this.lblTryCount.Name = "lblTryCount";
            this.lblTryCount.Size = new System.Drawing.Size(203, 24);
            this.lblTryCount.TabIndex = 3;
            this.lblTryCount.Text = "Количество попыток:";
            this.lblTryCount.Visible = false;
            // 
            // lblTryCountValue
            // 
            this.lblTryCountValue.AutoSize = true;
            this.lblTryCountValue.Location = new System.Drawing.Point(222, 50);
            this.lblTryCountValue.Name = "lblTryCountValue";
            this.lblTryCountValue.Size = new System.Drawing.Size(0, 24);
            this.lblTryCountValue.TabIndex = 4;
            this.lblTryCountValue.Visible = false;
            // 
            // lblUserNumber
            // 
            this.lblUserNumber.AutoSize = true;
            this.lblUserNumber.Location = new System.Drawing.Point(189, 122);
            this.lblUserNumber.Name = "lblUserNumber";
            this.lblUserNumber.Size = new System.Drawing.Size(119, 24);
            this.lblUserNumber.TabIndex = 5;
            this.lblUserNumber.Text = "Ваше число:";
            this.lblUserNumber.Visible = false;
            // 
            // tbUserNumberValue
            // 
            this.tbUserNumberValue.Location = new System.Drawing.Point(314, 119);
            this.tbUserNumberValue.Name = "tbUserNumberValue";
            this.tbUserNumberValue.Size = new System.Drawing.Size(107, 29);
            this.tbUserNumberValue.TabIndex = 6;
            this.tbUserNumberValue.Visible = false;
            this.tbUserNumberValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUserNumberValue_KeyPress);
            // 
            // tbMessage
            // 
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbMessage.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tbMessage.Location = new System.Drawing.Point(34, 166);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(696, 22);
            this.tbMessage.TabIndex = 8;
            this.tbMessage.TabStop = false;
            this.tbMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMessage.Visible = false;
            // 
            // cbSeparateForm
            // 
            this.cbSeparateForm.AutoSize = true;
            this.cbSeparateForm.Location = new System.Drawing.Point(193, 184);
            this.cbSeparateForm.Name = "cbSeparateForm";
            this.cbSeparateForm.Size = new System.Drawing.Size(346, 28);
            this.cbSeparateForm.TabIndex = 9;
            this.cbSeparateForm.Text = "Вводить текст в отдельной форме";
            this.cbSeparateForm.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 314);
            this.Controls.Add(this.cbSeparateForm);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbUserNumberValue);
            this.Controls.Add(this.lblUserNumber);
            this.Controls.Add(this.lblTryCountValue);
            this.Controls.Add(this.lblTryCount);
            this.Controls.Add(this.lblNumberTitle);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbHello);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::GuessNumber.Properties.Settings.Default, "Loc1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Location = global::GuessNumber.Properties.Settings.Default.Loc1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угадай число";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHello;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblNumberTitle;
        private System.Windows.Forms.Label lblTryCount;
        private System.Windows.Forms.Label lblTryCountValue;
        private System.Windows.Forms.Label lblUserNumber;
        private System.Windows.Forms.TextBox tbUserNumberValue;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.CheckBox cbSeparateForm;
    }
}

