using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;


namespace Pharmacy_kiosk
{
    public partial class UserControlForm1 : UserControl
    {
        private FormMain formMain;
        private Dictionary<Control, Rectangle> originalSizes = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private float originalFormWidth;
        private float originalFormHeight;
        private BindingSource bindingSource = new BindingSource(); // Добавляем BindingSource

        public SqlConnection sqlConnection = null;


        public UserControlForm1(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void UserControlForm1_Load(object sender, EventArgs e) // Загрузка формы
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

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11); // Шрифт всех ячеек

            // Инициализация TextBox
            txtSearch.Text = placeholderText; // Устанавливаем текст-подсказку
            txtSearch.ForeColor = Color.Gray; // Устанавливаем серый цвет текста

            dataGridView1.AllowUserToAddRows = false; //Строка для добавления данных
        }

        public void LoadData(SqlConnection connection)
        {
            try
            {
                // Запрос к базе данных для получения данных из таблицы Medications
                string query = "SELECT * FROM Medications";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Настройка BindingSource
                bindingSource.DataSource = dt;

                // Привязываем BindingSource к DataGridView
                dataGridView1.DataSource = bindingSource;

                // Проверяем наличие колонок перед их изменением
                if (dataGridView1.Columns.Count > 0)
                {
                    // Скрываем колонку MedicationID, если она существует
                    if (dataGridView1.Columns.Contains("MedicationID"))
                        dataGridView1.Columns["MedicationID"].Visible = false;

                    // Переименовываем заголовки
                    if (dataGridView1.Columns.Contains("Name"))
                        dataGridView1.Columns["Name"].HeaderText = "Название";

                    if (dataGridView1.Columns.Contains("Manufacturer"))
                        dataGridView1.Columns["Manufacturer"].HeaderText = "Производитель";

                    if (dataGridView1.Columns.Contains("Price"))
                        dataGridView1.Columns["Price"].HeaderText = "Цена";

                    if (dataGridView1.Columns.Contains("QuantityInStock"))
                        dataGridView1.Columns["QuantityInStock"].HeaderText = "Кол-во в наличии";
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Изменение заголовков столбцов
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false; // Чтобы стиль заголовков применился

            // Изменение шрифта и цвета строк
            //dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11); // Шрифт всех ячеек
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Цвет текста
            dataGridView1.DefaultCellStyle.BackColor = Color.White; // Цвет фона

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет каждой второй строки

            // Изменение границ и сетки
            dataGridView1.GridColor = Color.Purple; // Цвет линий сетки
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Границы ячеек
            dataGridView1.RowHeadersVisible = false; // Скрыть заголовки строк

            // Убрать выделение всей строки при клике
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Цвет выделения
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black; // Цвет текста при выделении

            // Изменение размера строк и столбцов
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Авторазмер колонок
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Авторазмер строк
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Высота заголовков


            //// Можно изменять цвет ячеек в зависимости от значений
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "FullName") // Если столбец называется "Status"
            //{
            //    e.CellStyle.BackColor = Color.MediumPurple;
            //    e.CellStyle.ForeColor = Color.White;
            //}
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

        private void UserControlForm1_Resize(object sender, EventArgs e)
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

                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", SizeFontGrid, FontStyle.Bold);
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", SizeFontGrid); // Шрифт всех ячеек

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

                buttonToForm1.BackColor = Color.FromArgb(185, 185, 185); // Задний фон кнопки
                buttonToForm1.FlatAppearance.BorderColor = Color.FromArgb(185, 185, 185); //Цвет обводки
                buttonToForm1.ForeColor = Color.FromArgb(0, 0, 0); // Цвет текста

                ChangeThemeOfButton(buttonToForm2);
                ChangeThemeOfButton(buttonToForm3);
                ChangeThemeOfButton(buttonToForm4);
                ChangeThemeOfButton(buttonToForm5);

                txtSearch.BackColor = Color.FromArgb(0, 0, 0); // Изменяем цвет фона поисковика на черный
                txtSearch.ForeColor = Color.FromArgb(255, 255, 255); // Изменяем цвет текста на белый

                buttonInfo.Image = Properties.Resources.about_white;
                Settings.Image = Properties.Resources.settings_white;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240); // Устанавливаем цвет фона формы

                buttonToForm1.BackColor = Color.FromArgb(70, 70, 70); // фон кнопки
                buttonToForm1.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70); //Цвет обводки
                buttonToForm1.ForeColor = Color.FromArgb(255, 255, 255); //  цвет (шрифт)

                ChangeThemeOfButton(buttonToForm2);
                ChangeThemeOfButton(buttonToForm3);
                ChangeThemeOfButton(buttonToForm4);
                ChangeThemeOfButton(buttonToForm5);


                txtSearch.BackColor = Color.FromArgb(255, 255, 255); // Изменяем цвет фона поисковика на белый
                txtSearch.ForeColor = Color.FromArgb(0, 0, 0); // Изменяем цвет текста на черный

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
                // Применяем фильтр к BindingSource
                if (string.IsNullOrEmpty(filter))
                {
                    bindingSource.Filter = null; // Сбрасываем фильтр, если строка поиска пуста
                }
                else
                {
                    // Фильтруем по названию (Name)
                    bindingSource.Filter = $"Name LIKE '{filter}%'";
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show("Ошибка при фильтрации данных: " + ex.Message);
            }
        }

        private string placeholderText = "Поисковик по названию"; // Текст-подсказка


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

        private void AddMedicines_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр UserControl
            AddMedicineControl addControl = new AddMedicineControl();

            // Подписываемся на событие добавления данных
            addControl.OnAddMedicine += (name, manufacturer, price, quantity) =>
            {
                // Проверяем, существует ли лекарство с таким же названием и производителем (без учета регистра)
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
                    {
                        connection.Open();

                        // SQL-запрос для проверки существования лекарства (без учета регистра)
                        string checkQuery = "SELECT COUNT(*) FROM Medications WHERE LOWER(Name) = LOWER(@Name) AND LOWER(Manufacturer) = LOWER(@Manufacturer)";

                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Name", name);
                            checkCommand.Parameters.AddWithValue("@Manufacturer", manufacturer);

                            int count = (int)checkCommand.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("Лекарство с таким названием и производителем уже существует.");
                                return;
                            }
                        }

                        // SQL-запрос для добавления новой записи
                        string insertQuery = "INSERT INTO Medications (Name, Manufacturer, Price, QuantityInStock) " +
                                           "VALUES (@Name, @Manufacturer, @Price, @QuantityInStock)";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@Name", name);
                            insertCommand.Parameters.AddWithValue("@Manufacturer", manufacturer);
                            insertCommand.Parameters.AddWithValue("@Price", price);
                            insertCommand.Parameters.AddWithValue("@QuantityInStock", quantity);

                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Обновляем DataGridView
                                LoadData(sqlConnection);

                                MessageBox.Show("Данные успешно добавлены.");

                                // Скрываем UserControl и Panel
                                addControl.Visible = false;
                                panelMedicine.Visible = false;
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
            panelMedicine.Controls.Clear();
            panelMedicine.Controls.Add(addControl);

            // Показываем Panel
            panelMedicine.Visible = true;
        }

        private void btnDeleteMedicine_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр UserControl
            DeleteMedicineControl deleteControl = new DeleteMedicineControl(sqlConnection, LoadData);

            // Очищаем Panel и добавляем UserControl
            panelMedicine.Controls.Clear();
            panelMedicine.Controls.Add(deleteControl);

            // Показываем Panel
            panelMedicine.Visible = true;
        }

        private void btnEditMedicine_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр UserControl
            EditMedicineControl editControl = new EditMedicineControl(sqlConnection);

            // Подписываемся на событие обновления данных
            editControl.OnMedicineUpdated += () =>
            {
                // Обновляем DataGridView
                LoadData(sqlConnection);
            };

            // Очищаем Panel и добавляем UserControl
            panelMedicine.Controls.Clear();
            panelMedicine.Controls.Add(editControl);

            // Показываем Panel
            panelMedicine.Visible = true;
        }
    }
}
