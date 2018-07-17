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
    [Route("v1/api/planes")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        readonly IPlaneService service;

        public PlanesController(IPlaneService planeService)
        {
            service = planeService;
        }
        // GET: v1/api/planes
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

        // GET: v1/api/planes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(service.Get(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: v1/api/planes
        [HttpPost]
        public IActionResult Post([FromBody]PlaneDto value)
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
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: v1/api/planes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlaneDto plane)
        {
            try
            {
                service.Update(plane, id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //PATCH v1/api/planes/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]TimeSpan value)
        {
            try
            {
                service.Update(value, id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: v1/api/planes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: v1/api/Planes
        [HttpDelete]
        public IActionResult Delete([FromBody] PlaneDto plane)
        {
            try
            {
                service.Delete(plane);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
