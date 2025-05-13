namespace Pharmacy_kiosk
{
    partial class UserControlForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlForm2));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonToForm5 = new System.Windows.Forms.Button();
            this.buttonToForm4 = new System.Windows.Forms.Button();
            this.buttonToForm1 = new System.Windows.Forms.Button();
            this.buttonToForm3 = new System.Windows.Forms.Button();
            this.buttonToForm2 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.AddEmployee = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panelEmployee = new System.Windows.Forms.Panel();
            this.Settings = new System.Windows.Forms.PictureBox();
            this.buttonInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panelEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(83, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 108);
            this.label1.TabIndex = 12;
            this.label1.Text = "Тут таблица сотрудников:\r\n\r\nКолонки таблици:\r\n- ФИО\r\n- Должность (фармацевт, адми" +
    "нистратор)\r\n- Контактный телефон";
            // 
            // buttonToForm5
            // 
            this.buttonToForm5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm5.FlatAppearance.BorderSize = 3;
            this.buttonToForm5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm5.Location = new System.Drawing.Point(643, 3);
            this.buttonToForm5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonToForm5.Name = "buttonToForm5";
            this.buttonToForm5.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm5.TabIndex = 25;
            this.buttonToForm5.Text = "Отчёты";
            this.buttonToForm5.UseVisualStyleBackColor = true;
            this.buttonToForm5.Click += new System.EventHandler(this.ButtonToForm5_Click);
            // 
            // buttonToForm4
            // 
            this.buttonToForm4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm4.FlatAppearance.BorderSize = 3;
            this.buttonToForm4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm4.Location = new System.Drawing.Point(483, 3);
            this.buttonToForm4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonToForm4.Name = "buttonToForm4";
            this.buttonToForm4.Size = new System.Drawing.Size(154, 41);
            this.buttonToForm4.TabIndex = 24;
            this.buttonToForm4.Text = "Продажи";
            this.buttonToForm4.UseVisualStyleBackColor = true;
            this.buttonToForm4.Click += new System.EventHandler(this.ButtonToForm4_Click);
            // 
            // buttonToForm1
            // 
            this.buttonToForm1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonToForm1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm1.FlatAppearance.BorderSize = 3;
            this.buttonToForm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonToForm1.Location = new System.Drawing.Point(3, 3);
            this.buttonToForm1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonToForm1.Name = "buttonToForm1";
            this.buttonToForm1.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm1.TabIndex = 1;
            this.buttonToForm1.Tag = "";
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
            this.buttonToForm3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonToForm3.Name = "buttonToForm3";
            this.buttonToForm3.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm3.TabIndex = 2;
            this.buttonToForm3.Text = "Клиенты";
            this.buttonToForm3.UseVisualStyleBackColor = true;
            this.buttonToForm3.Click += new System.EventHandler(this.ButtonToForm3_Click);
            // 
            // buttonToForm2
            // 
            this.buttonToForm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm2.FlatAppearance.BorderSize = 0;
            this.buttonToForm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm2.ForeColor = System.Drawing.Color.White;
            this.buttonToForm2.Location = new System.Drawing.Point(163, 3);
            this.buttonToForm2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonToForm2.Name = "buttonToForm2";
            this.buttonToForm2.Size = new System.Drawing.Size(154, 41);
            this.buttonToForm2.TabIndex = 1;
            this.buttonToForm2.Text = "Сотрудники";
            this.buttonToForm2.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtSearch.Location = new System.Drawing.Point(13, 60);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(464, 35);
            this.txtSearch.TabIndex = 28;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnDeleteEmployee.FlatAppearance.BorderSize = 3;
            this.btnDeleteEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnDeleteEmployee.Location = new System.Drawing.Point(254, 401);
            this.btnDeleteEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(215, 40);
            this.btnDeleteEmployee.TabIndex = 31;
            this.btnDeleteEmployee.Text = "Удалить";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnEditEmployee.FlatAppearance.BorderSize = 3;
            this.btnEditEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnEditEmployee.Location = new System.Drawing.Point(479, 401);
            this.btnEditEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(215, 40);
            this.btnEditEmployee.TabIndex = 30;
            this.btnEditEmployee.Text = "Редактировать";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // AddEmployee
            // 
            this.AddEmployee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.AddEmployee.FlatAppearance.BorderSize = 3;
            this.AddEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.AddEmployee.Location = new System.Drawing.Point(13, 401);
            this.AddEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddEmployee.Name = "AddEmployee";
            this.AddEmployee.Size = new System.Drawing.Size(230, 40);
            this.AddEmployee.TabIndex = 29;
            this.AddEmployee.Text = "Добавить нового сотрудника";
            this.AddEmployee.UseVisualStyleBackColor = true;
            this.AddEmployee.Click += new System.EventHandler(this.AddEmployees_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(483, 60);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(305, 37);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.Text = "Фильтр по должности";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(13, 101);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(779, 271);
            this.dataGridView2.TabIndex = 33;
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // panelEmployee
            // 
            this.panelEmployee.BackColor = System.Drawing.Color.Transparent;
            this.panelEmployee.Controls.Add(this.label1);
            this.panelEmployee.Location = new System.Drawing.Point(163, 160);
            this.panelEmployee.Name = "panelEmployee";
            this.panelEmployee.Size = new System.Drawing.Size(474, 150);
            this.panelEmployee.TabIndex = 34;
            this.panelEmployee.Visible = false;
            // 
            // Settings
            // 
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.Location = new System.Drawing.Point(700, 401);
            this.Settings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(40, 40);
            this.Settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Settings.TabIndex = 27;
            this.Settings.TabStop = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Image = ((System.Drawing.Image)(resources.GetObject("buttonInfo.Image")));
            this.buttonInfo.Location = new System.Drawing.Point(748, 401);
            this.buttonInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(40, 40);
            this.buttonInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonInfo.TabIndex = 26;
            this.buttonInfo.TabStop = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // UserControlForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelEmployee);
            this.Controls.Add(this.btnEditEmployee);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.AddEmployee);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonToForm5);
            this.Controls.Add(this.buttonToForm4);
            this.Controls.Add(this.buttonToForm1);
            this.Controls.Add(this.buttonToForm3);
            this.Controls.Add(this.buttonToForm2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserControlForm2";
            this.Size = new System.Drawing.Size(800, 449);
            this.Load += new System.EventHandler(this.UserControlForm2_Load);
            this.Resize += new System.EventHandler(this.UserControlForm2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panelEmployee.ResumeLayout(false);
            this.panelEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonToForm5;
        private System.Windows.Forms.Button buttonToForm4;
        private System.Windows.Forms.Button buttonToForm1;
        private System.Windows.Forms.Button buttonToForm3;
        private System.Windows.Forms.Button buttonToForm2;
        private System.Windows.Forms.PictureBox Settings;
        private System.Windows.Forms.PictureBox buttonInfo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Button AddEmployee;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panelEmployee;
    }
}
