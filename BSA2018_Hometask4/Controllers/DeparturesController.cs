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
    [Route("v1/api/departures")]
    [ApiController]
    public class DeparturesController : ControllerBase
    {
        readonly IDepartureService service;

        public DeparturesController(IDepartureService departureService)
        {
            service = departureService;
        }
        // GET: v1/api/departures
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.Get());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: v1/api/departures/5
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

        // POST: v1/api/departures
        [HttpPost]
        public IActionResult Post([FromBody]DepartureDto value)
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

        // PUT: v1/api/departures/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DepartureDto departure)
        {
            try
            {
                service.Update(departure, id);
                return Ok();
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


        //PATCH v1/api/departures/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]DateTime value)
        {
            try
            {
                service.Update(value, id);
                return Ok();
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
                return BadRequest( ex);
            }
        }

        // DELETE: v1/api/departures/5
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

        // DELETE: v1/api/departures
        [HttpDelete]
        public IActionResult Delete([FromBody] DepartureDto departure)
        {
            try
            {
                service.Delete(departure);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
