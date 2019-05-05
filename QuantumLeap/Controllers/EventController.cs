using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuantumLeap.Data;
using QuantumLeap.Models;
using QuantumLeap.Validators;

namespace QuantumLeap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly EventRepository _eventRepository;
        readonly CreateEventRequestValidator _validator;

        public EventController()
        {
            _eventRepository = new EventRepository();
            _validator = new CreateEventRequestValidator();
        }

        [HttpPost]
        public ActionResult AddEvent(CreateEventRequest createRequest)
        {
            if (_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a name and event location" });
            }

            var newEvent = _eventRepository.AddEvent(createRequest.Name, 
                                                    createRequest.EventTime, 
                                                    createRequest.EventLocation, 
                                                    createRequest.NameOfEvent);

            return Created($"api/event/{newEvent.Id}", newEvent);
        }

        [HttpGet]
        public ActionResult GetAllEvents()
        {
            var events = _eventRepository.GetAllEvents();

            return Ok(events);
        }

    }
}