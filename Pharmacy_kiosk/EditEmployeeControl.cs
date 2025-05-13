using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Pharmacy_kiosk
{
    public partial class EditEmployeeControl : UserControl
    {
        public event Action OnEmployeeUpdated; // Событие для уведомления об обновлении
        private SqlConnection sqlConnection;
        private int employeeID;

        public EditEmployeeControl(SqlConnection connection)
        {
            InitializeComponent();
            this.sqlConnection = connection;
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                string query = "SELECT EmployeeID, FullName, Position FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Заполняем ComboBox
                comboBoxEmployees.DisplayMember = "Display"; // Отображаемое значение
                comboBoxEmployees.ValueMember = "EmployeeID"; // Значение для изменения

                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row["EmployeeID"]}: {row["FullName"]} ({row["Position"]})";
                    comboBoxEmployees.Items.Add(new { Display = displayText, EmployeeID = row["EmployeeID"] });
                }

                if (comboBoxEmployees.Items.Count > 0)
                {
                    comboBoxEmployees.SelectedIndex = 0; // Выбираем первый элемент
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void comboBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEmployees.SelectedItem == null)
                return;

            // Получаем ID выбранного препарата
            employeeID = (int)((dynamic)comboBoxEmployees.SelectedItem).EmployeeID;

            // Загружаем данные выбранного препарата
            LoadEmployeeDetails(employeeID);
        }

        private void LoadEmployeeDetails(int employeeID)
        {
            try
            {
                string query = "SELECT FullName, Position, ContactNumber FROM Employees WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFullName.Text = reader["FullName"].ToString();
                            txtPosition.Text = reader["Position"].ToString();
                            txtContactNumber.Text = reader["ContactNumber"].ToString();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            {
                // Проверяем, что все поля заполнены
                if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPosition.Text) ||
                    string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    MessageBox.Show("Все поля должны быть заполнены.");
                    return;
                }

                // Обновляем данные в базе
                try
                {
                    string query = "UPDATE Employees SET FullName = @FullName, Position = @Position, ContactNumber = @ContactNumber, WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        command.Parameters.AddWithValue("@Position", txtPosition.Text);
                        command.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        if (sqlConnection.State != ConnectionState.Open)
                        {
                            sqlConnection.Open();
                        }

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные успешно обновлены.");

                            // Вызываем событие для уведомления об обновлении
                            OnEmployeeUpdated?.Invoke();

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
