// using API.Controllers;
// using TaskManagement.Application.Features.Tasks.CQRS.Commands;
// using TaskManagement.Application.Features.Tasks.DTOs;
// using TaskManagement.Application.Features.Tasks.CQRS.Queries;
// using Microsoft.AspNetCore.Mvc;
// using TaskManagement.Application.Features.Tasks.CQRS;

// namespace TaskManagement.API.Controllers
// {
//     public class CheckListController : BaseApiController
//     {
//         [HttpGet] //api/CheckList
//         public async Task<IActionResult> GetActivities()
//         {
//             return HandleResult(await Mediator.Send(new GetCheckListListQuery()));
//         }


//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetCheckList(int id)
//         {
//             return HandleResult(await Mediator.Send(new GetCheckListDetailQuery { Id = id }));
//         }

//         [HttpPost]
//         public async Task<IActionResult> CreateCheckList(CreateCheckListDto createCheckList)
//         {
//             return HandleResult(await Mediator.Send(new CreateCheckListCommand { CreateCheckListDto = createCheckList }));
//         }


//         [HttpPut]
//         public async Task<IActionResult> UpdateRate(UpdateCheckListDto updateCheckList)
//         {
//             return HandleResult(await Mediator.Send(new UpdateCheckListCommand { UpdateTasksDto = updateTasks }));
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteActvity(int id)
//         {
//             return HandleResult(await Mediator.Send(new DeleteTasksCommand { Id = id }));
//         }
//     }
// }
