using API.Controllers;
using TaskManagement.Application.Features.Tasks.CQRS.Commands;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Features.Tasks.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Tasks.CQRS;

namespace TaskManagement.API.Controllers
{
    public class TasksController : BaseApiController
    {
        [HttpGet] //api/Tasks
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new GetTasksListQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasks(int id)
        {
            return HandleResult(await Mediator.Send(new GetTasksDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTasks(CreateTasksDto createTasks)
        {
            return HandleResult(await Mediator.Send(new CreateTasksCommand { CreateTasksDto = createTasks }));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRate(UpdateTasksDto updateTasks)
        {
            return HandleResult(await Mediator.Send(new UpdateTasksCommand { UpdateTasksDto = updateTasks }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActvity(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteTasksCommand { Id = id }));
        }
    }
}
