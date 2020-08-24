using api.business;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace api.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly UsuariosBusiness usuariosBusiness;

        public UsuariosController()
        {
            usuariosBusiness = new UsuariosBusiness();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                var users = usuariosBusiness.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var user = usuariosBusiness.GetUserById(id);
                return user == null ? (IHttpActionResult) NotFound() : Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest();
                usuariosBusiness.InsertNew(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put([FromBody] Usuario usuario)
        {
            try
            {
                usuariosBusiness.Update(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var userToDelete = new Usuario { Id = id };
                usuariosBusiness.Delete(userToDelete);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}