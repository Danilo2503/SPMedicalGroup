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
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuario { get; set; }
        public UsuarioController()
        {
            _usuario = new UsuarioRepository();
        }
        /// <summary>
        /// Lista todos os usuarios presentes
        /// </summary>
        /// <returns>Lista de todos os usuarios encontrados</returns>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_usuario.read());
        }
        /// <summary>
        /// Lista todas as informações de um usuario especifico, baseado no ID passado como parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna todas as informações de um usuario</returns>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_usuario.readId(id));
        }
        /// <summary>
        /// Cadastra um novo usuario 
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult post(Usuario novoUsuario)
        {
            _usuario.create(novoUsuario);
            return StatusCode(201);
        }
        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code 202</returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _usuario.delete(id);
            return StatusCode(202);
        }
        /// <summary>
        /// Atualiza as informações de um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        /// <returns>Status Code204</returns>
        [HttpPut("{id}")]
        public IActionResult put(int id, Usuario usuarioAtualizado)
        {
            _usuario.update(id, usuarioAtualizado);
            return StatusCode(204);
        }
    }
}
