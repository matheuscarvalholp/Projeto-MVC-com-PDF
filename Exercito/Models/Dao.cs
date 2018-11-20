using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercito.Models
{
    public class Dao
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-Q6I8LRTT;Initial Catalog=Alistamento;Integrated Security=True");

        public void InserirLogin(string Usuario, string Login, string Senha, string Funcao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO [dbo].[Login]
                             ([Usuario]
                             ,[Login]
                             ,[Senha]
                             ,[Funcao]) 
                             VALUES(@Usuario,@Login,@Senha,@Funcao)";
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Login", Login);
                cmd.Parameters.AddWithValue("@Senha", Senha);
                cmd.Parameters.AddWithValue("@Funcao", Funcao);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void InserirArquivo(int Id_Usuario, byte[] Pdf, string Status)
        {
            try

            {
                connection.Close();
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO [dbo].[Cadastro]
                              ([Id_Usuario]
                              ,[Pdf]
                              ,[Status])
                             VALUES(@Id_Usuario,@Pdf,@Status)";
                cmd.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
                cmd.Parameters.AddWithValue("@Pdf", Pdf);
                cmd.Parameters.AddWithValue("@Status", Status);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Cadastro> retornarArquivo(int id)
        {
            connection.Close();
            connection.Open();
            List<Cadastro> arquivos = new List<Cadastro>();
            string query = @"SELECT [Id]
                            ,[Id_Usuario]
                            ,[Pdf]
                            ,[Status]
                        FROM [dbo].[Cadastro]";
            if (id != 0 || id == 4)
            {
                query += "WHERE Id_Usuario = " + id + "";
            }
            SqlCommand cmd = new SqlCommand(query, connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cadastro arquivo = new Cadastro();
                    arquivo.Id = Convert.ToInt32(reader["Id"]);
                    arquivo.Id_Usuario = Convert.ToInt32(reader["Id_Usuario"]);
                    arquivo.Pdf = (byte[])(reader["Pdf"]);
                    arquivo.Status = reader["Status"].ToString();
                    arquivos.Add(arquivo);
                }
            }
            return arquivos;
        }
        public List<Login> RetornarLogin(string Nome, string Senha, int id)//esse metodo retorna uma lista Login que é minha classe que para acessa-la preciso de 2 parametros que sao duas strings
        {
            List<Login> lista = new List<Login>();
            // conn = new SqlConnection(@"Data Source=USUARIO-PC\;Initial Catalog=C#;Integrated Security=True");//conn é minha cconexão com o banco de dados apartir da biblioteca do sql connection
            connection.Open();//abre a conexao com o banco de dados para que possa ser executado minha query
            string query = @"SELECT login.Id,
                            login.Usuario,
                            login.Login,
                            cadastro.Status FROM Login login
                            LEFT JOIN Cadastro cadastro ON login.Id = cadastro.Id_Usuario WHERE 1=1";
            if (Nome != "" && Senha != "")
            {
                query += " AND login.Login = '" + Nome + @"'
                        AND login.Senha ='" + Senha + "'";
            }
            if (id != 0 && id != 4)
            {
                query += @"AND login.Id = " + id + "";
            };//selecionando os dados e filtrando conforme os parametros do metodo
            SqlCommand cmd = new SqlCommand(query, connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Login l = new Login();
                    l.Id = Convert.ToInt32(reader["Id"]);
                    l.Usuario = reader["Usuario"].ToString();
                    l.Loginn = reader["Login"].ToString();
                    l.Status = reader["Status"].ToString();
                    lista.Add(l);
                }
                connection.Close();
                return lista;
            }
        }
        public void UpdateCadastro(int id, string Status)
        {
            try
            {
                connection.Close();
                connection.Open();
                string query = @"UPDATE [dbo].[Cadastro]
                              SET [Status] = '" + Status + @"'
                              WHERE Id_Usuario = " + id + "";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}