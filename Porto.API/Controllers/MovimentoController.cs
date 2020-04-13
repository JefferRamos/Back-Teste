using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Porto.Business.Interfaces;
using Porto.Business.Model;
using Porto.Data.DataContext;
using Porto.Data.Repository;

namespace Porto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : Controller
    {
        private readonly IMovimentoRepository _movimento;
        public MovimentoController(IMovimentoRepository movimento)
        {
            _movimento = movimento;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovimento()
        {
            try
            {
                var resulta = await _movimento.GetAll();
                return Ok(resulta);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Movimento movimento)
        {
             try
            {
                _movimento.Add(movimento);

                if(await _movimento.SaveChangesAsync())
                {
                    return Created($"/api/movimento/{movimento.Id}", movimento);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Put(int id, Movimento movimento)
        {
             try
            {
                _movimento.Update(movimento);

                if(await _movimento.SaveChangesAsync())
                {
                    return Created($"/api/movimento/{movimento.Id}", movimento);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("del/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
              try
            {
                var cont = await _movimento.GetById(id);
                if(cont == null) return NotFound();

                _movimento.Delete(cont);

                if(await _movimento.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }

            return BadRequest();
        }
    }
}
