using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JWS.Api
{
    public class BaseController : ControllerBase
    {
        public readonly IMediator _mediator;
        public Guid? UserId
        {
            get
            {
                var id = User?.FindFirst("sub")?.Value;
                return string.IsNullOrEmpty(id) ? null : Guid.Parse(id);
            }
        }

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
