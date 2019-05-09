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

    public class LeapController : ControllerBase
    {
        readonly LeapRepository _leapRepository;
        readonly CreateLeapRequestValidator _validator;

        public LeapController()
        {
            _leapRepository = new LeapRepository();
            _validator = new CreateLeapRequestValidator();
        }

        [HttpPost]
        public ActionResult AddLeap(CreateLeapRequest createRequest)
        {
            if (_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "users must have a leap..." });
            }
        }
    }
}

//will have to write a comparison query for both the leaper's budget remaining and whether or not they can leap again 
