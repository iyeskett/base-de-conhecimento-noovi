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
                Banco.AdicionarUsuario();
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
                Banco.RemoverUsuario();
            }
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

        public static void VerifyWindowsState(Form form, FormWindowState formWindowState)
        {
            if (formWindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

    }
}