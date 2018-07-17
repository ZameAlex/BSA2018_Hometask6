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
    [Route("v1/api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        readonly ITicketService service;

        public TicketsController(ITicketService ticketService)
        {
            service = ticketService;
        }
        // GET: v1/api/Tickets
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

        // GET: v1/api/Tickets/5
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

        // POST: v1/api/Tickets
        [HttpPost]
        public IActionResult Post([FromBody]TicketDto value)
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

        // PUT: v1/api/Tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketDto Ticket)
        {
            try
            {
                service.Update(Ticket, id);
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

        // DELETE: v1/api/Tickets/5
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

        // DELETE: v1/api/Tickets
        [HttpDelete]
        public IActionResult Delete([FromBody] TicketDto Ticket)
        {
            try
            {
                service.Delete(Ticket);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
