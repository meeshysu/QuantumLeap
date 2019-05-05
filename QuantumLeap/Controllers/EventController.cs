using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuantumLeap.Data;
using QuantumLeap.Models;

namespace QuantumLeap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddEvent(CreateEventRequest createRequest)
        {
            var repository = new EventRepository();

            var newEvent = repository.AddEvent(createRequest.Name,
                                               createRequest.EventTime,
                                               createRequest.EventLocation,
                                               createRequest.NameOfEvent);

            return Created($"/api/event/{newEvent.Id}", newEvent);
        }
    }
}