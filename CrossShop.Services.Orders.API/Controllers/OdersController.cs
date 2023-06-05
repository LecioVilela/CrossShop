using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossShop.Services.Orders.Application.Commands;
using CrossShop.Services.Orders.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossShop.Services.Orders.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetOrderById(id);

            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrder command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = id }, command);
        }
    }
}