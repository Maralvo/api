using api.database.common;
using api.interfaces;
using api.Models;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace api.database
{
    public class UsuariosDatabase : BaseAdo, IUsuarios
    {

        public UsuariosDatabase()
        {

        }

        public void Delete(Usuario usuario)
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
                        using (var cmd = new MySqlCommand("delete from Usuarios where ID_Usuario=@id", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("id", usuario.Id));
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    client.Disconnect();
                }
            }
        }

        public Usuario GetUserById(int? id)
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
                        using (var cmd = new MySqlCommand("select * from Usuarios where ID_Usuario=@id", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("id", id));
                            con.Open();
                            var rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                return new Usuario
                                {
                                    Id = Convert.ToInt32(rdr["ID_Usuario"]),
                                    Nome = rdr["Nome"].ToString(),
                                    Pontos = Convert.ToInt32(rdr["Pontos"].ToString()),
                                };
                            }
                        }
                    }
                    client.Disconnect();
                }
            }

            return null;
        }

        public IList<Usuario> GetUsers()
        {
            var users = new List<Usuario>();
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
                        using (var cmd = new MySqlCommand("select * from Usuarios", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            var rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                users.Add(new Usuario()
                                {
                                    Id = Convert.ToInt32(rdr["ID_Usuario"]),
                                    Nome = rdr["Nome"].ToString(),
                                    Pontos = Convert.ToInt32(rdr["Pontos"].ToString()),
                                });
                            }
                        }
                    }
                    client.Disconnect();
                }
            }
            return users;
        }

        public void InsertNew(Usuario usuario)
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
                        using (var cmd = new MySqlCommand("insert into Usuarios (Nome, Pontos) values (@nome, @pontos)", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("nome", usuario.Nome));
                            cmd.Parameters.Add(new MySqlParameter("pontos", usuario.Pontos));
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    client.Disconnect();
                }
            }
        }

        public void Update(Usuario usuario)
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
                        using (var cmd = new MySqlCommand("update Usuarios set Nome=@nome, Pontos=@pontos where ID_Usuario=@id", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new MySqlParameter("nome", usuario.Nome));
                            cmd.Parameters.Add(new MySqlParameter("pontos", usuario.Pontos));
                            cmd.Parameters.Add(new MySqlParameter("id", usuario.Id));
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
