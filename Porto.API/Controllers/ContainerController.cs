using System;
using System.Collections.Generic;
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
    public class ContainerController : Controller
    {
        public readonly IContainerRepository _container;
        public ContainerController(IContainerRepository container)
        {
            _container = container;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllContaineres()
        {
            try
            {
                var resulta = await _container.GetAll();
                return Ok(resulta);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Container container)
        {
            try
            {
                _container.Add(container);

                if(await _container.SaveChangesAsync())
                {
                    return Created($"/api/container/{container.Id}", container);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Put(int id, Container container)
        {
             try
            {
                _container.Update(container);

                if(await _container.SaveChangesAsync())
                {
                    return Created($"/api/container/{container.Id}", container);
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
                var cont = await _container.GetById(id);
                if(cont == null) return NotFound();

                _container.Delete(cont);

                if(await _container.SaveChangesAsync())
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
