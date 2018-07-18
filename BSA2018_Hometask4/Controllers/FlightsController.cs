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
    [Route("v1/api/flights")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        readonly IFlightService service;

        public FlightsController(IFlightService flightService)
        {
            service = flightService;
        }
        // GET: v1/api/flights
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

        // GET: v1/api/flights/5
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

        // POST: v1/api/flights
        [HttpPost]
        public IActionResult Post([FromBody]FlightDto value)
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
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: v1/api/flights/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FlightDto flight)
        {
            try
            {
                service.Update(flight, id);
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
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //PATCH v1/api/flights/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody](DateTime,DateTime) value)
        {
            try
            {
                service.Update(value.Item1, value.Item2, id);
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
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: v1/api/flights/5
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

        // DELETE: v1/api/flights
        [HttpDelete]
        public IActionResult Delete([FromBody] FlightDto flight)
        {
            try
            {
                service.Delete(flight);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
