using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using api.business;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadasController : ControllerBase
    {
        private readonly JogadasBusiness _jogadasBusiness;
        private readonly ILogger<JogadasController> _logger;

        public JogadasController(JogadasBusiness jogadasBusiness, ILogger<JogadasController> logger)
        {
            _jogadasBusiness = jogadasBusiness;
            _logger = logger;
        }

        // GET api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogadasBusiness.GetJogadas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_jogadasBusiness.GetJogadaById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] Jogada jogada)
        {
            try
            {
                if (jogada == null)
                    return BadRequest();
                _jogadasBusiness.InsertNew(jogada);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put([FromBody] Jogada jogada)
        {
            try
            {
                _jogadasBusiness.Update(jogada);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                var jogadaToDelete = new Jogada { Id = id };
                _jogadasBusiness.Delete(jogadaToDelete);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
