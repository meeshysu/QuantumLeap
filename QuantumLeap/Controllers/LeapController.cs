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
            var retrieveLeap = repository.RetrieveAllEventsAndLeaperInfo();
            return Ok(retrieveLeap);
        }

        [HttpPost]
        public ActionResult AddLeaper(CreateLeapRequest createRequest)
        {
            var repository = new LeapRepository();
            var randomLeaper = repository.GetRandomLeaper();

            if (randomLeaper.BudgetAmount > createRequest.Cost)
            {
                var newLeap = repository.LeapAndBudget(leaperId, leapeeId, eventId, createRequest.Cost);
                return Created($"api/leapers/{newLeaper.Id}", newLeaper);
            }
            else
            {
                return BadRequest("Sorry you do not have enough of a budget to leap.");
            }
        }
    }
}

//will have to write a comparison query for both the leaper's budget remaining and whether or not they can leap again 
