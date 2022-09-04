﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeConhecimentoNooviNet6
{
    public partial class FrmAcessos : Form
    {
        DataTable dtAcessos = new DataTable();


        public FrmAcessos()
        {
            InitializeComponent();
        }

        private void FrmAcessos_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            dtAcessos = AcessosCliente.SelectAcessos();
            dgvAcessos.DataSource = dtAcessos;
            ConfigurarGrade();
            btnAplicativo.Text = "Selecione um acesso";
            if (dgvAcessos.RowCount == 0)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
            }
        }

        private void ConfigurarGrade()
        {
            // Selecionando o tipo de fonte da DGV
            dgvAcessos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvAcessos.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvAcessos.RowHeadersWidth = 25;

            // Desativando o idCliente do select
            dgvAcessos.Columns["idCliente"].HeaderText = "ID";
            dgvAcessos.Columns["idCliente"].Visible = false;

            // Desativando o idCliente do select
            dgvAcessos.Columns["idCliente1"].HeaderText = "ID";
            dgvAcessos.Columns["idCliente1"].Visible = false;

            // Desativando o idAcesso do select
            dgvAcessos.Columns["idAcesso"].HeaderText = "ID";
            dgvAcessos.Columns["idAcesso"].Visible = false;


            // Passando o nome do cliente para a DGV
            dgvAcessos.Columns["nomeCliente"].HeaderText = "CLIENTE";
            dgvAcessos.Columns["nomeCliente"].DisplayIndex = 0;
            //dgvDocumentacoes.Columns["nomeCliente"].Width = 130;
            dgvAcessos.Columns["nomeCliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAcessos.Columns["nomeCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // Passando o titulo da documentação para a DGV
            dgvAcessos.Columns["tituloAcesso"].HeaderText = "TITULO";
            // dgvDocumentacoes.Columns["titulo"].Width = 130;
            dgvAcessos.Columns["tituloAcesso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAcessos.Columns["tituloAcesso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Passando a descrição da documentação para a DGV
            dgvAcessos.Columns["login"].HeaderText = "LOGIN";
            // dgvDocumentacoes.Columns["descricao"].Width = 130;
            dgvAcessos.Columns["login"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAcessos.Columns["login"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Passando o link da documentação para a DGV
            dgvAcessos.Columns["senha"].HeaderText = "SENHA";
            // dgvDocumentacoes.Columns["link"].Width = 130;
            dgvAcessos.Columns["senha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAcessos.Columns["senha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Passando o link da documentação para a DGV
            dgvAcessos.Columns["tipoAcesso"].HeaderText = "TIPO DE ACESSO";
            // dgvDocumentacoes.Columns["link"].Width = 130;
            dgvAcessos.Columns["tipoAcesso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAcessos.Columns["tipoAcesso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ordenando a documentação por titulo de forma alfabetia e crescente(A-Z)
            dgvAcessos.Sort(dgvAcessos.Columns["nomeCliente"], ListSortDirection.Ascending);
        }

        private void FrmAcessos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtAcessos)
            {
                RowFilter = $"TITULOACESSO LIKE '%{txtProcurar.Text}%' OR NOMECLIENTE LIKE '%{txtProcurar.Text}%'"
            };

            dgvAcessos.DataSource = dv;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.ValueMember != "")
            {
            dtAcessos = AcessosCliente.SelectAcessos(Convert.ToInt32(Convert.ToString(comboBox1.SelectedValue)));
            dgvAcessos.DataSource = dtAcessos;
            ConfigurarGrade();

            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.DataSource = AcessosCliente.SelectClientesAlfabeticamente();
            comboBox1.DisplayMember = "nomeCliente";
            comboBox1.ValueMember = "idCliente";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.ShowMenu();
            Program.VerifyWindowsState(Program.GetMenu(), this.WindowState);
            Dispose();
        }

        private void btnAplicativo_Click(object sender, EventArgs e)
        {
            var tipoAcesso = dgvAcessos.Rows[dgvAcessos.CurrentCell.RowIndex].Cells["tipoAcesso"].Value.ToString();

            if (tipoAcesso.ToString().ToUpper() == "SSH")
            {
                string caminho = @$"C:\Users\{Program.GetUser()}\Desktop\putty.exe";
                if (File.Exists(caminho))
                {
                    Process.Start(caminho);
                }
                else
                {
                    Process.Start("putty.exe");

                }
            }
            else if (tipoAcesso.ToString().ToUpper() == "RDP")
            {
                Process.Start("mstsc.exe");
            }
        }


        private void dgvAcessos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var tipoAcesso = dgvAcessos.Rows[dgvAcessos.CurrentCell.RowIndex].Cells["tipoAcesso"].Value.ToString();

            if (tipoAcesso.ToString().ToUpper() == "SSH")
            {
                btnAplicativo.Text = "Abrir Putty";
                btnWinSCP.Visible = true;
            }
            else if (tipoAcesso.ToString().ToUpper() == "RDP")
            {
                btnAplicativo.Text = "Abrir RDP";
                btnWinSCP.Visible = false;
            }
            else
            {
                btnAplicativo.Text = "Nenhum Aplicativo Disponível";
            }
        }

        private void dgvAcessos_DoubleClick(object sender, EventArgs e)
        {
            int idAcesso = Convert.ToInt32(dgvAcessos.Rows[dgvAcessos.CurrentCell.RowIndex].Cells["idAcesso"].Value.ToString());
            int idCliente = Convert.ToInt32(dgvAcessos.Rows[dgvAcessos.CurrentCell.RowIndex].Cells["idCliente"].Value.ToString());
            FrmAcesso frmAcesso = new FrmAcesso("doubleClique", idAcesso, idCliente);
            frmAcesso.ShowDialog();
            Inicializar();

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int idAcesso = Convert.ToInt32(dgvAcessos.Rows[dgvAcessos.CurrentCell.RowIndex].Cells["idAcesso"].Value.ToString());
            int idCliente = Convert.ToInt32(dgvAcessos.Rows[dgvAcessos.CurrentCell.RowIndex].Cells["idCliente"].Value.ToString());
            FrmAcesso frmAcesso = new FrmAcesso("alterar", idAcesso, idCliente);
            frmAcesso.ShowDialog();
            ListarAcessos();
        }

        private void btnWinSCP_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\WinSCP\WinSCP.exe");
        }

        void ListarAcessos()
        {
            Enabled = false;
            dtAcessos = AcessosCliente.SelectAcessos();
            btnWinSCP.Visible = false;
            dgvAcessos.DataSource = dtAcessos;
            Enabled = true;
        }

        private void btnListarDocumentacao_Click(object sender, EventArgs e)
        {
            ListarAcessos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int idAcesso = Convert.ToInt32(dgvAcessos.Rows[dgvAcessos.CurrentCell.RowIndex].Cells["idAcesso"].Value.ToString());
            int idCLiente = Convert.ToInt32(dgvAcessos.Rows[dgvAcessos.CurrentCell.RowIndex].Cells["idCliente"].Value.ToString());
            FrmAcesso frmAcesso = new FrmAcesso("excluir", idAcesso, idCLiente);
            frmAcesso.ShowDialog();
            ListarAcessos();

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FrmAcesso frmAcesso = new FrmAcesso("adicionar", 0, 0);
            frmAcesso.ShowDialog();
            ListarAcessos();
        }
    }
}
