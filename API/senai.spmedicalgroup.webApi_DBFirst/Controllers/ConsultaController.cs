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
    public class ConsultaController : ControllerBase
    {
        private IConsulta _ConsultumRepository { get; set; }

        public ConsultaController()
        {
            _ConsultumRepository = new ConsultasRepository();
        }
        /// <summary>
        /// Lista todas as consultas no sistema
        /// </summary>
        /// <returns>Retorna uma lista com todas as consultas</returns>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_ConsultumRepository.read());
        }
        /// <summary>
        /// Lista as informações de uma consulta, baseado no ID passado como parametro 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna as informacoes de uma consulta especifica</returns>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_ConsultumRepository.readId(id));
        }
        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaconsultum"></param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult post(Consulta novaconsultum)
        {
            _ConsultumRepository.create(novaconsultum);
            return StatusCode(201);
        }
        /// <summary>
        /// Deleta os registros de uma consulta
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code 202</returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _ConsultumRepository.delete(id);
            return StatusCode(id);
        }
        /// <summary>
        /// Atualiza as informações de uma consulta
        /// <param name="id"></param>
        /// <param name="consultumAtualizada"></param>
        /// <returns>Status Code 204</returns>
        [HttpPut("{id}")]
        public IActionResult put(int id, Consulta consultumAtualizada)
        {
            _ConsultumRepository.update(id, consultumAtualizada);
            return StatusCode(204);
        }
    }
}
