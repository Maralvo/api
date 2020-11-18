using api.interfaces;
using api.model;
using api.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace api.database
{
    public class JogadasDatabase : IJogadas
    {
        private readonly MySqlConnectionStringBuilder _builder;
        public JogadasDatabase(MysqlConfiguration mysqlConfiguration)
        {
            _builder = new MySqlConnectionStringBuilder
            {
                UserID = mysqlConfiguration.UserID,
                Password = mysqlConfiguration.Password,
                Server = mysqlConfiguration.Server,
                Database = mysqlConfiguration.Database,
            };
        }

        public void Delete(Jogada jogada)
        {
            using (var connection = new MySqlConnection(_builder.ConnectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("delete from Jogadas where ID_JOGADA=@id", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new MySqlParameter("id", jogada.Id));
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public Jogada GetJogadaById(int? id)
        {
            using (var connection = new MySqlConnection(_builder.ConnectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("select * from Jogadas where ID_JOGADA=@id", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new MySqlParameter("id", id));
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        return new Jogada
                        {
                            Id = Convert.ToInt32(rdr["ID_JOGADA"]),
                            Usuario = new Usuario
                            {
                                Id = Convert.ToInt32(rdr["ID_USUARIO"]),
                            },
                            Jogo = new Jogo
                            {
                                Id = Convert.ToInt32(rdr["ID_JOGO"]),
                            },
                            DataHora = Convert.ToDateTime(rdr["Data_Hora"]),
                            Erros = rdr["Erros"] == DBNull.Value ? (int?) null : Convert.ToInt32(rdr["Erros"]),
                            Acertos = rdr["Acertos"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["Acertos"]),
                            Pontos = rdr["Pontos"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["Pontos"]),
                            Tempo =Convert.ToString(rdr["Tempo"]),
                            Fases = rdr["Fases"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["Fases"]),
                        };
                    }
                }
                connection.Close();
            }

            return null;
        }

        public IList<Jogada> GetJogadas()
        {
            var jogadas = new List<Jogada>();
            using (var connection = new MySqlConnection(_builder.ConnectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("select * from Jogadas", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        jogadas.Add(new Jogada
                        {
                            Id = rdr["ID_JOGADA"] != DBNull.Value ? Convert.ToInt32(rdr["ID_JOGADA"]) : -1,
                            Usuario = new Usuario
                            {
                                Id = rdr["ID_USUARIO"] != DBNull.Value ? Convert.ToInt32(rdr["ID_USUARIO"]) : (int?)null,
                            },
                            Jogo = new Jogo
                            {
                                Id = Convert.ToInt32(rdr["ID_JOGO"]),
                            },
                            DataHora = rdr["Data_Hora"] != DBNull.Value ? Convert.ToDateTime(rdr["Data_Hora"]) : (DateTime?)null,
                            Erros = rdr["Erros"] != DBNull.Value ? Convert.ToInt32(rdr["Erros"]) : (int?)null,
                            Acertos = rdr["Acertos"] != DBNull.Value ? Convert.ToInt32(rdr["Erros"]) : (int?)null,
                            Pontos = rdr["Pontos"] != DBNull.Value ? Convert.ToInt32(rdr["Pontos"]) : (int?)null,
                            Tempo = rdr["Tempo"] != DBNull.Value ? Convert.ToString(rdr["Tempo"]) : null,
                            Fases = rdr["Fases"] != DBNull.Value ? Convert.ToInt32(rdr["Fases"]) : (int?)null,
                        });
                    }
                }
                connection.Close();
            }
            return jogadas;
        }

        public void InsertNew(Jogada jogada)
        {
            using (var connection = new MySqlConnection(_builder.ConnectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using (var cmd = new MySqlCommand("jogada_inserir", connection))
                    {
                        //        using (var client = new SshClient(SSH_HOST, SSH_USER, SSH_PASSWORD))
                        //{
                        //    client.Connect();
                        //    if (client.IsConnected)
                        //    {
                        //        var portForwarded = new ForwardedPortLocal(BOUND_HOST, BOUND_PORT, HOST, PORT);
                        //        client.AddForwardedPort(portForwarded);
                        //        portForwarded.Start();
                        //        using (MySqlConnection con = new MySqlConnection(CS))
                        //        {
                        //            using (var cmd = new MySqlCommand("jogada_inserir", con))
                        //            {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("@id_usuario", jogada.Usuario.Id));
                        cmd.Parameters.Add(new MySqlParameter("@nome_usuario", jogada.Usuario.Nome));
                        cmd.Parameters.Add(new MySqlParameter("@id_jogo", jogada.Jogo.Id));
                        cmd.Parameters.Add(new MySqlParameter("@erros", jogada.Erros));
                        cmd.Parameters.Add(new MySqlParameter("@acertos", jogada.Acertos));
                        cmd.Parameters.Add(new MySqlParameter("@pontos", jogada.Pontos));
                        cmd.Parameters.Add(new MySqlParameter("@tempo", jogada.Tempo));
                        cmd.Parameters.Add(new MySqlParameter("@fases", jogada.Fases));
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update(Jogada jogada)
        {
            using (var connection = new MySqlConnection(_builder.ConnectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand("update Usuarios set ID_USUARIO=@ID_USUARIO, ID_JOGO=@ID_JOGO, Data_Hora=@Data_Hora, Erros=@Erros, Acertos=@Acertos, Pontos=@Pontos, Tempo=@Tempo, Fases=@Fases where ID_JOGADA=@ID_JOGADA", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new MySqlParameter("@ID_USUARIO", jogada.Usuario.Id));
                    cmd.Parameters.Add(new MySqlParameter("@ID_JOGO", jogada.Jogo.Id));
                    cmd.Parameters.Add(new MySqlParameter("@Data_Hora", jogada.DataHora));
                    cmd.Parameters.Add(new MySqlParameter("@Erros", jogada.Erros));
                    cmd.Parameters.Add(new MySqlParameter("@Acertos", jogada.Acertos));
                    cmd.Parameters.Add(new MySqlParameter("@Pontos", jogada.Pontos));
                    cmd.Parameters.Add(new MySqlParameter("@Tempo", jogada.Tempo));
                    cmd.Parameters.Add(new MySqlParameter("@Fases", jogada.Fases));
                    cmd.Parameters.Add(new MySqlParameter("@ID_JOGADA", jogada.Id));

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}