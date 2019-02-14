namespace Lesson7_WeatherApp
{
    partial class FormWeatheApp
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
            this.lbSites = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gbClient = new System.Windows.Forms.GroupBox();
            this.gbPressure = new System.Windows.Forms.GroupBox();
            this.lbPressureValueMax = new System.Windows.Forms.Label();
            this.lbPressureValueMin = new System.Windows.Forms.Label();
            this.lbPressureMax = new System.Windows.Forms.Label();
            this.lbPressureMin = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.gbTemperature = new System.Windows.Forms.GroupBox();
            this.lbTemperatureValueMax = new System.Windows.Forms.Label();
            this.lbTemperatureValueMim = new System.Windows.Forms.Label();
            this.lbTemperatureMax = new System.Windows.Forms.Label();
            this.lbTemperatureMin = new System.Windows.Forms.Label();
            this.gbClient.SuspendLayout();
            this.gbPressure.SuspendLayout();
            this.gbTemperature.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSites
            // 
            this.lbSites.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSites.FormattingEnabled = true;
            this.lbSites.ItemHeight = 24;
            this.lbSites.Location = new System.Drawing.Point(0, 0);
            this.lbSites.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lbSites.Name = "lbSites";
            this.lbSites.Size = new System.Drawing.Size(455, 539);
            this.lbSites.TabIndex = 0;
            this.lbSites.SelectedIndexChanged += new System.EventHandler(this.lbSites_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(455, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 539);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // gbClient
            // 
            this.gbClient.Controls.Add(this.gbPressure);
            this.gbClient.Controls.Add(this.splitter2);
            this.gbClient.Controls.Add(this.gbTemperature);
            this.gbClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbClient.Location = new System.Drawing.Point(461, 0);
            this.gbClient.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbClient.Name = "gbClient";
            this.gbClient.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbClient.Size = new System.Drawing.Size(348, 539);
            this.gbClient.TabIndex = 2;
            this.gbClient.TabStop = false;
            // 
            // gbPressure
            // 
            this.gbPressure.Controls.Add(this.lbPressureValueMax);
            this.gbPressure.Controls.Add(this.lbPressureValueMin);
            this.gbPressure.Controls.Add(this.lbPressureMax);
            this.gbPressure.Controls.Add(this.lbPressureMin);
            this.gbPressure.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPressure.Location = new System.Drawing.Point(6, 219);
            this.gbPressure.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbPressure.Name = "gbPressure";
            this.gbPressure.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbPressure.Size = new System.Drawing.Size(336, 185);
            this.gbPressure.TabIndex = 2;
            this.gbPressure.TabStop = false;
            this.gbPressure.Text = "Давление";
            // 
            // lbPressureValueMax
            // 
            this.lbPressureValueMax.AutoSize = true;
            this.lbPressureValueMax.Location = new System.Drawing.Point(75, 87);
            this.lbPressureValueMax.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPressureValueMax.Name = "lbPressureValueMax";
            this.lbPressureValueMax.Size = new System.Drawing.Size(0, 24);
            this.lbPressureValueMax.TabIndex = 3;
            // 
            // lbPressureValueMin
            // 
            this.lbPressureValueMin.AutoSize = true;
            this.lbPressureValueMin.Location = new System.Drawing.Point(70, 37);
            this.lbPressureValueMin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPressureValueMin.Name = "lbPressureValueMin";
            this.lbPressureValueMin.Size = new System.Drawing.Size(0, 24);
            this.lbPressureValueMin.TabIndex = 2;
            // 
            // lbPressureMax
            // 
            this.lbPressureMax.AutoSize = true;
            this.lbPressureMax.Location = new System.Drawing.Point(13, 89);
            this.lbPressureMax.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPressureMax.Name = "lbPressureMax";
            this.lbPressureMax.Size = new System.Drawing.Size(46, 24);
            this.lbPressureMax.TabIndex = 1;
            this.lbPressureMax.Text = "Max";
            // 
            // lbPressureMin
            // 
            this.lbPressureMin.AutoSize = true;
            this.lbPressureMin.Location = new System.Drawing.Point(13, 37);
            this.lbPressureMin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPressureMin.Name = "lbPressureMin";
            this.lbPressureMin.Size = new System.Drawing.Size(41, 24);
            this.lbPressureMin.TabIndex = 0;
            this.lbPressureMin.Text = "Min";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(6, 213);
            this.splitter2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(336, 6);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // gbTemperature
            // 
            this.gbTemperature.Controls.Add(this.lbTemperatureValueMax);
            this.gbTemperature.Controls.Add(this.lbTemperatureValueMim);
            this.gbTemperature.Controls.Add(this.lbTemperatureMax);
            this.gbTemperature.Controls.Add(this.lbTemperatureMin);
            this.gbTemperature.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTemperature.Location = new System.Drawing.Point(6, 28);
            this.gbTemperature.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbTemperature.Name = "gbTemperature";
            this.gbTemperature.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbTemperature.Size = new System.Drawing.Size(336, 185);
            this.gbTemperature.TabIndex = 0;
            this.gbTemperature.TabStop = false;
            this.gbTemperature.Text = "Температура";
            // 
            // lbTemperatureValueMax
            // 
            this.lbTemperatureValueMax.AutoSize = true;
            this.lbTemperatureValueMax.Location = new System.Drawing.Point(73, 87);
            this.lbTemperatureValueMax.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTemperatureValueMax.Name = "lbTemperatureValueMax";
            this.lbTemperatureValueMax.Size = new System.Drawing.Size(0, 24);
            this.lbTemperatureValueMax.TabIndex = 3;
            // 
            // lbTemperatureValueMim
            // 
            this.lbTemperatureValueMim.AutoSize = true;
            this.lbTemperatureValueMim.Location = new System.Drawing.Point(66, 37);
            this.lbTemperatureValueMim.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTemperatureValueMim.Name = "lbTemperatureValueMim";
            this.lbTemperatureValueMim.Size = new System.Drawing.Size(0, 24);
            this.lbTemperatureValueMim.TabIndex = 2;
            // 
            // lbTemperatureMax
            // 
            this.lbTemperatureMax.AutoSize = true;
            this.lbTemperatureMax.Location = new System.Drawing.Point(13, 89);
            this.lbTemperatureMax.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTemperatureMax.Name = "lbTemperatureMax";
            this.lbTemperatureMax.Size = new System.Drawing.Size(46, 24);
            this.lbTemperatureMax.TabIndex = 1;
            this.lbTemperatureMax.Text = "max";
            // 
            // lbTemperatureMin
            // 
            this.lbTemperatureMin.AutoSize = true;
            this.lbTemperatureMin.Location = new System.Drawing.Point(13, 37);
            this.lbTemperatureMin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTemperatureMin.Name = "lbTemperatureMin";
            this.lbTemperatureMin.Size = new System.Drawing.Size(41, 24);
            this.lbTemperatureMin.TabIndex = 0;
            this.lbTemperatureMin.Text = "min";
            // 
            // FormWeatheApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(809, 539);
            this.Controls.Add(this.gbClient);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lbSites);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormWeatheApp";
            this.Text = "WeatheApp";
            this.Load += new System.EventHandler(this.FormWeatheApp_Load);
            this.gbClient.ResumeLayout(false);
            this.gbPressure.ResumeLayout(false);
            this.gbPressure.PerformLayout();
            this.gbTemperature.ResumeLayout(false);
            this.gbTemperature.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSites;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox gbClient;
        private System.Windows.Forms.GroupBox gbPressure;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox gbTemperature;
        private System.Windows.Forms.Label lbPressureValueMax;
        private System.Windows.Forms.Label lbPressureValueMin;
        private System.Windows.Forms.Label lbPressureMax;
        private System.Windows.Forms.Label lbPressureMin;
        private System.Windows.Forms.Label lbTemperatureValueMax;
        private System.Windows.Forms.Label lbTemperatureValueMim;
        private System.Windows.Forms.Label lbTemperatureMax;
        private System.Windows.Forms.Label lbTemperatureMin;
    }
}

