using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNooviNet6
{
    public partial class FrmConexão : Form
    {
        string Tipo;
        public string Resultado;
        public FrmConexão(string tipo)
        {
            Tipo = tipo;
            InitializeComponent();
        }

        private void FrmConexão_Load(object sender, EventArgs e)
        {
        }


        private void FrmConexão_Shown(object sender, EventArgs e)
        {
            if (Tipo == "ping")
            {
                lblConexao.Text = "Testando conexão, aguarde.";
                PingReply ping = new Ping().Send("192.168.138.25");
                Resultado = ping.Status.ToString();
                Dispose();
            }
        }
    }
}
