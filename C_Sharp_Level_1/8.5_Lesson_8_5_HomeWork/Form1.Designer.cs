namespace _8._5_Lesson_8_5_HomeWork
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
            this.btnOpenCSV = new System.Windows.Forms.Button();
            this.btnOpenXML = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenCSV
            // 
            this.btnOpenCSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenCSV.Location = new System.Drawing.Point(0, 0);
            this.btnOpenCSV.Name = "btnOpenCSV";
            this.btnOpenCSV.Size = new System.Drawing.Size(403, 69);
            this.btnOpenCSV.TabIndex = 0;
            this.btnOpenCSV.Text = "Выбрать файл CSV";
            this.btnOpenCSV.UseVisualStyleBackColor = true;
            this.btnOpenCSV.Click += new System.EventHandler(this.btnOpenCSV_Click);
            // 
            // btnOpenXML
            // 
            this.btnOpenXML.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOpenXML.Location = new System.Drawing.Point(0, 142);
            this.btnOpenXML.Name = "btnOpenXML";
            this.btnOpenXML.Size = new System.Drawing.Size(403, 76);
            this.btnOpenXML.TabIndex = 1;
            this.btnOpenXML.Text = "Открыть файл XML в блокноте";
            this.btnOpenXML.UseVisualStyleBackColor = true;
            this.btnOpenXML.Click += new System.EventHandler(this.btnOpenXML_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.Location = new System.Drawing.Point(0, 69);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(403, 73);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Конвертировать";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 218);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnOpenXML);
            this.Controls.Add(this.btnOpenCSV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convertor CSV to XML for Students";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenCSV;
        private System.Windows.Forms.Button btnOpenXML;
        private System.Windows.Forms.Button btnConvert;
    }
}

