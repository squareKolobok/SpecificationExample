using Microsoft.AspNetCore.Mvc;
using SpecificationExample.Tasks.Database;

namespace SpecificationExample.Tasks
{
    public class TasksController : Controller
    {
        private readonly ITaskRepository taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            return View(taskRepository.GetTasks());
        }

        public IActionResult AddTask()
        {
            return View();
        }

        [Route("/tasks/{id:int}")]
        public IActionResult ChangeTask(int id)
        {
            return View(taskRepository.GetTask(Specifications.ById(id)));
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}