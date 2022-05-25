using Microsoft.AspNetCore.Mvc;
using SpecificationExample.Statuses.Database;

namespace SpecificationExample.Statuses
{
    public class StatusesController : Controller
    {

        private readonly IStatusesRepository statusesRepository;

        public StatusesController(IStatusesRepository statusesRepository)
        {
            this.statusesRepository = statusesRepository;
        }

        public IActionResult Index()
        {
            return View(statusesRepository.GetStatuses());
        }

        public IActionResult AddStatus()
        {
            return View();
        }
    }
}