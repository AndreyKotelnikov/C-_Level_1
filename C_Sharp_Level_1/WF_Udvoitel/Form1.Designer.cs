namespace WF_Udvoitel
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
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblComandCounter = new System.Windows.Forms.Label();
            this.lblComandCounterValue = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumberTitle = new System.Windows.Forms.Label();
            this.lblNumberForPlay = new System.Windows.Forms.Label();
            this.lblNumberForPlayValue = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCommand1
            // 
            this.btnCommand1.Location = new System.Drawing.Point(242, 31);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(75, 23);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "+1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Location = new System.Drawing.Point(242, 86);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(75, 23);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "x2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(242, 148);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(91, 86);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(13, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "0";
            // 
            // lblComandCounter
            // 
            this.lblComandCounter.Location = new System.Drawing.Point(0, 175);
            this.lblComandCounter.Name = "lblComandCounter";
            this.lblComandCounter.Size = new System.Drawing.Size(104, 13);
            this.lblComandCounter.TabIndex = 4;
            this.lblComandCounter.Text = "Счётчик команд:";
            this.lblComandCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblComandCounterValue
            // 
            this.lblComandCounterValue.AutoSize = true;
            this.lblComandCounterValue.Location = new System.Drawing.Point(103, 175);
            this.lblComandCounterValue.Name = "lblComandCounterValue";
            this.lblComandCounterValue.Size = new System.Drawing.Size(13, 13);
            this.lblComandCounterValue.TabIndex = 5;
            this.lblComandCounterValue.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(347, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemPlay});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(53, 20);
            this.Menu.Text = "Меню";
            // 
            // MenuItemPlay
            // 
            this.MenuItemPlay.Name = "MenuItemPlay";
            this.MenuItemPlay.Size = new System.Drawing.Size(112, 22);
            this.MenuItemPlay.Text = "Играть";
            this.MenuItemPlay.Click += new System.EventHandler(this.MenuItemPlay_Click);
            // 
            // lblNumberTitle
            // 
            this.lblNumberTitle.AutoSize = true;
            this.lblNumberTitle.Location = new System.Drawing.Point(16, 86);
            this.lblNumberTitle.Name = "lblNumberTitle";
            this.lblNumberTitle.Size = new System.Drawing.Size(69, 13);
            this.lblNumberTitle.TabIndex = 7;
            this.lblNumberTitle.Text = "Ваше число:";
            // 
            // lblNumberForPlay
            // 
            this.lblNumberForPlay.AutoSize = true;
            this.lblNumberForPlay.Location = new System.Drawing.Point(13, 28);
            this.lblNumberForPlay.Name = "lblNumberForPlay";
            this.lblNumberForPlay.Size = new System.Drawing.Size(102, 13);
            this.lblNumberForPlay.TabIndex = 8;
            this.lblNumberForPlay.Text = "Загаданное число:";
            this.lblNumberForPlay.Visible = false;
            // 
            // lblNumberForPlayValue
            // 
            this.lblNumberForPlayValue.AutoSize = true;
            this.lblNumberForPlayValue.Location = new System.Drawing.Point(122, 28);
            this.lblNumberForPlayValue.Name = "lblNumberForPlayValue";
            this.lblNumberForPlayValue.Size = new System.Drawing.Size(0, 13);
            this.lblNumberForPlayValue.TabIndex = 9;
            this.lblNumberForPlayValue.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 197);
            this.Controls.Add(this.lblNumberForPlayValue);
            this.Controls.Add(this.lblNumberForPlay);
            this.Controls.Add(this.lblNumberTitle);
            this.Controls.Add(this.lblComandCounterValue);
            this.Controls.Add(this.lblComandCounter);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Удвоитель";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblComandCounter;
        private System.Windows.Forms.Label lblComandCounterValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPlay;
        private System.Windows.Forms.Label lblNumberTitle;
        private System.Windows.Forms.Label lblNumberForPlay;
        private System.Windows.Forms.Label lblNumberForPlayValue;
    }
}

