using AutoMapper;
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
    public class AccountController:ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationAccount>> CreateAccount([FromBody] CreateAccountBodyDto account)
        {
            var actionResult = await _mediator.Send(new CreateAccountCommand(
                account.name)
                );

            return Ok(actionResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            await _mediator.Send(new DeleteAccountCommand(id));
            return new NoContentResult();
        }
    }
}
