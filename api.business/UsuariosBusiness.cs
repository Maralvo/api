using api.facade;
using api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using api.interfaces;

namespace api.business
{
    public class UsuariosBusiness : IUsuarios
    {
        private readonly UsuariosFacade usuariosFacade;

        public UsuariosBusiness()
        {
            usuariosFacade = new UsuariosFacade();
        }

        public void Delete(Usuario usuario)
        {
            usuariosFacade.Delete(usuario);
        }

        public Usuario GetUserById(int? id)
        {
            return usuariosFacade.GetUserById(id);
        }

        public IList<Usuario> GetUsers()
        {
            return usuariosFacade.GetUsers();
        }

        public void InsertNew(Usuario usuario)
        {
            usuariosFacade.InsertNew(usuario);
        }

        public void Update(Usuario usuario)
        {
            usuariosFacade.Update(usuario);
        }
    }
}
