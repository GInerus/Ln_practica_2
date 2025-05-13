using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;


namespace Pharmacy_kiosk
{
    public partial class UserControlForm2 : UserControl
    {
        private FormMain formMain;
        private Dictionary<Control, Rectangle> originalSizes = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private float originalFormWidth;
        private float originalFormHeight;
        private BindingSource bindingSource = new BindingSource(); // Добавляем BindingSource

        public SqlConnection sqlConnection = null;

        public UserControlForm2(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void UserControlForm2_Load(object sender, EventArgs e) // Загрузка формы
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

            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 11); // Шрифт всех ячеек

            // Инициализация TextBox
            txtSearch.Text = placeholderText; // Устанавливаем текст-подсказку
            txtSearch.ForeColor = Color.Gray; // Устанавливаем серый цвет текста

            dataGridView2.AllowUserToAddRows = false; //Строка для добавления данных
        }

        public void LoadData(SqlConnection connection)
        {
            try
            {
                // Запрос к базе данных для получения данных из таблицы Employees
                string query = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Настройка BindingSource
                bindingSource.DataSource = dt;

                // Привязываем BindingSource к DataGridView
                dataGridView2.DataSource = bindingSource;

                // Проверяем наличие колонок перед их изменением
                if (dataGridView2.Columns.Count > 0)
                {
                    // Скрываем колонку EmployeeID, если она существует
                    if (dataGridView2.Columns.Contains("EmployeeID"))
                        dataGridView2.Columns["EmployeeID"].Visible = false;

                    // Переименовываем заголовки
                    if (dataGridView2.Columns.Contains("FullName"))
                        dataGridView2.Columns["FullName"].HeaderText = "ФИО сотрудника";

                    if (dataGridView2.Columns.Contains("Position"))
                        dataGridView2.Columns["Position"].HeaderText = "Должность";

                    if (dataGridView2.Columns.Contains("ContactNumber"))
                        dataGridView2.Columns["ContactNumber"].HeaderText = "Контактный телефон";
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Изменение заголовков столбцов
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.EnableHeadersVisualStyles = false; // Чтобы стиль заголовков применился

            // Изменение шрифта и цвета строк
            //dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11); // Шрифт всех ячеек
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black; // Цвет текста
            dataGridView2.DefaultCellStyle.BackColor = Color.White; // Цвет фона

            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет каждой второй строки

            // Изменение границ и сетки
            dataGridView2.GridColor = Color.Purple; // Цвет линий сетки
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Границы ячеек
            dataGridView2.RowHeadersVisible = false; // Скрыть заголовки строк

            // Убрать выделение всей строки при клике
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Цвет выделения
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black; // Цвет текста при выделении

            // Изменение размера строк и столбцов
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Авторазмер колонок
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Авторазмер строк
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Высота заголовков


            //// Можно изменять цвет ячеек в зависимости от значений
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "FullName") // Если столбец называется "Status"
            //{
            //    e.CellStyle.BackColor = Color.MediumPurple;
            //    e.CellStyle.ForeColor = Color.White;
            //}
        }

        private void ButtonToForm1_Click(object sender, EventArgs e)
        {
            UserControlForm1 userControlForm1 = new UserControlForm1(formMain);
            formMain.ShowControl(userControlForm1);
        }

        private void ButtonToForm3_Click(object sender, EventArgs e)
        {
            UserControlForm3 userControlForm3 = new UserControlForm3(formMain);
            formMain.ShowControl(userControlForm3);
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

        private void UserControlForm2_Resize(object sender, EventArgs e)
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


                    int SizeFontGrid = (int)(11 * scaleFactor);

                    SizeFontGrid = Math.Max(SizeFontGrid, 1); // Минимальный размер шрифта - 1

                    dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", SizeFontGrid, FontStyle.Bold);
                    dataGridView2.DefaultCellStyle.Font = new Font("Arial", SizeFontGrid); // Шрифт всех ячеек

                }
            }
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

                buttonToForm2.BackColor = Color.FromArgb(185, 185, 185); // Задний фон кнопки
                buttonToForm2.FlatAppearance.BorderColor = Color.FromArgb(185, 185, 185); //Цвет обводки
                buttonToForm2.ForeColor = Color.FromArgb(0, 0, 0); // Цвет текста

                ChangeThemeOfButton(buttonToForm1);
                ChangeThemeOfButton(buttonToForm3);
                ChangeThemeOfButton(buttonToForm4);
                ChangeThemeOfButton(buttonToForm5);

                label1.ForeColor = Color.FromArgb(255, 255, 255); // Белый цвет (шрифт)

                buttonInfo.Image = Properties.Resources.about_white;
                Settings.Image = Properties.Resources.settings_white;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240); // Устанавливаем цвет фона формы

                buttonToForm2.BackColor = Color.FromArgb(70, 70, 70); // фон кнопки
                buttonToForm2.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70); //Цвет обводки
                buttonToForm2.ForeColor = Color.FromArgb(255, 255, 255); //  цвет (шрифт)

                ChangeThemeOfButton(buttonToForm1);
                ChangeThemeOfButton(buttonToForm3);
                ChangeThemeOfButton(buttonToForm4);
                ChangeThemeOfButton(buttonToForm5);


                label1.ForeColor = Color.FromArgb(0, 0, 0); // Черный цвет (шрифт)

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

        private void FilterData(string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter))
                {
                    bindingSource.Filter = null; // Сбрасываем фильтр, если строка пустая
                }
                else
                {
                    // Фильтруем по любому вхождению подстроки в ФИО
                    bindingSource.Filter = $"FullName LIKE '%{filter}%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при фильтрации данных: " + ex.Message);
            }
        }

        private string placeholderText = "Поисковик по ФИО"; // Текст-подсказка

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Если текст не равен подсказке и не пустой, применяем фильтрацию
            if (txtSearch.Text != placeholderText && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string filter = txtSearch.Text.Trim().ToLower(); // Получаем текст фильтра
                FilterData(filter); // Применяем фильтрацию
            }
            else
            {
                // Если текст пустой или равен подсказке, сбрасываем фильтр
                FilterData(""); // Сбрасываем фильтр
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            // Если текст равен подсказке, очищаем поле
            if (txtSearch.Text == placeholderText)
            {
                txtSearch.Text = ""; // Очищаем поле
                txtSearch.ForeColor = Color.Black; // Устанавливаем стандартный цвет текста
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            // Если поле пустое, возвращаем текст-подсказку
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = placeholderText; // Возвращаем подсказку
                txtSearch.ForeColor = Color.Gray; // Устанавливаем серый цвет текста
            }
        }

        private void AddEmployees_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр UserControl
            AddEmployeeControl addControl = new AddEmployeeControl();

            // Подписываемся на событие добавления данных
            addControl.OnAddEmployee += (FullName, Position, ContactNumber) =>
            {
                // Проверяем, существует ли фио сотрудника с таким же фио (без учета регистра)
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
                    {
                        connection.Open();

                        // SQL-запрос для проверки существования фио (без учета регистра)
                        string checkQuery = "SELECT COUNT(*) FROM Employees WHERE LOWER(FullName) = LOWER(@FullName)";

                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@FullName", FullName);

                            int count = (int)checkCommand.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("Этот сотрудник уже зарегестирован в базе.");
                                return;
                            }
                        }

                        // SQL-запрос для добавления новой записи
                        string insertQuery = "INSERT INTO Employees (FullName, Position, ContactNumber) " +
                                           "VALUES (@FullName, @Position, @ContactNumber)";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@FullName", FullName);
                            insertCommand.Parameters.AddWithValue("@Position", Position);
                            insertCommand.Parameters.AddWithValue("@ContactNumber", ContactNumber);

                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Обновляем DataGridView
                                LoadData(sqlConnection);

                                MessageBox.Show("Данные успешно добавлены.");

                                // Скрываем UserControl и Panel
                                addControl.Visible = false;
                                panelEmployee.Visible = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
                }
            };

            // Добавляем UserControl в Panel
            panelEmployee.Controls.Clear();
            panelEmployee.Controls.Add(addControl);

            // Показываем Panel
            panelEmployee.Visible = true;
        }


        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {

            // Создаем экземпляр UserControl
            DeleteEmployeeControl deleteControl = new DeleteEmployeeControl(sqlConnection, LoadData);

            // Очищаем Panel и добавляем UserControl
            panelEmployee.Controls.Clear();
            panelEmployee.Controls.Add(deleteControl);

            // Показываем Panel
            panelEmployee.Visible = true;
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр UserControl
            EditEmployeeControl editControl = new EditEmployeeControl(sqlConnection);

            // Подписываемся на событие обновления данных
            editControl.OnEmployeeUpdated += () =>
            {
                // Обновляем DataGridView
                LoadData(sqlConnection);
            };

            // Очищаем Panel и добавляем UserControl
            panelEmployee.Controls.Clear();
            panelEmployee.Controls.Add(editControl);

            // Показываем Panel
            panelEmployee.Visible = true;
        }
    }
}
