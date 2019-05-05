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

    public class LeaperController : ControllerBase
    {
        readonly LeaperRepository _leaperRepository;
        readonly CreateEventRequestValidator _validator;

        public LeaperController()
        {
            _leaperRepository = new LeaperRepository();
            _validator = new CreateEventRequestValidator();
        }


        [HttpPost]
        public ActionResult AddLeaper(CreateLeaperRequest createRequest)
        {
            var repository = new LeaperRepository();

            var newLeaper = repository.AddLeaper(createRequest.Name,
                                                 createRequest.BudgetAmount);

            return Created($"/api/leaper/{newLeaper.Id}", newLeaper);
        }

        [HttpGet]
        public ActionResult GetAllLeapers()
        {
            var leapers = _leaperRepository.GetAllLeapers();
            return Ok(leapers);
        }
    }
}
