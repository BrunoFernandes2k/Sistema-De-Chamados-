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
using static Empresa.Db.LoginDb;

namespace Empresa.UI.Windows
{
    public partial class TelaInicialForm : Form
    {
        private int tipoUsuario;
        public TelaInicialForm(int tipoUsuario)
        {
            InitializeComponent();
            this.tipoUsuario = tipoUsuario;
            AjustarBotoes();
        }

        private void AjustarBotoes()
        {
            if (tipoUsuario == LoginDb.TipoUsuario.Colaborador)
            {
                abrirChamadoButton.Visible = true; // Colaborador não vê
                acompanharChamadoButton.Visible = true;      // Pode abrir chamados
                
            }
            else if (tipoUsuario == LoginDb.TipoUsuario.Tecnico)
            {
                abrirChamadoButton.Visible = false; // Colaborador não vê
                acompanharChamadoButton.Visible = true;      // Pode abrir chamados
            }
        }

        private void abrirChamadoButton_Click(object sender, EventArgs e)
        {
            
            this.Hide(); // Esconde o formulário de login
            AberturaForm aberturaForm = new AberturaForm();
            aberturaForm.FormClosed += (s, args) => this.Show(); 
            aberturaForm.Show();

        }

        private void TelaInicialForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void acompanharChamadoButton_Click(object sender, EventArgs e)
        {
            this.Hide(); // Esconde o formulário de login

            // Supondo que você tenha a informação do usuário logado
            int tipoUsuarioLogado = Sessao.UsuarioLogado.TipoUsuario;

            AcompanharForm acompanharForm = new AcompanharForm(tipoUsuarioLogado);

            acompanharForm.FormClosed += (s, args) => this.Show(); // Quando fechar, mostra novamente
            acompanharForm.Show();
        }

    }
}
