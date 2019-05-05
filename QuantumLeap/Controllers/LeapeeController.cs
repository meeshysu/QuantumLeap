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
    public class LeapeeController : ControllerBase
    {
        readonly LeapeeRepository _leapeeRepository;
        readonly CreateEventRequestValidator _validator;

        public LeapeeController()
        {
            _leapeeRepository = new LeapeeRepository();
            _validator = new CreateEventRequestValidator();
        }

        [HttpPost]
        public ActionResult AddLeapee(CreateLeapeeRequest createRequest)
        {
            var repository = new LeapeeRepository();

            var newLeapee = repository.AddLeapee(createRequest.Name,
                                                 createRequest.Age,
                                                 createRequest.Gender);

            return Created($"/api/leapee/{newLeapee.Id}", newLeapee);
        }

        [HttpGet]
        public ActionResult GetAllLeapees()
        {
            var events = _leapeeRepository.GetAllLeapees();
            return Ok(events);
        }
    }
}