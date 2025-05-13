using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacy_kiosk
{
    public partial class AddEmployeeControl: UserControl
    {
        // Событие для уведомления о добавлении данных
        public event Action<string, string, string> OnAddEmployee;

        public AddEmployeeControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPosition.Text) ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            // Вызываем событие с данными
            OnAddEmployee?.Invoke(txtFullName.Text, txtPosition.Text, txtContactNumber.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Очищаем поля
            txtFullName.Text = string.Empty;
            txtPosition.Text = string.Empty;
            txtContactNumber.Text = string.Empty;

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
