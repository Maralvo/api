using api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.interfaces
{
    public interface IUsuarios
    {
        IList<Usuario> GetUsers();
        Usuario GetUserById(int? id);
        void InsertNew(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
