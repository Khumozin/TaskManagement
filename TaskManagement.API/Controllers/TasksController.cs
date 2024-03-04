using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs.Task;
using TaskManagement.Application.Features.Task.Commands.Requests;
using TaskManagement.Application.Features.Task.Queries.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<ActionResult<List<TaskDTO>>> Get()
        {
            var tasks = await _mediator.Send(new GetTaskListRequest());
            return Ok(tasks);
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> Get(Guid id)
        {
            var task = await _mediator.Send(new GetTaskDetailRequest { ID = id });
            return Ok(task);
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTaskDTO value)
        {
            var command = new CreateTaskCommand { taskDTO = value};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateTaskDTO value)
        {
            var command = new UpdateTaskCommand { TaskDTO = value, ID = id};
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("changecompletestatus")]
        public async Task<ActionResult> ChangeComplete(Guid id, [FromBody] ChangeTaskCompleteStatusDTO value)
        {
            var command = new UpdateTaskCommand { ChangeTaskCompleteStatus = value, ID = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTaskCommand { ID = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
