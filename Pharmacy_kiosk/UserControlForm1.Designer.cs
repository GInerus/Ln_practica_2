namespace Pharmacy_kiosk
{
    partial class UserControlForm1
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
            this.buttonToForm3 = new System.Windows.Forms.Button();
            this.buttonToForm2 = new System.Windows.Forms.Button();
            this.buttonToForm1 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.AddMedicines = new System.Windows.Forms.Button();
            this.btnEditMedicine = new System.Windows.Forms.Button();
            this.btnDeleteMedicine = new System.Windows.Forms.Button();
            this.buttonToForm4 = new System.Windows.Forms.Button();
            this.buttonToForm5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelMedicine = new System.Windows.Forms.Panel();
            this.Settings = new System.Windows.Forms.PictureBox();
            this.buttonInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).BeginInit();
            this.SuspendLayout();
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
            this.buttonToForm3.TabIndex = 8;
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
            this.buttonToForm2.TabIndex = 7;
            this.buttonToForm2.Text = "Сотрудники";
            this.buttonToForm2.UseVisualStyleBackColor = true;
            this.buttonToForm2.Click += new System.EventHandler(this.ButtonToForm2_Click);
            // 
            // buttonToForm1
            // 
            this.buttonToForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm1.FlatAppearance.BorderSize = 0;
            this.buttonToForm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm1.ForeColor = System.Drawing.Color.White;
            this.buttonToForm1.Location = new System.Drawing.Point(3, 3);
            this.buttonToForm1.Name = "buttonToForm1";
            this.buttonToForm1.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm1.TabIndex = 10;
            this.buttonToForm1.Text = "Медикаменты";
            this.buttonToForm1.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.AccessibleDescription = "";
            this.txtSearch.AccessibleName = "";
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(13, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(779, 35);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.Tag = "";
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // AddMedicines
            // 
            this.AddMedicines.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.AddMedicines.FlatAppearance.BorderSize = 3;
            this.AddMedicines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddMedicines.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddMedicines.Location = new System.Drawing.Point(13, 401);
            this.AddMedicines.Name = "AddMedicines";
            this.AddMedicines.Size = new System.Drawing.Size(215, 40);
            this.AddMedicines.TabIndex = 13;
            this.AddMedicines.Text = "Добавить лекарство";
            this.AddMedicines.UseVisualStyleBackColor = true;
            this.AddMedicines.Click += new System.EventHandler(this.AddMedicines_Click);
            // 
            // btnEditMedicine
            // 
            this.btnEditMedicine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnEditMedicine.FlatAppearance.BorderSize = 3;
            this.btnEditMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditMedicine.Location = new System.Drawing.Point(479, 401);
            this.btnEditMedicine.Name = "btnEditMedicine";
            this.btnEditMedicine.Size = new System.Drawing.Size(215, 40);
            this.btnEditMedicine.TabIndex = 14;
            this.btnEditMedicine.Text = "Редактировать";
            this.btnEditMedicine.UseVisualStyleBackColor = true;
            this.btnEditMedicine.Click += new System.EventHandler(this.btnEditMedicine_Click);
            // 
            // btnDeleteMedicine
            // 
            this.btnDeleteMedicine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnDeleteMedicine.FlatAppearance.BorderSize = 3;
            this.btnDeleteMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteMedicine.Location = new System.Drawing.Point(249, 401);
            this.btnDeleteMedicine.Name = "btnDeleteMedicine";
            this.btnDeleteMedicine.Size = new System.Drawing.Size(215, 40);
            this.btnDeleteMedicine.TabIndex = 15;
            this.btnDeleteMedicine.Text = "Удалить";
            this.btnDeleteMedicine.UseVisualStyleBackColor = true;
            this.btnDeleteMedicine.Click += new System.EventHandler(this.btnDeleteMedicine_Click);
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
            this.buttonToForm4.TabIndex = 19;
            this.buttonToForm4.Text = "Продажи";
            this.buttonToForm4.UseVisualStyleBackColor = true;
            this.buttonToForm4.Click += new System.EventHandler(this.ButtonToForm4_Click);
            // 
            // buttonToForm5
            // 
            this.buttonToForm5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm5.FlatAppearance.BorderSize = 3;
            this.buttonToForm5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm5.Location = new System.Drawing.Point(643, 3);
            this.buttonToForm5.Name = "buttonToForm5";
            this.buttonToForm5.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm5.TabIndex = 20;
            this.buttonToForm5.Text = "Отчёты";
            this.buttonToForm5.UseVisualStyleBackColor = true;
            this.buttonToForm5.Click += new System.EventHandler(this.ButtonToForm5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(779, 271);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // panelMedicine
            // 
            this.panelMedicine.BackColor = System.Drawing.Color.Transparent;
            this.panelMedicine.Location = new System.Drawing.Point(163, 181);
            this.panelMedicine.Name = "panelMedicine";
            this.panelMedicine.Size = new System.Drawing.Size(474, 150);
            this.panelMedicine.TabIndex = 23;
            this.panelMedicine.Visible = false;
            // 
            // Settings
            // 
            this.Settings.Image = global::Pharmacy_kiosk.Properties.Resources.settings;
            this.Settings.Location = new System.Drawing.Point(700, 401);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(40, 40);
            this.Settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Settings.TabIndex = 18;
            this.Settings.TabStop = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Image = global::Pharmacy_kiosk.Properties.Resources.about;
            this.buttonInfo.Location = new System.Drawing.Point(749, 401);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(40, 40);
            this.buttonInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonInfo.TabIndex = 16;
            this.buttonInfo.TabStop = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // UserControlForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelMedicine);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonToForm5);
            this.Controls.Add(this.buttonToForm4);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.btnDeleteMedicine);
            this.Controls.Add(this.btnEditMedicine);
            this.Controls.Add(this.AddMedicines);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.buttonToForm1);
            this.Controls.Add(this.buttonToForm3);
            this.Controls.Add(this.buttonToForm2);
            this.Name = "UserControlForm1";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.UserControlForm1_Load);
            this.Resize += new System.EventHandler(this.UserControlForm1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToForm3;
        private System.Windows.Forms.Button buttonToForm2;
        private System.Windows.Forms.Button buttonToForm1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button AddMedicines;
        private System.Windows.Forms.Button btnEditMedicine;
        private System.Windows.Forms.Button btnDeleteMedicine;
        private System.Windows.Forms.PictureBox buttonInfo;
        private System.Windows.Forms.PictureBox Settings;
        private System.Windows.Forms.Button buttonToForm4;
        private System.Windows.Forms.Button buttonToForm5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelMedicine;
    }
}
