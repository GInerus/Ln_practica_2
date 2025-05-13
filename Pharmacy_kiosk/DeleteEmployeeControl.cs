using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacy_kiosk
{
    public partial class DeleteEmployeeControl: UserControl
    {
        private SqlConnection sqlConnection;
        private Action<SqlConnection> loadData; // Делегат для обновления данных
        public DeleteEmployeeControl(SqlConnection connection, Action<SqlConnection> loadData)
        {
            InitializeComponent();
            this.sqlConnection = connection;
            this.loadData = loadData;
            LoadEmployees();
        }

        // Загружаем сотрудников в ComboBox
        private void LoadEmployees()
        {
            try
            {
                string query = "SELECT EmployeeID, FullName, Position FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Заполняем ComboBox
                comboBoxEmployee.DisplayMember = "Display"; // Отображаемое значение
                comboBoxEmployee.ValueMember = "EmployeeID"; // Значение для удаления

                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row["EmployeeID"]}: {row["FullName"]} ({row["Position"]})";
                    comboBoxEmployee.Items.Add(new { Display = displayText, EmployeeID = row["EmployeeID"] });
                }

                if (comboBoxEmployee.Items.Count > 0)
                {
                    comboBoxEmployee.SelectedIndex = 0; // Выбираем первый элемент
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления из базы.");
                return;
            }

            // Получаем ID выбранного препарата
            int EmployeeID = (int)((dynamic)comboBoxEmployee.SelectedItem).EmployeeID;

            // Подтверждение удаления
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этого сотрудника?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Открываем соединение, если оно закрыто
                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        int rowsAffected = command.ExecuteNonQuery();

                        // Вызываем метод для обновления данных
                        loadData?.Invoke(sqlConnection);


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Сотрудник успешно удален.");
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
                            MessageBox.Show("Сотрудник не был удален.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении сотрудника: " + ex.Message);
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
