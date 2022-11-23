using System.Diagnostics;
using System.IO;

namespace BaseDeConhecimentoNooviNet6
{
    internal static class Program
    {
        public static Menu menu;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {
                BancoSQLite.AdicionarUsuario();
                CreateSqLitePath();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(menu = new Menu());
                // Application.Run(new frmEditorDeTexto());
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                BancoSQLite.RemoverUsuario();
            }
        }


        private static void CreateSqLitePath()
        {
            string path = @$"C:\Users\{GetUser()}\Documents\BaseDeConhecimentoNoovi\SQLite";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string GetUser()
        {
            return System.Windows.Forms.SystemInformation.UserName;
        }

        public static void HideMenu()
        {
            menu.Hide();
        }

        public static Form GetMenu()
        {
            return menu;
        }

        public static void ShowMenu()
        {
            menu.Show();
        }

        public static void MaximizeMenu()
        {
            menu.WindowState = FormWindowState.Maximized;
        }

        public static void NormalMenu()
        {
            menu.WindowState = FormWindowState.Normal;
        }


        /// <summary>
        /// Verifica o estado da janela atual e abre a nova no mesmo formato
        /// </summary>
        /// <param name="form">Form que será aberto</param>
        /// <param name="formWindowState">Estado em que o form deverá ser aberto</param>
        public static void VerifyWindowsState(Form form, FormWindowState formWindowState)
        {
            if (formWindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

    }
}