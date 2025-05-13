using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pharmacy_kiosk
{
    public partial class UserControlForm5 : UserControl
    {
        private FormMain formMain;
        private Dictionary<Control, Rectangle> originalSizes = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private float originalFormWidth;
        private float originalFormHeight;

        public UserControlForm5(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void UserControlForm5_Load(object sender, EventArgs e) // Загрузка формы
        {

            originalFormWidth = this.Width;
            originalFormHeight = this.Height;

            foreach (Control ctrl in this.Controls)
            {
                originalSizes[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);
                originalFontSizes[ctrl] = ctrl.Font.Size; // Запоминаем оригинальный размер шрифта
            }

            ChangeTheme();

            // Заполняем ComboBox типами отчётов
            comboBoxReportType.Items.Add("Продажи за период");
            comboBoxReportType.Items.Add("Топ продаваемых лекарств");
            comboBoxReportType.Items.Add("Выручка по сотрудникам");
            comboBoxReportType.SelectedIndex = 0;  // Выбираем первый элемент по умолчанию

            // Подключаем обработчик события выбора отчёта
            comboBoxReportType.SelectedIndexChanged += ComboBoxReportType_SelectedIndexChanged;

            // Инициализация Chart
            InitializeChart();

            // Загружаем отчёт по умолчанию
            GenerateReport("Топ продаваемых лекарств");
        }

        private void InitializeChart()
        {
            // Очищаем Chart
            chartReports.Series.Clear();
            chartReports.Titles.Clear();

            // Настройка внешнего вида
            chartReports.BackColor = AppSettings.ThemeApp == "dark" ? Color.FromArgb(15, 15, 15) : Color.FromArgb(240, 240, 240);
            chartReports.ChartAreas[0].BackColor = chartReports.BackColor;
            chartReports.ChartAreas[0].AxisX.LabelStyle.ForeColor = AppSettings.ThemeApp == "dark" ? Color.White : Color.Black;
            chartReports.ChartAreas[0].AxisY.LabelStyle.ForeColor = AppSettings.ThemeApp == "dark" ? Color.White : Color.Black;
        }

        private void ComboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = comboBoxReportType.SelectedItem.ToString();
            GenerateReport(reportType);
        }

        private void GenerateSalesByPeriodReport()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                connection.Open();

                string query = @"
            SELECT 
                CONVERT(VARCHAR, S.SaleDate, 104) AS SaleDate,
                SUM(S.TotalAmount) AS TotalAmount
            FROM Sales S
            GROUP BY S.SaleDate
            ORDER BY S.SaleDate";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Очищаем Chart
                chartReports.Series.Clear();
                chartReports.Titles.Clear();

                // Добавляем заголовок
                chartReports.Titles.Add("Продажи за период");

                // Создаем серию данных
                Series series = new Series("Продажи");
                series.ChartType = SeriesChartType.Column;

                // Заполняем данными
                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["SaleDate"], row["TotalAmount"]);
                }

                // Добавляем серию на график
                chartReports.Series.Add(series);
            }
        }

        private void GenerateTopMedicationsReport()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                string query = @"
                SELECT TOP 10  -- Ограничиваем выборку топ-10 препаратов
                     M.Name AS MedicationName,
                        SUM(SD.QuantitySold) AS TotalSold
                FROM SaleDetails SD
                JOIN Medications M ON SD.MedicationID = M.MedicationID 
                GROUP BY M.Name
                ORDER BY TotalSold DESC"; // Сортируем по количеству продаж

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Очищаем Chart
                chartReports.Series.Clear();
                chartReports.Titles.Clear();

                // Добавляем заголовок
                chartReports.Titles.Add("Топ продаваемых лекарств");

                // Создаем серию данных
                Series series = new Series("Топ лекарств");
                series.ChartType = SeriesChartType.Pie;

                // Заполняем данными
                foreach (DataRow row in dt.Rows)
                {
                    // Добавляем точку данных
                    DataPoint point = new DataPoint();
                    point.SetValueXY(row["MedicationName"], row["TotalSold"]);

                    // Добавляем подпись с названием препарата и количеством продаж
                    point.Label = $"{row["MedicationName"]}\n{row["TotalSold"]} шт.";  // Название и количество
                    point.Font = new Font("Arial", 10, FontStyle.Bold);  // Настройка шрифта
                    point.LabelForeColor = Color.Black;  // Цвет текста подписей

                    series.Points.Add(point);
                }

                // Добавляем серию на график
                chartReports.Series.Add(series);

                // Настройка отображения подписей
                series.IsValueShownAsLabel = true;  // Показывать значения на диаграмме
                series["PieLabelStyle"] = "Outside";  // Подписи вне секторов
                series["PieLineColor"] = "Black";  // Цвет линий, соединяющих подписи с секторами
            }
        }

        private void GenerateRevenueByEmployeesReport()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                connection.Open();

                string query = @"
            SELECT 
                E.FullName AS EmployeeName,
                SUM(S.TotalAmount) AS TotalRevenue
            FROM Sales S
            JOIN Employees E ON S.EmployeeID = E.EmployeeID
            GROUP BY E.FullName
            ORDER BY TotalRevenue DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Очищаем Chart
                chartReports.Series.Clear();
                chartReports.Titles.Clear();

                // Добавляем заголовок
                chartReports.Titles.Add("Выручка по сотрудникам");

                // Создаем серию данных
                Series series = new Series("Выручка");
                series.ChartType = SeriesChartType.Bar;

                // Заполняем данными
                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["EmployeeName"], row["TotalRevenue"]);
                }

                // Добавляем серию на график
                chartReports.Series.Add(series);
            }
        }

        private void GenerateReport(string reportType)
        {
            switch (reportType)
            {
                case "Продажи за период":
                    GenerateSalesByPeriodReport();
                    break;
                case "Топ продаваемых лекарств":
                    GenerateTopMedicationsReport();
                    break;
                case "Выручка по сотрудникам":
                    GenerateRevenueByEmployeesReport();
                    break;
                default:
                    MessageBox.Show("Выберите тип отчёта!");
                    break;
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

        private void ButtonToForm4_Click(object sender, EventArgs e)
        {
            UserControlForm4 userControlForm4 = new UserControlForm4(formMain);
            formMain.ShowControl(userControlForm4);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            ProgramInfo.ShowInfo(); // Вызов статического метода для отображения информации
        }


        private void UserControlForm5_Resize(object sender, EventArgs e)
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

                buttonToForm5.BackColor = Color.FromArgb(185, 185, 185); // Задний фон кнопки
                buttonToForm5.FlatAppearance.BorderColor = Color.FromArgb(185, 185, 185); //Цвет обводки
                buttonToForm5.ForeColor = Color.FromArgb(0, 0, 0); // Цвет текста

                ChangeThemeOfButton(buttonToForm1);
                ChangeThemeOfButton(buttonToForm2);
                ChangeThemeOfButton(buttonToForm3);
                ChangeThemeOfButton(buttonToForm4);

                buttonInfo.Image = Properties.Resources.about_white;
                Settings.Image = Properties.Resources.settings_white;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240); // Устанавливаем цвет фона формы

                buttonToForm5.BackColor = Color.FromArgb(70, 70, 70); // фон кнопки
                buttonToForm5.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70); //Цвет обводки
                buttonToForm5.ForeColor = Color.FromArgb(255, 255, 255); //  цвет (шрифт)

                ChangeThemeOfButton(buttonToForm1);
                ChangeThemeOfButton(buttonToForm2);
                ChangeThemeOfButton(buttonToForm3);
                ChangeThemeOfButton(buttonToForm4);

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
