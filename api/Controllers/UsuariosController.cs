﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using api.business;
using api.interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosBusiness _usuariosBusiness;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(UsuariosBusiness usuariosBusiness, ILogger<UsuariosController> logger)
        {
            _usuariosBusiness = usuariosBusiness;
            _logger = logger;
        }

        // GET api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuariosBusiness.GetUsers());
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
                return Ok(_usuariosBusiness.GetUserById(id));
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
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest();
                _usuariosBusiness.InsertNew(usuario);
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
        public IActionResult Put([FromBody] Usuario usuario)
        {
            try
            {
                _usuariosBusiness.Update(usuario);
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
                var userToDelete = new Usuario { Id = id };
                _usuariosBusiness.Delete(userToDelete);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
