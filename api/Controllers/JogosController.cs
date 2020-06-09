using api.business;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class JogosController : ApiController
    {
        private readonly JogosBusiness jogosBusiness;

        public JogosController()
        {
            jogosBusiness = new JogosBusiness();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                var jogos = jogosBusiness.GetJogos();
                return Ok(jogos);
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
                var jogo = jogosBusiness.GetJogoById(id);
                return jogo == null ? (IHttpActionResult)NotFound() : Ok(jogo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Jogo jogo)
        {
            try
            {
                jogosBusiness.InsertNew(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put([FromBody] Jogo jogo)
        {
            try
            {
                jogosBusiness.Update(jogo);
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
                var jogoToDelete = new Jogo { Id = id };
                jogosBusiness.Delete(jogoToDelete);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
