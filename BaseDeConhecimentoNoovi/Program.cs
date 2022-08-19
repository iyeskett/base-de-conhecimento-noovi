using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNoovi
{
    static class Program
    {
        static Menu menu;
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Banco.AdicionarUsuario();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(menu = new Menu());
            Banco.RemoverUsuario();
        }

        public static void HideMenu()
        {
            menu.Hide();    
        }

        public static void ShowMenu()
        {
            menu.Show();
        }
    }
}
