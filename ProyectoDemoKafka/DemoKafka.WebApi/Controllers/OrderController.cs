using DemoKafka.Application.Dtos.RegisterOrder;
using DemoKafka.WebApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace DemoKafka.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderController : ControllerWrapper
    {

        [HttpPost("register")]
        public async Task<IActionResult> register(RegisterOrderRequestDto request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
