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
    public class LeapeeController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddLeapee(CreateLeapeeRequest createRequest)
        {
            var repository = new LeapeeRepository();

            var newLeapee = repository.AddLeapee(createRequest.Name,
                                                 createRequest.Age,
                                                 createRequest.Gender);

            return Created($"/api/leapee/{newLeapee.Id}", newLeapee);
        }
    }
}