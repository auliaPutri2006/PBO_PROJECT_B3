using PBO_PROJECT_B3.view;


namespace PBO_PROJECT_B3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gambar_produk");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new V_Login());
        }
    }
}