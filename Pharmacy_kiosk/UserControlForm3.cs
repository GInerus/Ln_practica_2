using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace Pharmacy_kiosk
{
    public partial class UserControlForm3 : UserControl
    {
        private FormMain formMain;
        private Dictionary<Control, Rectangle> originalSizes = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private float originalFormWidth;
        private float originalFormHeight;
        private BindingSource bindingSource = new BindingSource(); // Добавляем BindingSource

        public SqlConnection sqlConnection = null;

        public UserControlForm3(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void UserControlForm3_Load(object sender, EventArgs e) // Загрузка формы
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);

            LoadData(sqlConnection);

            originalFormWidth = this.Width;
            originalFormHeight = this.Height;

            foreach (Control ctrl in this.Controls)
            {
                originalSizes[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);
                originalFontSizes[ctrl] = ctrl.Font.Size; // Запоминаем оригинальный размер шрифта
            }

            ChangeTheme();

            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);
            dataGridView3.DefaultCellStyle.Font = new Font("Arial", 11); // Шрифт всех ячеек

            dataGridView3.AllowUserToAddRows = false; //Строка для добавления данных
        }

        public void LoadData(SqlConnection connection)
        {
            try
            {
                // Запрос к базе данных для получения данных из таблицы Clients
                string query = "SELECT * FROM Clients";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Настройка BindingSource
                bindingSource.DataSource = dt;

                // Привязываем BindingSource к DataGridView
                dataGridView3.DataSource = bindingSource;

                // Проверяем наличие колонок перед их изменением
                if (dataGridView3.Columns.Count > 0)
                {
                    // Скрываем колонку ClientID, если она существует
                    if (dataGridView3.Columns.Contains("ClientID"))
                        dataGridView3.Columns["ClientID"].Visible = false;

                    // Переименовываем заголовки
                    if (dataGridView3.Columns.Contains("FullName"))
                        dataGridView3.Columns["FullName"].HeaderText = "ФИО клиента";

                    if (dataGridView3.Columns.Contains("ContactNumber"))
                        dataGridView3.Columns["ContactNumber"].HeaderText = "Контактный телефон";

                    if (dataGridView3.Columns.Contains("Discount"))
                        dataGridView3.Columns["Discount"].HeaderText = "Скидка";
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Изменение заголовков столбцов
            //dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView3.EnableHeadersVisualStyles = false; // Чтобы стиль заголовков применился

            // Изменение шрифта и цвета строк
            //dataGridView3.DefaultCellStyle.Font = new Font("Arial", 11); // Шрифт всех ячеек
            dataGridView3.DefaultCellStyle.ForeColor = Color.Black; // Цвет текста
            dataGridView3.DefaultCellStyle.BackColor = Color.White; // Цвет фона

            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет каждой второй строки

            // Изменение границ и сетки
            dataGridView3.GridColor = Color.Purple; // Цвет линий сетки
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Границы ячеек
            dataGridView3.RowHeadersVisible = false; // Скрыть заголовки строк

            // Убрать выделение всей строки при клике
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Цвет выделения
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.Black; // Цвет текста при выделении

            // Изменение размера строк и столбцов
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Авторазмер колонок
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Авторазмер строк
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Высота заголовков


            //// Можно изменять цвет ячеек в зависимости от значений
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "FullName") // Если столбец называется "Status"
            //{
            //    e.CellStyle.BackColor = Color.MediumPurple;
            //    e.CellStyle.ForeColor = Color.White;
            //}
        }

        private void UserControlForm3_Resize(object sender, EventArgs e)
        {
            float scaleWidth = this.Width / originalFormWidth;
            float scaleHeight = this.Height / originalFormHeight;
            float scaleFactor = Math.Min(scaleWidth, scaleHeight); // Сохраняем пропорции

            foreach (Control ctrl in this.Controls)
            {
                if (originalSizes.ContainsKey(ctrl))
                {
                    Rectangle original = originalSizes[ctrl];

                    // Масштабируем расположение и размер элемента
                    ctrl.Location = new Point((int)(original.X * scaleWidth), (int)(original.Y * scaleHeight));
                    ctrl.Size = new Size((int)(original.Width * scaleWidth), (int)(original.Height * scaleHeight));

                    // Масштабируем шрифт, но не позволяем ему стать меньше 1
                    float newFontSize = originalFontSizes[ctrl] * scaleFactor;
                    newFontSize = Math.Max(newFontSize, 1); // Минимальный размер шрифта - 1

                    ctrl.Font = new Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style);
                }
            }
        }

        private void ButtonToForm1_Click(object sender, EventArgs e)
        {
            UserControlForm1 userControlForm1 = new UserControlForm1(formMain);
            formMain.ShowControl(userControlForm1);
        }

        private void ButtonToForm2_Click(object sender, EventArgs e)
        {
            UserControlForm2 userControlForm2 = new UserControlForm2(formMain);
            formMain.ShowControl(userControlForm2);
        }

        private void ButtonToForm4_Click(object sender, EventArgs e)
        {
            UserControlForm4 userControlForm4 = new UserControlForm4(formMain);
            formMain.ShowControl(userControlForm4);
        }
        private void ButtonToForm5_Click(object sender, EventArgs e)
        {
            UserControlForm5 userControlForm5 = new UserControlForm5(formMain);
            formMain.ShowControl(userControlForm5);
        }


        private void buttonInfo_Click(object sender, EventArgs e)
        {
            ProgramInfo.ShowInfo(); // Вызов статического метода для отображения информации
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (AppSettings.ThemeApp == "light")
                AppSettings.ThemeApp = "dark"; //Либо dark либо light
            else
                AppSettings.ThemeApp = "light";

            ChangeTheme();
        }

        private void ChangeThemeOfButton(Button button) // Кнопка смены формы
        {
            if (AppSettings.ThemeApp == "dark")
            {
                button.BackColor = Color.FromArgb(15, 15, 15); //Черный фон кнопки
                button.FlatAppearance.BorderColor = Color.FromArgb(185, 185, 185); //Цвет обводки
                button.ForeColor = Color.FromArgb(255, 255, 255); // Черный цвет (шрифт)
            }
            else
            {
                button.BackColor = Color.FromArgb(240, 240, 240); // фон кнопки
                button.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70); //Цвет обводки
                button.ForeColor = Color.FromName("ControlText"); //  цвет (шрифт)
            }
        }

        private void ChangeTheme() // Функция смены формы
        {
            if (AppSettings.ThemeApp == "dark")
            {
                this.BackColor = Color.FromArgb(15, 15, 15); // Устанавливаем цвет фона формы

                buttonToForm3.BackColor = Color.FromArgb(185, 185, 185); // Задний фон кнопки
                buttonToForm3.FlatAppearance.BorderColor = Color.FromArgb(185, 185, 185); //Цвет обводки
                buttonToForm3.ForeColor = Color.FromArgb(0, 0, 0); // Цвет текста

                ChangeThemeOfButton(buttonToForm1);
                ChangeThemeOfButton(buttonToForm2);
                ChangeThemeOfButton(buttonToForm4);
                ChangeThemeOfButton(buttonToForm5);

                buttonInfo.Image = Properties.Resources.about_white;
                Settings.Image = Properties.Resources.settings_white;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240); // Устанавливаем цвет фона формы

                buttonToForm3.BackColor = Color.FromArgb(70, 70, 70); // фон кнопки
                buttonToForm3.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70); //Цвет обводки
                buttonToForm3.ForeColor = Color.FromArgb(255, 255, 255); //  цвет (шрифт)

                ChangeThemeOfButton(buttonToForm1);
                ChangeThemeOfButton(buttonToForm2);
                ChangeThemeOfButton(buttonToForm4);
                ChangeThemeOfButton(buttonToForm5);

                buttonInfo.Image = Properties.Resources.about;
                Settings.Image = Properties.Resources.settings;
            }
        }

        private void add_data_bt_Click(object sender, EventArgs e)
        {

        }
    }
}
