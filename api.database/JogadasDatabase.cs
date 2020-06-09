using api.database.common;
using api.interfaces;
using api.Models;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace api.database
{
    public class JogadasDatabase : BaseAdo, IJogadas
    {

        public JogadasDatabase()
        {

        }

        public void Delete(Jogada jogada)
        {
            using (var client = new SshClient(SSH_HOST, SSH_USER, SSH_PASSWORD))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    var portForwarded = new ForwardedPortLocal(BOUND_HOST, BOUND_PORT, HOST, PORT);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (var con = new MySqlConnection(CS))
                    {
                        using (var cmd = new MySqlCommand("delete from Jogadas where ID_JOGADA=@id", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("id", jogada.Id));
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    client.Disconnect();
                }
            }
        }

        public Jogada GetJogadaById(int? id)
        {
            using (var client = new SshClient(SSH_HOST, SSH_USER, SSH_PASSWORD))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    var portForwarded = new ForwardedPortLocal(BOUND_HOST, BOUND_PORT, HOST, PORT);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (var con = new MySqlConnection(CS))
                    {
                        using (var cmd = new MySqlCommand("select * from Jogadas where ID_JOGADA=@id", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("id", id));
                            con.Open();
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
                                    Erros = Convert.ToInt32(rdr["Erros"]),
                                    Acertos = Convert.ToInt32(rdr["Acertos"]),
                                    Pontos = Convert.ToInt32(rdr["Pontos"]),
                                    Tempo = Convert.ToDateTime(rdr["Tempo"]),
                                    Fases = Convert.ToInt32(rdr["Fases"]),
                                };
                            }
                        }
                    }
                    client.Disconnect();
                }
            }

            return null;
        }

        public IList<Jogada> GetJogadas()
        {
            var jogadas = new List<Jogada>();
            using (var client = new SshClient(SSH_HOST, SSH_USER, SSH_PASSWORD))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    var portForwarded = new ForwardedPortLocal(BOUND_HOST, BOUND_PORT, HOST, PORT);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (var con = new MySqlConnection(CS))
                    {
                        using (var cmd = new MySqlCommand("select * from Jogadas", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            var rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                jogadas.Add(new Jogada
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
                                    Erros = Convert.ToInt32(rdr["Erros"]),
                                    Acertos = Convert.ToInt32(rdr["Acertos"]),
                                    Pontos = Convert.ToInt32(rdr["Pontos"]),
                                    Tempo = Convert.ToDateTime(rdr["Tempo"]),
                                    Fases = Convert.ToInt32(rdr["Fases"]),
                                });
                            }
                        }
                    }
                    client.Disconnect();
                }
            }
            return jogadas;
        }

        public void InsertNew(Jogada jogada)
        {
            using (var client = new SshClient(SSH_HOST, SSH_USER, SSH_PASSWORD))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    var portForwarded = new ForwardedPortLocal(BOUND_HOST, BOUND_PORT, HOST, PORT);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (MySqlConnection con = new MySqlConnection(CS))
                    {
                        using (var cmd = new MySqlCommand("insert into Jogadas (ID_USUARIO, ID_JOGO, Data_Hora, Erros, Acertos, Pontos, Tempo, Fases) values (@ID_USUARIO, @ID_JOGO, @Data_Hora, @Erros, @Acertos, @Pontos, @Tempo, @Fases)", con))
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
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    client.Disconnect();
                }
            }
        }

        public void Update(Jogada jogada)
        {
            using (var client = new SshClient(SSH_HOST, SSH_USER, SSH_PASSWORD))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    var portForwarded = new ForwardedPortLocal(BOUND_HOST, BOUND_PORT, HOST, PORT);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (MySqlConnection con = new MySqlConnection(CS))
                    {
                        using (var cmd = new MySqlCommand("update Usuarios set ID_USUARIO=@ID_USUARIO, ID_JOGO=@ID_JOGO, Data_Hora=@Data_Hora, Erros=@Erros, Acertos=@Acertos, Pontos=@Pontos, Tempo=@Tempo, Fases=@Fases where ID_JOGADA=@ID_JOGADA", con))
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
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    client.Disconnect();
                }
            }
        }
    }
}
