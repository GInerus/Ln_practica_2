using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacy_kiosk
{
    public partial class EditMedicineControl : UserControl
    {
        public event Action OnMedicineUpdated; // Событие для уведомления об обновлении

        private SqlConnection sqlConnection;
        private int medicationID;

        public EditMedicineControl(SqlConnection connection)
        {
            InitializeComponent();
            this.sqlConnection = connection;
            LoadMedicines();
        }

        // Загружаем препараты в ComboBox
        private void LoadMedicines()
        {
            try
            {
                string query = "SELECT MedicationID, Name, Manufacturer FROM Medications";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Заполняем ComboBox
                comboBoxMedicines.DisplayMember = "Display"; // Отображаемое значение
                comboBoxMedicines.ValueMember = "MedicationID"; // Значение для изменения

                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row["MedicationID"]}: {row["Name"]} ({row["Manufacturer"]})";
                    comboBoxMedicines.Items.Add(new { Display = displayText, MedicationID = row["MedicationID"] });
                }

                if (comboBoxMedicines.Items.Count > 0)
                {
                    comboBoxMedicines.SelectedIndex = 0; // Выбираем первый элемент
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        // Обработчик выбора препарата в ComboBox
        private void comboBoxMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMedicines.SelectedItem == null)
                return;

            // Получаем ID выбранного препарата
            medicationID = (int)((dynamic)comboBoxMedicines.SelectedItem).MedicationID;

            // Загружаем данные выбранного препарата
            LoadMedicineDetails(medicationID);
        }

        // Загружаем данные выбранного препарата
        private void LoadMedicineDetails(int medicationID)
        {
            try
            {
                string query = "SELECT Name, Manufacturer, Price, QuantityInStock FROM Medications WHERE MedicationID = @MedicationID";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@MedicationID", medicationID);

                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["Name"].ToString();
                            txtManufacturer.Text = reader["Manufacturer"].ToString();
                            txtPrice.Text = reader["Price"].ToString();
                            txtQuantity.Text = reader["QuantityInStock"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных препарата: " + ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        // Обработчик кнопки "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtManufacturer.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            // Парсим числовые значения
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Некорректное значение цены.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Некорректное значение количества.");
                return;
            }

            // Обновляем данные в базе
            try
            {
                string query = "UPDATE Medications SET Name = @Name, Manufacturer = @Manufacturer, Price = @Price, QuantityInStock = @QuantityInStock WHERE MedicationID = @MedicationID";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Manufacturer", txtManufacturer.Text);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@QuantityInStock", quantity);
                    command.Parameters.AddWithValue("@MedicationID", medicationID);

                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные успешно обновлены.");

                        // Вызываем событие для уведомления об обновлении
                        OnMedicineUpdated?.Invoke();

                        // Скрываем UserControl и Panel
                        this.Visible = false;

                        // Получаем родительскую панель и скрываем её
                        if (this.Parent is Panel parentPanel)
                        {
                            parentPanel.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данные не были обновлены.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении данных: " + ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        // Обработчик кнопки "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Скрываем UserControl и Panel
            this.Visible = false;

            // Получаем родительскую панель и скрываем её
            if (this.Parent is Panel parentPanel)
            {
                parentPanel.Visible = false;
            }
        }

        // Переопределяем метод OnPaint для рисования рамки
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Рисуем рамку вокруг UserControl
            using (Pen pen = new Pen(Color.Black, 5)) // Цвет и толщина рамки
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }
    }
}