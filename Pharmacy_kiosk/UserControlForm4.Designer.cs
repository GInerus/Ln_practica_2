namespace Pharmacy_kiosk
{
    partial class UserControlForm4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlForm4));
            this.buttonInfo = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.PictureBox();
            this.buttonToForm5 = new System.Windows.Forms.Button();
            this.buttonToForm4 = new System.Windows.Forms.Button();
            this.buttonToForm1 = new System.Windows.Forms.Button();
            this.buttonToForm3 = new System.Windows.Forms.Button();
            this.buttonToForm2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
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
            this.buttonToForm5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm5.FlatAppearance.BorderSize = 3;
            this.buttonToForm5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm5.Location = new System.Drawing.Point(643, 3);
            this.buttonToForm5.Name = "buttonToForm5";
            this.buttonToForm5.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm5.TabIndex = 25;
            this.buttonToForm5.Text = "Отчёты";
            this.buttonToForm5.UseVisualStyleBackColor = true;
            this.buttonToForm5.Click += new System.EventHandler(this.ButtonToForm5_Click);
            // 
            // buttonToForm4
            // 
            this.buttonToForm4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.buttonToForm4.FlatAppearance.BorderSize = 0;
            this.buttonToForm4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToForm4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToForm4.ForeColor = System.Drawing.Color.White;
            this.buttonToForm4.Location = new System.Drawing.Point(483, 3);
            this.buttonToForm4.Name = "buttonToForm4";
            this.buttonToForm4.Size = new System.Drawing.Size(154, 40);
            this.buttonToForm4.TabIndex = 24;
            this.buttonToForm4.Text = "Продажи";
            this.buttonToForm4.UseVisualStyleBackColor = false;
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(13, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(518, 35);
            this.textBox1.TabIndex = 27;
            this.textBox1.Text = "Поиск по клиенту, продавцу, медикаменту";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(13, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(681, 40);
            this.button1.TabIndex = 28;
            this.button1.Text = "Оформить продажу";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(537, 60);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(251, 35);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(13, 101);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(779, 271);
            this.dataGridView4.TabIndex = 35;
            this.dataGridView4.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView4_CellFormatting);
            // 
            // UserControlForm4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonToForm5);
            this.Controls.Add(this.buttonToForm4);
            this.Controls.Add(this.buttonToForm1);
            this.Controls.Add(this.buttonToForm3);
            this.Controls.Add(this.buttonToForm2);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.buttonInfo);
            this.Name = "UserControlForm4";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.UserControlForm4_Load);
            this.Resize += new System.EventHandler(this.UserControlForm4_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox buttonInfo;
        private System.Windows.Forms.PictureBox Settings;
        private System.Windows.Forms.Button buttonToForm5;
        private System.Windows.Forms.Button buttonToForm4;
        private System.Windows.Forms.Button buttonToForm1;
        private System.Windows.Forms.Button buttonToForm3;
        private System.Windows.Forms.Button buttonToForm2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView4;
    }
}
