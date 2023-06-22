using MediatorProject.Commands;
using MediatorProject.Models;
using MediatorProject.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MediatorProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ListReconstuctionService _listReconstuctionService;

        public ListInfoController(IMediator mediator, ListReconstuctionService listReconstuctionService)
        {
            _mediator = mediator;
            _listReconstuctionService = listReconstuctionService;
        }

        [HttpPost("saveList")]
        public async Task<IActionResult> SaveList([FromBody] ListParsingModels content)
        {
            string listInfo = JsonConvert.SerializeObject(content);
            var command = new ListSaveCommand(content.ListName, content.UserId, listInfo);
            var listId = await _mediator.Send(command);
            return Ok(listId);
        }
        [HttpPost("loadAllLists")]
        public async Task<IActionResult> LoadAllLists([FromBody] RequestData requestData)
        {
            var command = new ListLoadAllCommand(requestData.userId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("loadSingleList")]
        public async Task<IActionResult> LoadSpecificList([FromBody] RequestData requestData)
        {
            var query = new ListLoadSingleCommand(requestData.userId, requestData.listName);
            var listContents = await _mediator.Send(query);

            if (listContents != null)
            {
                ListParsingModels listData = JsonConvert.DeserializeObject<ListParsingModels>(listContents);
                var listInfo = _listReconstuctionService.RebuildData(listData);
                return Ok(listInfo);
            }

            return NotFound();
        }

        [HttpDelete("deleteList")]
        public async Task<IActionResult> DeleteList([FromBody] RequestData requestData)
        {
            var command = new DeleteListCommand(requestData.userId, requestData.listName);
            await _mediator.Send(command);

            return Ok("deleted");
        }
    }
}

//===ENDPOINTS===//
//https://localhost:7016/api/ListInfo/saveList           //
//https://localhost:7016/api/ListInfo/loadAllLists       //
//https://localhost:7016/api/ListInfo/loadSingleList     //
//https://localhost:7016/api/ListInfo/deleteList         //