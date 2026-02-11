using Empresa.Db;
using Empresa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Empresa.Db.LoginDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Empresa.UI.Windows
{
    public partial class AcompanharForm : Form
    {
        private int tipoUsuario;
        public AcompanharForm(int tipoUsuario)
        {
            InitializeComponent();
            this.tipoUsuario = tipoUsuario;
            voltarButton.Visible = false;
            ExibirGrid();
            AjustarBotoes();
        }


        private void CarregarChamados()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Empresa.PIM; Integrated Security = True; Pooling = False"))
                {
                    string sql = "SELECT Id, Nome, Email, Setor, Assunto, Descricao, DataAbertura, Prioridade, Status FROM Chamados";

                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    listaDataGridView.DataSource = dt; // joga o resultado na grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar chamados: " + ex.Message);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();

        }
        private void AjustarBotoes()
        {
            if (tipoUsuario == LoginDb.TipoUsuario.Colaborador)
            {
                atualizarButton.Visible = false; // Colaborador não vê
                visualizarButton.Visible = true;      // Pode abrir chamados
                nomeTextBox.ReadOnly = true;  // 
                emailTextBox.ReadOnly = true; 
                setorTextBox.ReadOnly = true;    //Colaborador não pode escrever nos campo//
                assuntoTextBox.ReadOnly = true; 
                statusTextBox.ReadOnly = true;  
                descricaoRichTextBox.ReadOnly = true;  //
            }
            else if (tipoUsuario == LoginDb.TipoUsuario.Tecnico)
            {
                atualizarButton.Visible = false; // Tecnico vê
                visualizarButton.Visible = true;      // Pode abrir chamados
                nomeTextBox.ReadOnly = true;
                emailTextBox.ReadOnly = true;
                setorTextBox.ReadOnly = true;
                assuntoTextBox.ReadOnly = true;



            }
        }
        private void ExibirGrid()
        {

            var db = new ChamadoDb();
            listaDataGridView.DataSource = db.Listar();
            listaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listaDataGridView.ReadOnly = true;
            listaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listaDataGridView.Dock = DockStyle.Fill;
            listaDataGridView.RowHeadersVisible = false;
            listaDataGridView.EnableHeadersVisualStyles = true;
            listaDataGridView.Columns["Id"].Visible = false;
            listaDataGridView.Columns["IdUsuario"].Visible = false;
            listaDataGridView.Columns["Nome"].Visible = true;
            listaDataGridView.Columns["Email"].Visible = false;
            listaDataGridView.Columns["Descricao"].Visible = false;
            detalhesPanel.Visible = false;
            atualizarButton.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AcompanharForm_Load(object sender, EventArgs e)
        {
            ExibirGrid();
            listaDataGridView.AllowUserToAddRows = false;
        }

        private void visualizarButton_Click(object sender, EventArgs e)
        {
            if (listaDataGridView.CurrentRow == null)
                return;

            detalhesPanel.Visible = true;
            visualizarButton.Visible = false;
            listaDataGridView.Visible = false;
            voltarButton.Visible = true;

            // pega o chamado selecionado
            Chamado chamado = (Chamado)listaDataGridView.CurrentRow.DataBoundItem;

            detalhesPanel.Dock = DockStyle.Fill;
            nomeTextBox.Text = chamado.Nome;
            emailTextBox.Text = chamado.Email;
            setorTextBox.Text = chamado.Setor;
            assuntoTextBox.Text = chamado.Assunto;
            descricaoRichTextBox.Text = chamado.Descricao;
            statusTextBox.Text = chamado.Status;

            atualizarButton.Visible = tipoUsuario == LoginDb.TipoUsuario.Tecnico;
        }



        private void voltarButton_Click(object sender, EventArgs e)
        {
            detalhesPanel.Visible = false;
            voltarButton.Visible = false;
            listaDataGridView.Visible = true;

            ExibirGrid();
            AjustarBotoes(); // aqui sim
        }


        private void listaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deletarButton_Click(object sender, EventArgs e)
        {
            if (listaDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um chamado para deletar!");
                return;
            }

            // Pega o ID da linha selecionada (coluna Id deve existir na grid)
            int idChamado = Convert.ToInt32(listaDataGridView.SelectedRows[0].Cells["Id"].Value);

            DialogResult confirm = MessageBox.Show(
                "Tem certeza que deseja deletar este chamado?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Chama seu método já existente
                    var chamadoDb = new ChamadoDb();
                    chamadoDb.Excluir(idChamado);

                    MessageBox.Show("Chamado deletado com sucesso!");

                    CarregarChamados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar chamado: " + ex.Message);
                }
            }
        }

        private void atualizarButton_Click(object sender, EventArgs e)
        {
            var chamado = new Chamado();
            chamado.Id = Convert.ToInt32(listaDataGridView.CurrentRow.Cells["Id"].Value);
            chamado.Descricao = descricaoRichTextBox.Text;
            chamado.Status = statusTextBox.Text;

            MessageBox.Show("Chamado alterado com sucesso!");

            var db = new ChamadoDb();
            db.Alterar(chamado);
        }

        private void nomeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
