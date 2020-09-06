using api.database;
using api.interfaces;
using api.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.facade
{
    public class UsuariosFacade : IUsuarios
    {
        private readonly IUsuarios _usuarios;
        private readonly ILogger<UsuariosFacade> _logger;

        public UsuariosFacade(IUsuarios usuarios, ILogger<UsuariosFacade> logger)
        {
            _usuarios = usuarios;
            _logger = logger;
        }


        public void Delete(Usuario usuario)
        {
            _usuarios.Delete(usuario);
        }

        public Usuario GetUserById(int? id)
        {
            return _usuarios.GetUserById(id);
        }

        public IList<Usuario> GetUsers()
        {
            return _usuarios.GetUsers();
        }

        public void InsertNew(Usuario usuario)
        {
            _usuarios.InsertNew(usuario);
        }

        public void Update(Usuario usuario)
        {
            _usuarios.Update(usuario);
        }
    }
}
