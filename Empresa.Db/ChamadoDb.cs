using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Empresa.Models;
using System.Net.Http.Headers;

namespace Empresa.Db
{
    public class ChamadoDb
    {
        public void Create (Chamado chamado)
        {
            string sql = "INSERT INTO Chamados (IdUsuario,Email,Nome,Setor,Assunto,Descricao,DataAbertura,Prioridade) VALUES (@IdUsuario,@Email,@Nome,@Setor,@Assunto,@Descricao,@DataAbertura,@Prioridade)";
            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@IdUsuario", chamado.IdUsuario);
            cmd.Parameters.AddWithValue("@Email", chamado.Email);
            cmd.Parameters.AddWithValue("@Nome", chamado.Nome);
            cmd.Parameters.AddWithValue("@Setor", chamado.Setor);
            cmd.Parameters.AddWithValue("@Assunto", chamado.Assunto);
            cmd.Parameters.AddWithValue("@Descricao", chamado.Descricao);
            cmd.Parameters.AddWithValue("@DataAbertura", chamado.DataAbertura);
            cmd.Parameters.AddWithValue("@Prioridade", chamado.Prioridade);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void Excluir (int Id)
        {
            string sql = "DELETE FROM Chamados WHERE Id = @Id";

            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql,cn);

            cmd.Parameters.AddWithValue("@id", Id);
            cn.Open();
            cmd.ExecuteNonQuery(); 
            cn.Close();
        }
        public void Alterar(Chamado chamado)
        {
            string sql = "UPDATE Chamados SET Status=@Status, Descricao=@Descricao WHERE Id=@Id";

            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@id", chamado.Id);
            cmd.Parameters.AddWithValue("@Status", chamado.Status);
            cmd.Parameters.AddWithValue("@Descricao", chamado.Descricao);
   
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public List<Chamado> Listar()
        {
            // Pega tipo do usuário logado (precisa existir na sua classe Login)
            int tipoUsuario = Sessao.UsuarioLogado.TipoUsuario;
            string sql;

            if (tipoUsuario == 1) // Admin vê todos
            {
                sql = "SELECT Id, IdUsuario, Setor, Assunto, Descricao, DataAbertura, Prioridade, Nome, Email, Status FROM Chamados";
            }
            else // Colaborador ou Técnico só vê os próprios
            {
                sql = "SELECT Id, IdUsuario, Setor, Assunto, Descricao, DataAbertura, Prioridade, Nome, Email, Status " +
                      "FROM Chamados WHERE IdUsuario=@IdUsuario";
            }

            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql, cn);

            if (tipoUsuario != 1)
                cmd.Parameters.AddWithValue("@IdUsuario", Sessao.UsuarioLogado.Id);

            List<Chamado> lista = new List<Chamado>();

            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var chamado = new Chamado();

                chamado.Id = Convert.ToInt32(reader["Id"]);
                chamado.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                chamado.Setor = reader["Setor"].ToString();
                chamado.Assunto = reader["Assunto"].ToString();
                chamado.Descricao = reader["Descricao"].ToString();
                chamado.DataAbertura = Convert.ToDateTime(reader["DataAbertura"]);
                chamado.Prioridade = (reader["Prioridade"] != DBNull.Value && (bool)reader["Prioridade"]);
                chamado.Nome = reader["Nome"].ToString();
                chamado.Email = reader["Email"].ToString();
                chamado.Status = reader["Status"].ToString();

                lista.Add(chamado);
            }

            reader.Close();
            cn.Close();
            return lista;
         }
        
    }
}
