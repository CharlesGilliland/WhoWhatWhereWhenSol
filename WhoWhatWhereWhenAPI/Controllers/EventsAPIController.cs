using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhoWhatWhereWhen.Data;
using WhoWhatWhereWhen.Models;

namespace WhoWhatWhereWhenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventsAPIController : ControllerBase
    {
        private ApplicationDbContext _context;

        public EventsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET api/events
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            return Ok(_context.Events.ToList());
        }

        // GET api/events/{id}
        [HttpGet]
        public ActionResult<Event> GetEvent(int id)
        {
            var singleEvent = _context.Events.Include(x => x.EventType).SingleOrDefault(x => x.Id == id);

            if(singleEvent == null)
            {
                return NotFound();
            }

            return Ok(singleEvent);
        }

        // POST api/events
        [HttpPost]
        public ActionResult<Event> CreateEvent(Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Add(newEvent);
            _context.SaveChanges();

            return Ok(newEvent);
        }

        // PUT api/events
        [HttpPut]
        public ActionResult UpdateEvent(int id, Event updatedEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var eventInDb = _context.Events.SingleOrDefault(x => x.Id == id);

            if(eventInDb == null)
            {
                return NotFound();
            }

            eventInDb.Title = updatedEvent.Title;
            eventInDb.EventTypeId = updatedEvent.EventTypeId;
            eventInDb.DateAndTime = updatedEvent.DateAndTime;
            eventInDb.Description = updatedEvent.Description;

            _context.SaveChanges();
            return Ok();
        }

        // DELTE api/events
        [HttpDelete]
        public ActionResult DeleteEvent(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(x => x.Id == id);

            if (eventInDb == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
