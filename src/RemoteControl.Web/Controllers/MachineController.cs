using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using MediatR;
using RemoteControl.Shared.Commands;

namespace RemoteControl.Web.Controllers
{
    [RoutePrefix("api/v1/machine")]
    public class MachineController : ApiController
    {
        private readonly IMediator _mediator;

        public MachineController(IMediator mediator)
            => _mediator = mediator;

        [Route("")]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        [Route("register")]
        public async Task<IHttpActionResult> Post([FromBody]RegisterMachineCommand input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(input);

            if (result is Exception exception)
                return BadRequest(exception.Message);

            return new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.Created));
        }
    }
}