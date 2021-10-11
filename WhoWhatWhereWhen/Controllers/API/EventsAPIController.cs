using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhoWhatWhereWhen.Data;
using WhoWhatWhereWhen.DTOs;
using WhoWhatWhereWhen.Models;

namespace WhoWhatWhereWhen.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventsAPIController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EventsAPIController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetEvents()
        {
            return Ok(_context.Events.Include(x => x.EventType).Include(x => x.Host).ToList().Select(_mapper.Map<Event, EventDto>));
        }

        [HttpGet("{id}")]
        public ActionResult<EventDto> GetEvent(int id)
        {
            var singleEvent = _context.Events.Include(x => x.EventType).Include(x => x.Host).SingleOrDefault(x => x.Id == id);

            if (singleEvent == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EventDto>(singleEvent));
        }

        // POST api/events
        [HttpPost]
        public ActionResult<EventDto> CreateEvent(EventDto newEventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newEvent = _mapper.Map<EventDto, Event>(newEventDto);

            _context.Add(newEvent);
            _context.SaveChanges();

            newEventDto.Id = newEvent.Id;

            return CreatedAtAction(nameof(CreateEvent), newEventDto);
        }

        // PUT api/events
        [HttpPut("{id}")]
        public ActionResult UpdateEvent(int id, EventDto updatedEventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var eventInDb = _context.Events.SingleOrDefault(x => x.Id == id);

            if (eventInDb == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedEventDto, eventInDb);

            _context.SaveChanges();

            return Ok();
        }



        // TRY TO GET THIS WORKING!!!!!!!
        //// PUT /api/events
        //[HttpPut]
        //[Route("api/EventsAPI/id/uid")]
        //public ActionResult AddAttending(int id, string uid)
        //{
        //    var eventInDb = _context.Events.SingleOrDefault(x => x.Id == id);
        //    if (eventInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    var userInDb = _context.Users.SingleOrDefault(x => x.Id == uid);
        //    if (userInDb == null)
        //    {
        //        return Ok();
        //    }

        //    eventInDb.Attending.ToList().Add(uid);
        //    _context.SaveChanges();

        //    return Ok();
        //}




        // DELTE api/events
        [HttpDelete("{id}")]
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
