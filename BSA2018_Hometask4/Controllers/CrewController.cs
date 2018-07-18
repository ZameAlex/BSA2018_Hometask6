using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA2018_Hometask4.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BSA2018_Hometask4.Shared.DTO;
using FluentValidation;
using BSA2018_Hometask4.Shared.Exceptions;

namespace BSA2018_Hometask4.Controllers
{
    [Route("v1/api/crew")]
    [ApiController]
    public class CrewsController : ControllerBase
    {
        readonly ICrewService service;

        public CrewsController(ICrewService crewService)
        {
            service = crewService;
        }
        // GET: v1/api/crew
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.Get());
            }
            catch (Exception ex )
            {
                return NotFound(ex);
            }
        }

        // GET: v1/api/crew/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(service.Get(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // POST: v1/api/crew
        [HttpPost]
        public IActionResult Post([FromBody]CrewDto value)
        {
            try
            {
                service.Create(value);
                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: v1/api/crew/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CrewDto crew)
        {
            try
            {
                service.Update(crew, id);
                return Ok();
            }
            catch(NotFoundException ex)
            {
                return NotFound( ex);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: v1/api/crew/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // DELETE: v1/api/crew
        [HttpDelete]
        public IActionResult Delete([FromBody] CrewDto crew)
        {
            try
            {
                service.Delete(crew);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
