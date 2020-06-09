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
    public class JogosDatabase : BaseAdo, IJogos
    {

        public JogosDatabase()
        {

        }
        public void Delete(Jogo jogo)
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
                        using (var cmd = new MySqlCommand("delete from Jogos where ID_JOGO=@id", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("id", jogo.Id));
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    client.Disconnect();
                }
            }
        }

        public Jogo GetJogoById(int? id)
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
                        using (var cmd = new MySqlCommand("select * from Jogos where ID_JOGO=@id", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("id", id));
                            con.Open();
                            var rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                return new Jogo
                                {
                                    Id = Convert.ToInt32(rdr["ID_JOGO"]),
                                    DataCriacao = Convert.ToDateTime(rdr["Data_Criacao"]),
                                    Nome = Convert.ToString(rdr["Nome"]),
                                    Versao = Convert.ToInt32(rdr["Versao"]),
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

        public IList<Jogo> GetJogos()
        {
            var jogos = new List<Jogo>();
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
                        using (var cmd = new MySqlCommand("select * from Jogos", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            var rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                jogos.Add(new Jogo
                                {
                                    Id = Convert.ToInt32(rdr["ID_JOGO"]),
                                    DataCriacao = Convert.ToDateTime(rdr["Data_Criacao"]),
                                    Nome = Convert.ToString(rdr["Nome"]),
                                    Versao = Convert.ToInt32(rdr["Versao"]),
                                    Fases = Convert.ToInt32(rdr["Fases"]),
                                });
                            }
                        }
                    }
                    client.Disconnect();
                }
            }
            return jogos;
        }

        public void InsertNew(Jogo jogo)
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
                        using (var cmd = new MySqlCommand("insert into Jogos (Nome, Data_Criacao, Versao, Fases) values (@Nome, NOW(), @Versao, @Fases)", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("@Nome", jogo.Nome));
                            cmd.Parameters.Add(new MySqlParameter("@Versao", jogo.Versao));
                            cmd.Parameters.Add(new MySqlParameter("@Fases", jogo.Fases));
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    client.Disconnect();
                }
            }
        }

        public void Update(Jogo jogo)
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
                        using (var cmd = new MySqlCommand("update Jogos set Nome=@Nome, Versao=@Versao, Fases=@Fases where ID_JOGO=@ID_JOGO", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("@Nome", jogo.Nome));
                            cmd.Parameters.Add(new MySqlParameter("@Versao", jogo.Versao));
                            cmd.Parameters.Add(new MySqlParameter("@Fases", jogo.Fases));
                            cmd.Parameters.Add(new MySqlParameter("@ID_JOGO", jogo.Id));
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
