using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmedicalgroup.webApi_DBFirst.Domains;
using senai.spmedicalgroup.webApi_DBFirst.Interfaces;
using senai.spmedicalgroup.webApi_DBFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITiposUsuario _Tipo { get; set; }
        public TipoUsuarioController()
        {
            _Tipo = new TipoUsuarioRepository();
        }
        /// <summary>
        /// Listar todos os tipos de usuarios
        /// </summary>
        /// <returns>Lista de todos os tipos de usuarios</returns>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_Tipo.read());
        }
        /// <summary>
        /// Listar apenas um tipo de usuario, baseado no seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma lista com as informações do tipo de usuario encontrado com o ID que foi passado como parametro</returns>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_Tipo.readId(id));
        }
        /// <summary>
        /// Cadastrar um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult post(TiposUsuario novoTipoUsuario)
        {
            _Tipo.create(novoTipoUsuario);
            return StatusCode(201);
        }
        /// <summary>
        /// Deleta um tipo de usuario baseado no ID passado como parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code 202</returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _Tipo.delete(id);
            return StatusCode(202);
        }
        /// <summary>
        /// Atualiza as informações de um tipo de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoAtualizado"></param>
        /// <returns>Status Code 203</returns>
        [HttpPut("{id}")]
        public IActionResult put(int id, TiposUsuario tipoAtualizado)
        {
            _Tipo.update(id, tipoAtualizado);
            return StatusCode(203);
        }
    }
}
