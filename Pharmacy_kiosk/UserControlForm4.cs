using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
namespace Pharmacy_kiosk
{
    public partial class UserControlForm4 : UserControl
    {
        private FormMain formMain;
        private Dictionary<Control, Rectangle> originalSizes = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private float originalFormWidth;
        private float originalFormHeight;
        private BindingSource bindingSource = new BindingSource(); // Добавляем BindingSource

        public SqlConnection sqlConnection = null;

        public UserControlForm4(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void UserControlForm4_Load(object sender, EventArgs e) // Загрузка формы
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

            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);
            dataGridView4.DefaultCellStyle.Font = new Font("Arial", 11); // Шрифт всех ячеек

            dataGridView4.AllowUserToAddRows = false; //Строка для добавления данных

        }

        public void LoadData(SqlConnection connection)
        {
            try
            {
                // Запрос к базе данных для получения данных
                string query = @"
            SELECT 
                CONVERT(VARCHAR, S.SaleDate, 104) AS Дата,
                ISNULL(C.FullName, 'Не зарегистрирован') AS ФИО_клиента,
                E.FullName AS ФИО_продавца,
                STUFF((SELECT ', ' + M.Name + ' (' + CAST(SD.QuantitySold AS VARCHAR) + N' шт.)'
                       FROM SaleDetails SD
                       JOIN Medications M ON SD.MedicationID = M.MedicationID
                       WHERE SD.SaleID = S.SaleID
                       FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Список_товаров,
                S.TotalAmount AS Общая_сумма
            FROM Sales S
            JOIN Employees E ON S.EmployeeID = E.EmployeeID
            LEFT JOIN Clients C ON S.ClientID = C.ClientID
            ORDER BY S.SaleDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Привязываем DataTable к DataGridView
                dataGridView4.DataSource = dt;

                // Настройка заголовков колонок
                if (dataGridView4.Columns.Count > 0)
                {
                    dataGridView4.Columns["Дата"].HeaderText = "Дата";
                    dataGridView4.Columns["ФИО_клиента"].HeaderText = "ФИО клиента";
                    dataGridView4.Columns["ФИО_продавца"].HeaderText = "ФИО продавца";
                    dataGridView4.Columns["Список_товаров"].HeaderText = "Список товаров";
                    dataGridView4.Columns["Общая_сумма"].HeaderText = "Общая сумма";
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Изменение заголовков столбцов
            //dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView4.EnableHeadersVisualStyles = false; // Чтобы стиль заголовков применился

            // Изменение шрифта и цвета строк
            //dataGridView4.DefaultCellStyle.Font = new Font("Arial", 11); // Шрифт всех ячеек
            dataGridView4.DefaultCellStyle.ForeColor = Color.Black; // Цвет текста
            dataGridView4.DefaultCellStyle.BackColor = Color.White; // Цвет фона

            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет каждой второй строки

            // Изменение границ и сетки
            dataGridView4.GridColor = Color.Purple; // Цвет линий сетки
            //dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Границы ячеек
            dataGridView4.RowHeadersVisible = false; // Скрыть заголовки строк

            // Убрать выделение всей строки при клике
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Цвет выделения
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.Black; // Цвет текста при выделении

            // Изменение размера строк и столбцов
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Авторазмер колонок
            dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Авторазмер строк
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Высота заголовков


            //// Можно изменять цвет ячеек в зависимости от значений
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "FullName") // Если столбец называется "Status"
            //{
            //    e.CellStyle.BackColor = Color.MediumPurple;
            //    e.CellStyle.ForeColor = Color.White;
            //}
        }

        private void UserControlForm4_Resize(object sender, EventArgs e)
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

        private void ButtonToForm3_Click(object sender, EventArgs e)
        {
            UserControlForm3 userControlForm3 = new UserControlForm3(formMain);
            formMain.ShowControl(userControlForm3);
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


        private void ChangeThemeOfButton(Button button)
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

        private void ChangeTheme()
        {
            if (AppSettings.ThemeApp == "dark")
            {
                this.BackColor = Color.FromArgb(15, 15, 15); // Устанавливаем цвет фона формы

                buttonToForm4.BackColor = Color.FromArgb(185, 185, 185); // Задний фон кнопки
                buttonToForm4.FlatAppearance.BorderColor = Color.FromArgb(185, 185, 185); //Цвет обводки
                buttonToForm4.ForeColor = Color.FromArgb(0, 0, 0); // Цвет текста

                ChangeThemeOfButton(buttonToForm1);
                ChangeThemeOfButton(buttonToForm2);
                ChangeThemeOfButton(buttonToForm3);
                ChangeThemeOfButton(buttonToForm5);

                buttonInfo.Image = Properties.Resources.about_white;
                Settings.Image = Properties.Resources.settings_white;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240); // Устанавливаем цвет фона формы

                buttonToForm4.BackColor = Color.FromArgb(70, 70, 70); // фон кнопки
                buttonToForm4.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70); //Цвет обводки
                buttonToForm4.ForeColor = Color.FromArgb(255, 255, 255); //  цвет (шрифт)

                ChangeThemeOfButton(buttonToForm1);
                ChangeThemeOfButton(buttonToForm2);
                ChangeThemeOfButton(buttonToForm3);
                ChangeThemeOfButton(buttonToForm5);


                buttonInfo.Image = Properties.Resources.about;
                Settings.Image = Properties.Resources.settings;
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (AppSettings.ThemeApp == "light")
                AppSettings.ThemeApp = "dark"; //Либо dark либо light
            else
                AppSettings.ThemeApp = "light";

            ChangeTheme();
        }
    }
}
