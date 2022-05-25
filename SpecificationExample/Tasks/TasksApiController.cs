using AutoFilterSpecification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecificationExample.Tasks.Database;
using SpecificationExample.Tasks.Models;

namespace SpecificationExample.Tasks
{
    [ApiController]
    [Route("/api/tasks")]
    public class TasksApiController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;

        public TasksApiController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] UserTaskModification task)
        {
            taskRepository.AddTask(task);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put(int id, [FromBody] UserTaskModification task)
        {
            task.Id = id;
            taskRepository.UpdateTask(task);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Seacr([FromBody] SearchTaskViewModel search)
        {
            var filter = new AutoFilter<SearchTaskViewModel>(search);
            var where = filter.GetFilter<UserTaskInfo>();

            return StatusCode(StatusCodes.Status200OK, taskRepository.GetTasks(where));
        }
    }
}