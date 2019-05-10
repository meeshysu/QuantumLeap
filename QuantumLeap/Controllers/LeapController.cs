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

        [HttpGet]
        public ActionResult RetrieveAllEventsAndLeaperInfo()
        {
            var repository = new LeapRepository();
            var retrieveLeap = repository.RetrieveEventAndLeaperInfo();
            return Ok(retrieveLeap);
        }

        [HttpPost]
        public ActionResult AddLeapee(CreateLeapRequest createRequest)
        {
            var repository = new LeapRepository();
            var randomLeaper = repository.GetRandomLeaper();
            int @leaperId = randomLeaper.Id;
            int @leapeeId = repository.GetRandomLeapee().Id;
            int @eventId = 0;

            if(randomLeaper.BudgetAmount > createRequest.Cost)
            {
                var newLeap = repository.RetrieveUpdatedBudgetFromLeap(leaperId, leapeeId, eventId, createRequest.Cost);
                return Created($"api/leap/{newLeap.Id}", newLeap);
            }
            else
            {
                return BadRequest("Sorry, you don't have enough money to leap.");
            }
        }
    }
}

//will have to write a comparison query for both the leaper's budget remaining and whether or not they can leap again 
