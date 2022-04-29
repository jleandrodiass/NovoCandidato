using Microsoft.AspNetCore.Mvc;
using Candidatos.Buseness.Interfaces;
using Candidatos.modelo;
using System;

namespace CandidatosControllers
{
    [ApiController]
    [Route("controller")]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidato_Bs _candidato;
        public CandidatoController(ICandidato_Bs candidato_Bs)
        {
            _candidato = candidato_Bs;
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidatoId(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var candidato  = await _candidato.GetCandidatoId(id);

                if (candidato == null)
                {
                    return NotFound();
                }

                return Ok(candidato);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            try
            {
                var avaliacao = _candidato.GetAll();
                if (avaliacao == null)
                    return NotFound();

                return Ok(avaliacao);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        

        [HttpPost]
        public async Task<IActionResult> Post(Candidato novoCandidato)
        {
            try
            {
                // var data = DateTime.Now.Year;
                if (novoCandidato.DataNascimento.Year >= DateTime.Now.Year)
                {
                    return BadRequest("Verifique sua data de nascimento.");
                }
                //var idade = _candidato.CalcularIdade(novoCandidato.DataNascimento);

                // if (idade >= 18)
                // {
                    var candidato = await _candidato.Novocandidato(novoCandidato);
                    return Ok(candidato);
            }

            
            catch (Exception ex)
            {
                return BadRequest("Candidato deve possuir maioridade. ");
                throw ex;
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(Candidato novoCandidato)
        {
            var candidato = await _candidato.PutUpdade(novoCandidato);
            return Ok(candidato);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                await _candidato.Delete(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
