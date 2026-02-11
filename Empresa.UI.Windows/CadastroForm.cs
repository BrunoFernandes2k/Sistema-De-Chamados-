using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Empresa.Models;
using Empresa.Db;

namespace Empresa.UI.Windows
{
    public partial class CadastroForm : Form
    {
        public CadastroForm()
        {
            InitializeComponent();
        }
        private void CadastroForm_Load(object sender, EventArgs e)
        {
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string senha = senhaTextBox.Text;
            string confirmarSenha = confirmarSenhaTextBox.Text;
            string nome = nomeTextBox.Text;
            string usuario = usuarioTextBox.Text;
            string email = emailTextBox.Text;

            if (senha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(nome))
            {

                MessageBox.Show("Por favor, preencha este campo com o nome!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Por favor, preencha este campo com o Usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, preencha este campo com o email!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha este campo com a senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(confirmarSenha))
            {
                MessageBox.Show("Por favor, confirme sua senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            var login = new Login();
            login.Nome = nomeTextBox.Text;
            login.Email = emailTextBox.Text;
            login.Usuario = usuarioTextBox.Text;
            login.Senha = senhaTextBox.Text;

            if (tipoUsuarioComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo de usuário!");
                return;
            }
            login.TipoUsuario = tipoUsuarioComboBox.SelectedIndex;

            var db = new Db.LoginDb();
            db.Create(login);

            MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void tipoUsuarioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nomeTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void confirmarSenhaTextBox_TextChanged(object sender, EventArgs e)
        {
            confirmarSenhaTextBox.PasswordChar = '*';
        }

        private void senhaTextBox_TextChanged(object sender, EventArgs e)
        {
            senhaTextBox.PasswordChar = '*';
        }
    }
}
