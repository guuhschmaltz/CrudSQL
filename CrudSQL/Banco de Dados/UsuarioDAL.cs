using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CrudSQL.Banco_de_Dados
{
    public class UsuarioDAL
    {
        private readonly string _connectionString;
        public UsuarioDAL()
        {
            //Aqui irá vir sua string de conexão//
            //_connectionString = Properties.Settings.Default.DBExemploConnectionString;
        }

        public void Atualizar(Usuario u)
        {
            var conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                var sqlQuery = "UPDATE TB_USUARIO SET NOME = @nome, CIDADE = @cidade, CARGO = @cargo WHERE NOME = @nome";
                var cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.Add(new SqlParameter("@nome", u.Nome));
                cmd.Parameters.Add(new SqlParameter("@cidade", u.Cidade));
                cmd.Parameters.Add(new SqlParameter("@cargo", u.Cargo));
                cmd.ExecuteNonQuery();
            }
            catch
            {

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public void Deletar(Usuario u)
        {
            var conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                var sqlQuery = "DELETE FROM TB_USUARIO WHERE NOME = @nome AND CIDADE = @cidade AND CARGO = @cargo";
                var cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.Add(new SqlParameter("@nome", u.Nome));
                cmd.Parameters.Add(new SqlParameter("@cidade", u.Cidade));
                cmd.Parameters.Add(new SqlParameter("@cargo", u.Cargo));
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        public void Inserir(Usuario u)
        {
            var conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                var sqlQuery = "INSERT INTO TB_USUARIO (NOME,CIDADE,CARGO) VALUES (@nome,@cidade,@cargo)";
                var cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.Add(new SqlParameter("@nome", u.Nome));
                cmd.Parameters.Add(new SqlParameter("@cidade", u.Cidade));
                cmd.Parameters.Add(new SqlParameter("@cargo", u.Cargo));
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }

        }

        public List<Usuario> ListarTodos()
        {
            var conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                var sqlQuery = "SELECT * FROM TB_USUARIO";
                var cmd = new SqlCommand(sqlQuery, conn);
                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);


                var usuarios = new List<Usuario>();
                foreach (DataRow row in dt.Rows)
                {
                    usuarios.Add(new Usuario
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        Nome = row["NOME"].ToString(),
                        Cargo = row["CARGO"].ToString(),
                        Cidade = row["CIDADE"].ToString()
                    });
                }
                return usuarios;
            }
            catch
            {

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public List<Usuario> ListarUsuario(string nome)
        {
            var conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                var sqlQuery = $"SELECT * FROM TB_USUARIO WHERE NOME LIKE '%{nome}%'";
                var cmd = new SqlCommand(sqlQuery, conn);
                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);


                var usuarios = new List<Usuario>();
                foreach (DataRow row in dt.Rows)
                {
                    usuarios.Add(new Usuario
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        Nome = row["NOME"].ToString(),
                        Cargo = row["CARGO"].ToString(),
                        Cidade = row["CIDADE"].ToString()
                    });
                }
                return usuarios;
            }
            catch
            {

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
