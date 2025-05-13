using System.Windows.Forms;

namespace Pharmacy_kiosk
{
    public static class ProgramInfo
    {
        public static string Title => "Лекарственный уголок";
        public static string Version => "Beta 0.5.1";
        public static string Author => "Исаев Г. И.";
        public static string Description => "Аптечный киоск: номенклатура лекарств, работники аптеки, покупатели, журнал регистрации продаж.";

        public static void ShowInfo()
        {
            string programInfo = $"Название программы: {Title}\n" +
                                 $"Версия: {Version}\n" +
                                 $"Автор: {Author}\n" +
                                 $"\n" +
                                 $"Описание: {Description}";

            // Показываем информацию в диалоговом окне
            MessageBox.Show(programInfo, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
