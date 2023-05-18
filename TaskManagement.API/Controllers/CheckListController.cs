using API.Controllers;
using TaskManagement.Application.Features.Checklist.CQRS.Commands;
using TaskManagement.Application.Features.Checklist.DTOs;
using TaskManagement.Application.Features.Checklist.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;


namespace TaskManagement.API.Controllers
{
    public class CheckListController : BaseApiController
    {
        [HttpGet] //api/CheckList
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new GetCheckListListQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCheckList(int id)
        {
            return HandleResult(await Mediator.Send(new GetCheckListDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckList(CreateCheckListDto createCheckList)
        {
            return HandleResult(await Mediator.Send(new CreateCheckListCommand { CreateCheckListDto = createCheckList }));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRate(UpdateCheckListDto updateCheckList)
        {
            return HandleResult(await Mediator.Send(new UpdateCheckListCommand { UpdateCheckListDto = updateCheckList }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActvity(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCheckListCommand { Id = id }));
        }
    }
}
