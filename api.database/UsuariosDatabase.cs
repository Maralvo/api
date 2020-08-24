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
            using (var con = new MySqlConnection(builder.ConnectionString))
            {
                con.Open();
                using (var cmd = new MySqlCommand("delete from Usuarios where ID_Usuario=@id", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new MySqlParameter("id", usuario.Id));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public Usuario GetUserById(int? id)
        {
            using (var con = new MySqlConnection(builder.ConnectionString))
            {
                con.Open();
                using (var cmd = new MySqlCommand("select * from Usuarios where ID_Usuario=@id", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new MySqlParameter("id", id));
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
                con.Close();
            }

            return null;
        }

        public IList<Usuario> GetUsers()
        {
            var users = new List<Usuario>();

            using (var con = new MySqlConnection(builder.ConnectionString))
            {
                con.Open();
                using (var cmd = new MySqlCommand("select * from Usuarios", con))
                {
                    cmd.CommandType = CommandType.Text;
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
                con.Close();
            }
            return users;
        }

        public void InsertNew(Usuario usuario)
        {
            using (var con = new MySqlConnection(builder.ConnectionString))
            {
                con.Open();
                using (var cmd = new MySqlCommand("usuario_inserir", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("nome", usuario.Nome));
                    cmd.Parameters.Add(new MySqlParameter("pontos", usuario.Pontos));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void Update(Usuario usuario)
        {
            using (var con = new MySqlConnection(builder.ConnectionString))
            {
                con.Open();
                using (var cmd = new MySqlCommand("update Usuarios set Nome=@nome, Pontos=@pontos where ID_Usuario=@id", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new MySqlParameter("nome", usuario.Nome));
                    cmd.Parameters.Add(new MySqlParameter("pontos", usuario.Pontos));
                    cmd.Parameters.Add(new MySqlParameter("id", usuario.Id));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
