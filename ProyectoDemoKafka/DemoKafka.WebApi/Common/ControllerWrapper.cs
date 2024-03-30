using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoKafka.WebApi.Common
{
    public abstract class ControllerWrapper : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator =>
            mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
