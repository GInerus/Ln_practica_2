using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy_kiosk
{
    public partial class FormMain : Form
    {
        public SqlConnection sqlConnection = null;

        private UserControlForm1 userControlForm1;
        private UserControlForm2 userControlForm2;
        private UserControlForm3 userControlForm3;
        private UserControlForm4 userControlForm4;
        private UserControlForm5 userControlForm5;

        public FormMain()
        {
            InitializeComponent();

            //Инициализация UserControl'ов
            userControlForm1 = new UserControlForm1(this);

            //Изначально показываем первый экран(например, UserControlForm1)
            ShowControl(userControlForm1);
        }

        //Метод для отображения нужного UserControl в Panel
        public void ShowControl(UserControl control)
        {
            // Очищаем панель контейнер
            panelContainer.Controls.Clear();
            // Добавляем новый UserControl
            panelContainer.Controls.Add(control);
            control.Dock = DockStyle.Fill;  // Растягиваем на весь доступный размер

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
            sqlConnection.Open();
        }
    }
}
