using CargaDeDados.Enitities;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaDeDados.Infra
{
    public class Repository
    {

        string path = "";
        
        public List<string[]> PegarPath(string local)
        {
            path = @"C:\TempMar\Teste de desenvolvimento - Backend C#\" + local;
            var objeto = File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"))
                .Skip(1)
                .Select(a => a.Split(';'))
                .ToList();

            return objeto;
        }
        public void InserirPais()
        {
            path = "tblPais.csv";
            var objeto = PegarPath(path);

            //SALVANDO NO BANCO DE DADOS

            foreach (var item in objeto)
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteDB;Integrated Security=True";
                    con.Open();
                    SqlTransaction transacao = con.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tblPais (DescPais) VALUES (@DescPais)", con, transacao);
                        command.Parameters.AddWithValue("@DescPais", item[1]);
                        command.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw new Exception(ex.Message);
                    }

                }

            }
        }
    
        public void InserirCliente()
        {

            path = "tblCliente.csv";
            var objeto = PegarPath(path);

            foreach (var item in objeto)
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteDB;Integrated Security=True";
                    con.Open();
                    SqlTransaction transacao = con.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tblCliente (DescCliente, CodPais, DDD, Fone, CodSexo) VALUES (@DescCliente, @CodPais, @DDD, @Fone, @CodSexo)", con, transacao);
                        command.Parameters.AddWithValue("@DescCliente", item[1]);
                        command.Parameters.AddWithValue("@CodPais", Convert.ToInt32(item[2]));
                        command.Parameters.AddWithValue("@DDD", item[3]);
                        command.Parameters.AddWithValue("@Fone", item[4]);
                        command.Parameters.AddWithValue("@CodSexo", Convert.ToInt32( item[5]));
                        command.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw new Exception(ex.Message);
                    }

                }

            }

        }

        public void InserirPedido()
        {
            path = "tblPedido.csv";
            var objeto = PegarPath(path);

            foreach (var item in objeto)
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteDB;Integrated Security=True";
                    con.Open();
                    SqlTransaction transacao = con.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tblPedido (CodCliente, QtdPedidos) VALUES (@CodCliente, @QtdPedidos)", con, transacao);
                        command.Parameters.AddWithValue("@CodCliente", Convert.ToInt32(item[1]));
                        command.Parameters.AddWithValue("@QtdPedidos", Convert.ToInt32(item[2]));
                        command.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw new Exception(ex.Message);
                    }

                }

            }
        }

        public void InserirQuestao()
        {
            path = "tblQuestao.csv";
            var objeto = PegarPath(path);

            foreach (var item in objeto)
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteDB;Integrated Security=True";
                    con.Open();
                    SqlTransaction transacao = con.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tblQuestao (DescQuestao) VALUES (@DescQuestao)", con, transacao);
                        command.Parameters.AddWithValue("@DescQuestao", item[1]);
                        command.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw new Exception(ex.Message);
                    }

                }

            }
        }

        public void InserirQuestaoOpcao()
        {
            path = "tblQuestaoOpcao.csv";
            var objeto = PegarPath(path);

            foreach (var item in objeto)
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteDB;Integrated Security=True";
                    con.Open();
                    SqlTransaction transacao = con.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tblQuestaoOpcao (CodQuestao, CodOpcao, DescOpcao) VALUES (@CodQuestao, @CodOpcao, @DescOpcao)", con, transacao);
                        command.Parameters.AddWithValue("@CodQuestao", Convert.ToInt32(item[1]));
                        command.Parameters.AddWithValue("@CodOpcao", Convert.ToInt32(item[2]));
                        command.Parameters.AddWithValue("@DescOpcao", item[3]);
                        command.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw new Exception(ex.Message);
                    }

                }

            }
        }

        public void InserirResposta()
        {
            path = "tblResposta.csv";
            var objeto = PegarPath(path);

            foreach (var item in objeto)
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteDB;Integrated Security=True";
                    con.Open();
                    SqlTransaction transacao = con.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tblResposta (CodCliente, CodQuestaoOpcao) VALUES (@CodCliente, @CodQuestaoOpcao)", con, transacao);
                        command.Parameters.AddWithValue("@CodCliente", Convert.ToInt32(item[1]));
                        command.Parameters.AddWithValue("@CodQuestaoOpcao", Convert.ToInt32(item[2]));
                        command.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw new Exception(ex.Message);
                    }

                }

            }
        }

        public void InserirSexo()
        {
            path = "tblSexo.csv";
            var objeto = PegarPath(path);

            foreach (var item in objeto)
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteDB;Integrated Security=True";
                    con.Open();
                    SqlTransaction transacao = con.BeginTransaction();
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tblSexo (DescSexo) VALUES (@DescSexo)", con, transacao);
                        command.Parameters.AddWithValue("@DescSexo", item[1]);
                        command.ExecuteNonQuery();
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        throw new Exception(ex.Message);
                    }

                }

            }
        }
    }
}
