using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacy_kiosk
{
    public partial class DeleteMedicineControl : UserControl
    {
        private SqlConnection sqlConnection;
        private Action<SqlConnection> loadData; // Делегат для обновления данных
        public DeleteMedicineControl(SqlConnection connection, Action<SqlConnection> loadData)
        {
            InitializeComponent();
            this.sqlConnection = connection;
            this.loadData = loadData;
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
                comboBoxMedicines.ValueMember = "MedicationID"; // Значение для удаления

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

        // Обработчик кнопки "Удалить"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxMedicines.SelectedItem == null)
            {
                MessageBox.Show("Выберите препарат для удаления.");
                return;
            }

            // Получаем ID выбранного препарата
            int medicationID = (int)((dynamic)comboBoxMedicines.SelectedItem).MedicationID;

            // Подтверждение удаления
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот препарат?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Открываем соединение, если оно закрыто
                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    string query = "DELETE FROM Medications WHERE MedicationID = @MedicationID";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@MedicationID", medicationID);
                        int rowsAffected = command.ExecuteNonQuery();

                        // Вызываем метод для обновления данных
                        loadData?.Invoke(sqlConnection);


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Препарат успешно удален.");
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
                            MessageBox.Show("Препарат не был удален.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении препарата: " + ex.Message);
                }
                finally
                {
                    // Закрываем соединение после выполнения запроса
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
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