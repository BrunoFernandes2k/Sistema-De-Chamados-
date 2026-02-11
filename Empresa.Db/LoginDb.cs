using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Empresa.Models;
using System.Net.Http.Headers;
using System.Security.Authentication;


namespace Empresa.Db
{
    public class LoginDb
    {
        public static class TipoUsuario
        {
            public const int Colaborador = 0;
            public const int Tecnico = 1;
        }

        public void Create(Login login)
        {
            // Código para incluir cliente

            string sql = "INSERT INTO Usuarios (Nome,Usuario,Email,Senha,TipoUsuario) VALUES (@Nome,@Usuario,@Email,@Senha,@TipoUsuario)";
            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Nome", login.Nome);
            cmd.Parameters.AddWithValue("@Usuario", login.Usuario);
            cmd.Parameters.AddWithValue("@Email", login.Email);
            cmd.Parameters.AddWithValue("@Senha",login.Senha);
            cmd.Parameters.AddWithValue("@TipoUsuario",login.TipoUsuario);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public Login Autenticar(string usuario, string senha)
        {
            string sql = @"SELECT Id, Nome, Usuario, Email, Senha, TipoUsuario 
                   FROM Usuarios 
                   WHERE Usuario=@Usuario AND Senha=@Senha";

            using (var cn = new SqlConnection(Db.Conexao))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Senha", senha);

                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Login
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Usuario = reader["Usuario"].ToString(),
                            Email = reader["Email"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            TipoUsuario = Convert.ToInt32(reader["TipoUsuario"])
                        };
                    }
                }
            }

            return null;
        }




        public bool ResetarSenha(string usuario, string email, string senha)
        {
            string sql = "UPDATE Usuarios SET Senha=@Senha WHERE Usuario=@Usuario AND Email=@Email";

            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql, cn);
            {
                cmd.Parameters.AddWithValue("@Senha", senha);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Email", email);

                cn.Open();
                int count = cmd.ExecuteNonQuery();
                return count > 0;
            }
        }
    }
}
