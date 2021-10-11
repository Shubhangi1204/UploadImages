using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.ApplicationModels;
using UploadImages.Models;

namespace UploadImages.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CommentsController: ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationComment>> CreateComment([FromBody] CreateCommentBodyDto comment)
        {
            var actionResult = await _mediator.Send(new CreateCommentCommand(
                comment.content,
                comment.postid,
                comment.creatorId,
                comment.creatorName
                )
                );

            return Ok(actionResult);
        }
    }
}
