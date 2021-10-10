using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WhoWhatWhereWhen.Controllers.API;
using WhoWhatWhereWhen.Data;
using WhoWhatWhereWhen.Models;
using WhoWhatWhereWhen.ViewModels;

namespace WhoWhatWhereWhen.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new EventsViewModel()
            {
                Events = _context.Events.Include(x => x.EventType).ToList()
            };
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var singleEvent = _context.Events.SingleOrDefault(x => x.Id == id);
            return View(singleEvent);
        }

        public IActionResult Edit(int id)
        {
            var singleEvent = _context.Events.SingleOrDefault(x => x.Id == id);

            if (singleEvent == null)
            {
                return NotFound();
            }

            var vm = new EventFormViewModel
            {
                Event = singleEvent,
                EventTypes = _context.EventType.ToList()
            };
            return View("EventsForm", vm);
        }

        public IActionResult Create()
        {
            var vm = new EventFormViewModel
            {
                Event = new Event(),
                EventTypes = _context.EventType.ToList()
            };
            return View("EventsForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Event Event)
        {
            if (!ModelState.IsValid)
            {
                var vm = new EventFormViewModel
                {
                    Event = Event,
                    EventTypes = _context.EventType.ToList()
                };
                return View("EventsForm", vm);
            }
            if (Event.Id == 0)
            {
                _context.Add(Event);
            }
            else
            {
                var eventInDb = _context.Events.Single(x => x.Id == Event.Id);

                eventInDb.Title = Event.Title;
                eventInDb.EventTypeId = Event.EventTypeId;
                eventInDb.DateAndTime = Event.DateAndTime;
                eventInDb.Description = Event.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        // TRY TO GET THIS WORKING!!!!
        //[HttpPut]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddAttending(int id, string uid)
        //{
        //    var eventInDb = _context.Events.SingleOrDefault(x => x.Id == id);
        //    if (eventInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    var userInDb = _context.Users.SingleOrDefault(x => x.Id == uid);
        //    if (userInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    eventInDb.Attending.ToList().Add(uid);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}

    }
}
