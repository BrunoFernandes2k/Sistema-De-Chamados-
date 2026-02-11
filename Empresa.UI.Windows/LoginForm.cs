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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Esconde o formulário de login
            ResetarSenhaForm resetarSenhaForm = new ResetarSenhaForm();
            resetarSenhaForm.FormClosed += (s, args) => this.Show(); // Quando fechar o cadastro, mostra o formulário de login
            resetarSenhaForm.Show(); 
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string usuario = usuarioTextBox.Text.Trim();
            string senha = senhaTextBox.Text.Trim();
            var db = new LoginDb();

            var usuarioLogado = db.Autenticar(usuario, senha);

            if (usuarioLogado == null)
            {
                MessageBox.Show("Usuário ou senha incorretos. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Sessao.UsuarioLogado = usuarioLogado;


            MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            TelaInicialForm telaInicialForm = new TelaInicialForm(usuarioLogado.TipoUsuario);
            telaInicialForm.FormClosed += (s, args) => this.Show(); // Quando fechar o cadastro, mostra o formulário de login
            telaInicialForm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Esconde o formulário de login
            CadastroForm cadastroForm = new CadastroForm();
            cadastroForm.FormClosed += (s, args) => this.Show(); // Quando fechar o cadastro, mostra o formulário de login
            cadastroForm.Show();
        }

        private void Mostrar_Click(object sender, EventArgs e)
        {
            
          
            
        }

        private void senhaTextBox_TextChanged(object sender, EventArgs e)
        {
            senhaTextBox.PasswordChar = '*';
        }

        private void MostrarSenhaBox1_CheckedChanged(object sender, EventArgs e)
        {
            senhaTextBox.PasswordChar = MostrarSenhaBox1.Checked ? '\0' : '*';
        }

        private void usuarioTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
