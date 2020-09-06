using api.facade;
using api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using api.interfaces;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace api.business
{
    public class UsuariosBusiness
    {
        private readonly UsuariosFacade _usuariosFacade;
        private readonly ILogger<UsuariosBusiness> _logger;

        public UsuariosBusiness(UsuariosFacade usuariosFacade, ILogger<UsuariosBusiness> logger)
        {
            _usuariosFacade = usuariosFacade;
            _logger = logger;
        }

        public void Delete(Usuario usuario)
        {
            _usuariosFacade.Delete(usuario);
        }

        public Usuario GetUserById(int? id)
        {
            return _usuariosFacade.GetUserById(id);
        }

        public IList<Usuario> GetUsers()
        {
            return _usuariosFacade.GetUsers();
        }

        public void InsertNew(Usuario usuario)
        {
            _usuariosFacade.InsertNew(usuario);
        }

        public void Update(Usuario usuario)
        {
            _usuariosFacade.Update(usuario);
        }
    }
}
