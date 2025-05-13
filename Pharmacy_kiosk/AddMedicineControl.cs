using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pharmacy_kiosk
{
    public partial class AddMedicineControl : UserControl
    {
        // Событие для уведомления о добавлении данных
        public event Action<string, string, decimal, int> OnAddMedicine;

        public AddMedicineControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

            // Вызываем событие с данными
            OnAddMedicine?.Invoke(txtName.Text, txtManufacturer.Text, price, quantity);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Очищаем поля
            txtName.Text = string.Empty;
            txtManufacturer.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;

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
