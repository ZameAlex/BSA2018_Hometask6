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
    [Route("v1/api/stewadress")]
    [ApiController]
    public class StewadresssController : ControllerBase
    {
        readonly IStewadressService service;

        public StewadresssController(IStewadressService stewadressService)
        {
            service = stewadressService;
        }
        // GET: v1/api/stewadress
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

        // GET: v1/api/stewadress/5
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

        // POST: v1/api/stewadress
        [HttpPost]
        public IActionResult Post([FromBody]StewadressDto value)
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

        // PUT: v1/api/stewadress/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StewadressDto stewadress)
        {
            try
            {
                service.Update(stewadress, id);
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

        // DELETE: v1/api/stewadress/5
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

        // DELETE: v1/api/stewadress
        [HttpDelete]
        public IActionResult Delete([FromBody] StewadressDto stewadress)
        {
            try
            {
                service.Delete(stewadress);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
