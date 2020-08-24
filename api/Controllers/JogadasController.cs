using api.business;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api.Controllers
{
    public class JogadasController : ApiController
    {
        private readonly JogadasBusiness jogadasBusiness;

        public JogadasController()
        {
            jogadasBusiness = new JogadasBusiness();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                var jogadas = jogadasBusiness.GetJogadas();
                return Ok(jogadas);
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
                var jogada = jogadasBusiness.GetJogadaById(id);
                return jogada == null ? (IHttpActionResult)NotFound() : Ok(jogada);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Jogada jogada)
        {
            try
            {
                jogadasBusiness.InsertNew(jogada);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put([FromBody] Jogada jogada)
        {
            try
            {
                jogadasBusiness.Update(jogada);
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
                var jogadaToDelete = new Jogada { Id = id };
                jogadasBusiness.Delete(jogadaToDelete);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}