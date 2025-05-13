namespace Pharmacy_kiosk
{
    partial class UserControlForm5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlForm5));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonInfo = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.PictureBox();
            this.buttonToForm5 = new System.Windows.Forms.Button();
            this.buttonToForm4 = new System.Windows.Forms.Button();
            this.buttonToForm1 = new System.Windows.Forms.Button();
            this.buttonToForm3 = new System.Windows.Forms.Button();
            this.buttonToForm2 = new System.Windows.Forms.Button();
            this.comboBoxReportType = new System.Windows.Forms.ComboBox();
            this.chartReports = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReports)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonInfo
            // 
            this.buttonInfo.Image = ((System.Drawing.Image)(resources.GetObject("buttonInfo.Image")));
            this.buttonInfo.Location = new System.Drawing.Point(748, 401);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(40, 40);
            this.buttonInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonInfo.TabIndex = 16;
            this.buttonInfo.TabStop = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // Settings
            // 
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.Location = new System.Drawing.Point(700, 401);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(40, 40);
            this.Settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Settings.TabIndex = 18;
            this.Settings.TabStop = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // buttonToForm5
            // 
            this.buttonToForm5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm5.FlatAppearance.BorderSize = 0;
            this.buttonToForm5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm5.ForeColor = System.Drawing.Color.White;
            this.buttonToForm5.Location = new System.Drawing.Point(643, 3);
            this.buttonToForm5.Name = "buttonToForm5";
            this.buttonToForm5.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm5.TabIndex = 25;
            this.buttonToForm5.Text = "Отчёты";
            this.buttonToForm5.UseVisualStyleBackColor = false;
            // 
            // buttonToForm4
            // 
            this.buttonToForm4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm4.FlatAppearance.BorderSize = 3;
            this.buttonToForm4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm4.Location = new System.Drawing.Point(483, 3);
            this.buttonToForm4.Name = "buttonToForm4";
            this.buttonToForm4.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm4.TabIndex = 24;
            this.buttonToForm4.Text = "Продажи";
            this.buttonToForm4.UseVisualStyleBackColor = true;
            this.buttonToForm4.Click += new System.EventHandler(this.ButtonToForm4_Click);
            // 
            // buttonToForm1
            // 
            this.buttonToForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonToForm1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm1.FlatAppearance.BorderSize = 3;
            this.buttonToForm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonToForm1.Location = new System.Drawing.Point(3, 3);
            this.buttonToForm1.Name = "buttonToForm1";
            this.buttonToForm1.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm1.TabIndex = 23;
            this.buttonToForm1.Text = "Медикаменты";
            this.buttonToForm1.UseVisualStyleBackColor = false;
            this.buttonToForm1.Click += new System.EventHandler(this.ButtonToForm1_Click);
            // 
            // buttonToForm3
            // 
            this.buttonToForm3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm3.FlatAppearance.BorderSize = 3;
            this.buttonToForm3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm3.Location = new System.Drawing.Point(323, 3);
            this.buttonToForm3.Name = "buttonToForm3";
            this.buttonToForm3.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm3.TabIndex = 22;
            this.buttonToForm3.Text = "Клиенты";
            this.buttonToForm3.UseVisualStyleBackColor = true;
            this.buttonToForm3.Click += new System.EventHandler(this.ButtonToForm3_Click);
            // 
            // buttonToForm2
            // 
            this.buttonToForm2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm2.FlatAppearance.BorderSize = 3;
            this.buttonToForm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm2.Location = new System.Drawing.Point(163, 3);
            this.buttonToForm2.Name = "buttonToForm2";
            this.buttonToForm2.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm2.TabIndex = 21;
            this.buttonToForm2.Text = "Сотрудники";
            this.buttonToForm2.UseVisualStyleBackColor = true;
            this.buttonToForm2.Click += new System.EventHandler(this.ButtonToForm2_Click);
            // 
            // comboBoxReportType
            // 
            this.comboBoxReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxReportType.FormattingEnabled = true;
            this.comboBoxReportType.Location = new System.Drawing.Point(13, 60);
            this.comboBoxReportType.Name = "comboBoxReportType";
            this.comboBoxReportType.Size = new System.Drawing.Size(775, 33);
            this.comboBoxReportType.TabIndex = 26;
            this.comboBoxReportType.Text = "Топ продаваемых лекарств";
            // 
            // chartReports
            // 
            chartArea3.Name = "ChartArea1";
            this.chartReports.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartReports.Legends.Add(legend3);
            this.chartReports.Location = new System.Drawing.Point(13, 101);
            this.chartReports.Name = "chartReports";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartReports.Series.Add(series3);
            this.chartReports.Size = new System.Drawing.Size(779, 316);
            this.chartReports.TabIndex = 32;
            this.chartReports.Text = "chart1";
            // 
            // UserControlForm5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.comboBoxReportType);
            this.Controls.Add(this.buttonToForm5);
            this.Controls.Add(this.buttonToForm4);
            this.Controls.Add(this.buttonToForm1);
            this.Controls.Add(this.buttonToForm3);
            this.Controls.Add(this.buttonToForm2);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.chartReports);
            this.Name = "UserControlForm5";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.UserControlForm5_Load);
            this.Resize += new System.EventHandler(this.UserControlForm5_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox buttonInfo;
        private System.Windows.Forms.PictureBox Settings;
        private System.Windows.Forms.Button buttonToForm5;
        private System.Windows.Forms.Button buttonToForm4;
        private System.Windows.Forms.Button buttonToForm1;
        private System.Windows.Forms.Button buttonToForm3;
        private System.Windows.Forms.Button buttonToForm2;
        private System.Windows.Forms.ComboBox comboBoxReportType;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReports;
    }
}
