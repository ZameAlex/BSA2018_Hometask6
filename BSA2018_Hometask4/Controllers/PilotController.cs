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
    [Route("v1/api/pilots")]
    [ApiController]
    public class PilotsController : ControllerBase
    {
        readonly IPilotService service;

        public PilotsController(IPilotService pilotService)
        {
            service = pilotService;
        }
        // GET: v1/api/Pilots
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.Get());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // GET: v1/api/pilots/5
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

        // POST: v1/api/pilots
        [HttpPost]
        public IActionResult Post([FromBody]PilotDto value)
        {
            try
            {
                return Ok(service.Create(value));
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

        // PUT: v1/api/pilots/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PilotDto pilot)
        {
            try
            {
                service.Update(pilot, id);
                return Ok("success");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
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

        //PATCH v1/api/pilots/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]int value)
        {
            try
            {
                service.Update(value, id);
                return Ok("success");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
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

        // DELETE: v1/api/pilots/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return NoContent();
            }
            catch (Exception ex )
            {
                return NotFound(ex);
            }
        }

        // DELETE: v1/api/pilots
        [HttpDelete]
        public IActionResult Delete([FromBody] PilotDto pilot)
        {
            try
            {
                service.Delete(pilot);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
