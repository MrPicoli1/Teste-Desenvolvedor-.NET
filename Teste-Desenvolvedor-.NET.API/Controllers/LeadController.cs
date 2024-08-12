﻿using Microsoft.AspNetCore.Mvc;
using Teste_Desenvolvedor_.NET.Models.Models;

namespace Teste_Desenvolvedor_.NET.API.Controllers
{
    [ApiController]
    [Route("api/v1/lead")]
    public class LeadController : Controller
    {

        /// <summary>
        /// Adicionar um Lead
        /// </summary>
        /// <param name="model">Objeto para a criãção de um Lead</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se o Lead foi Criado </response>
        /// <response code="400">Se o Lead não foi Criado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarLead([FromBody] LeadModel model)
        {
            return Ok();
        }

        /// <summary>
        /// Retornar um Lead
        /// </summary>
        /// <param name="id">Objeto para a encontrar o Lead</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se o Lead foi encontrado </response>
        /// <response code="404">Se o Lead não foi encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLead(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Retorna todos os Leads
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se os Leads foram retornados </response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllLead()
        {
            return Ok();
        }

        /// <summary>
        /// Deleta um Lead
        /// </summary>
        /// <param name="id">Objeto para a encontrar o Lead</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se o Lead foi Deletado </response>
        /// <response code="404">Se o Lead não foi encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLead(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Atualiza um Lead
        /// </summary>
        /// <param name="model">Objeto para a Atualizacao de um Lead</param>
        /// <param name="id">Objeto para a encontrar o Lead</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se o Lead foi Aualizado </response>
        /// <response code="404">Se o Lead não foi encontrado</response>
        /// <response code="400">Se o Lead não foi Atualizado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLead([FromBody] LeadModel model, Guid id)
        {
            return Ok();
        }
    }
}