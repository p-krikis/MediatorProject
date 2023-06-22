using MediatorProject.Commands;
using MediatorProject.Models;
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

        public ListInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("saveList")]
        public async Task<IActionResult> SaveList([FromBody] ListParsingModels content)
        {
            string listInfo = JsonConvert.SerializeObject(content);
            var command = new ListSaveCommand(content.ListName, content.UserId, listInfo);
            var listId = await _mediator.Send(command);
            return Ok(listId);
        }
    }
}


//[HttpPost("saveListData")]
//public async Task<IActionResult> SaveList([FromBody] ListParsingModels content)
//{
//    string listName = content.ListName;
//    string userId = content.UserId;
//    string jsonData = JsonConvert.SerializeObject(content);
//    int listId = await _listDataHandlingService.SaveListData(listName, userId, jsonData);
//    return Ok();
//}

//[HttpPost("getAllLists")]
//public async Task<IActionResult> LoadAllLists([FromBody] RequestData content)
//{
//    string targetUserId = content.userId;
//    var lists = await _listDataHandlingService.LoadAllLists(targetUserId);
//    return Ok(lists);
//}

//[HttpPost("loadspecificlist")]
//public async Task<IActionResult> loadspecificlist([FromBody] RequestData content)
//{
//    string targetuserid = content.userId;
//    string targetlistname = content.listName;
//    var listcontents = await _listDataHandlingService.LoadSingleList(targetuserid, targetlistname);
//    ListParsingModels listData = JsonConvert.DeserializeObject<ListParsingModels>(listcontents);
//    var listInfo = _listDataReconstructionService.RebuildData(listData);
//    return Ok(listInfo);
//}

//[HttpDelete("deleteList")]
//public async Task<IActionResult> DeleteList([FromBody] RequestData content)
//{
//    string targetUserId = content.userId;
//    string targetListName = content.listName;
//    await _listDataHandlingService.DeleteSpecificList(targetUserId, targetListName);
//    return Ok("deleted");
//}