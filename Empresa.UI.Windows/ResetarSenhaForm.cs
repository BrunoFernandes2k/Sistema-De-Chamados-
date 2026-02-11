using Empresa.Db;
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
    public partial class ResetarSenhaForm : Form
    {
        public ResetarSenhaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }

        private void finalizarButton_Click(object sender, EventArgs e)
        {
            string usuario = usuarioResetTextBox.Text;
            string email = emailResetTextBox.Text; 
            string novaSenha = novaSenhaTextBox.Text;

            var db = new LoginDb();
            bool sucesso = db.ResetarSenha(usuario, email, novaSenha);

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Por favor, preencha este campo com o Usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, preencha este campo com o Email!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(novaSenha))
            {
                MessageBox.Show("Por favor, preencha este campo com a Nova Senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }









            if (sucesso) 
            { 
                MessageBox.Show("Senha alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Usuário ou e-mail não encontrados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void usuarioResetTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MostrarSenhacheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            novaSenhaTextBox.PasswordChar = MostrarSenhacheckBox1.Checked ? '\0' : '*';
        }

        private void novaSenhaTextBox_TextChanged(object sender, EventArgs e)
        {
            novaSenhaTextBox.PasswordChar = '*';
        }
    }
}
