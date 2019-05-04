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
    public class LeaperController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddLeaper(CreateLeaperRequest createRequest)
        {
            var repository = new LeaperRepository();

            var newLeaper = repository.AddLeaper(createRequest.Name,
                                                 createRequest.BudgetAmount);

            return Created($"/api/leaper/{newLeaper.Id}", newLeaper);
        }
    }
}
