using Empresa.Db;
using Empresa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa.UI.Windows
{
    public partial class AberturaForm : Form
    {
        public AberturaForm()
        {
            InitializeComponent();
        }
        private void AberturaForm_Load(object sender, EventArgs e)
        {
            voltarButton.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataAberturaLabel_Click(object sender, EventArgs e)
        {
            DateTime dataAbertura = DateTime.Now;
            dataAberturaLabel.Text = dataAbertura.ToString();
        }

        private void relogioTimer_Tick(object sender, EventArgs e)
        {
            dataAberturaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Sessao.UsuarioLogado == null)
            {
                MessageBox.Show("Nenhum usuário logado. Faça login antes de abrir um chamado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var chamado = new Chamado();
            chamado.IdUsuario = Sessao.UsuarioLogado.Id;
            chamado.Nome = Sessao.UsuarioLogado.Nome;
            chamado.Email = Sessao.UsuarioLogado.Email;

            chamado.Setor = setorComboBox.SelectedItem?.ToString();
            chamado.Assunto = assuntoTextBox.Text;
            chamado.Descricao = descricaoRichTextBox.Text;
            chamado.DataAbertura = DateTime.Parse(dataAberturaLabel.Text);
            chamado.Prioridade = prioridadeCheckBox.Checked;

            var db = new Db.ChamadoDb();
            db.Create(chamado);

            MessageBox.Show("Chamado cadastrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void prioridadeCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void setorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
