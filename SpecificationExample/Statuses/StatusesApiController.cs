using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecificationExample.Statuses.Database;
using SpecificationExample.Statuses.Models;

namespace SpecificationExample.Statuses
{
    [ApiController]
    [Route("/api/statuses")]
    public class StatusesApiController : ControllerBase
    {

        private readonly IStatusesRepository statusesRepository;

        public StatusesApiController(IStatusesRepository statusesRepository)
        {
            this.statusesRepository = statusesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, statusesRepository.GetStatuses());
        }

        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            var status = new Status() { Name = name };
            statusesRepository.AddStatus(status);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}