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
    public class ClinicaController : ControllerBase
    {
        private IClinica _clinica { get; set; }
        public ClinicaController()
        {
            _clinica = new ClinicaRepository();
        }
        /// <summary>
        /// Lista todas as clinicas cadastradas
        /// </summary>
        /// <returns>Retorna uma lista contendo todas as clinicas</returns>
        [HttpGet]
        public IActionResult get()
        {
            return Ok(_clinica.read());
        }
        /// <summary>
        /// Lista as informações de uma clinica baseado no ID passado como parametro na busca
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna as informações de uma clinica</returns>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_clinica.readId(id));
        }
        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica"></param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult post(Clinica novaClinica)
        {
            _clinica.create(novaClinica);
            return StatusCode(201);
        }
        /// <summary>
        /// Deleta o cadastro de uma clinica
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code 202</returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _clinica.delete(id);
            return StatusCode(202);
        }
        /// <summary>
        /// Atualiza as informacoes de uma clinica
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinicaAtualizada"></param>
        /// <returns>Status Code 203</returns>
        [HttpPut("{id}")]
        public IActionResult put(int id, Clinica clinicaAtualizada)
        {
            _clinica.update(id, clinicaAtualizada);
            return StatusCode(203);
        }
    }
}
