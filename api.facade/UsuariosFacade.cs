using api.database;
using api.interfaces;
using api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.facade
{
    public class UsuariosFacade : IUsuarios
    {
        private readonly UsuariosDatabase usuariosDatabase;

        public UsuariosFacade()
        {
            usuariosDatabase = new UsuariosDatabase();
        }


        public void Delete(Usuario usuario)
        {
            usuariosDatabase.Delete(usuario);
        }

        public Usuario GetUserById(int? id)
        {
            return usuariosDatabase.GetUserById(id);
        }

        public IList<Usuario> GetUsers()
        {
            return usuariosDatabase.GetUsers();
        }

        public void InsertNew(Usuario usuario)
        {
            usuariosDatabase.InsertNew(usuario);
        }

        public void Update(Usuario usuario)
        {
            usuariosDatabase.Update(usuario);
        }
    }
}
