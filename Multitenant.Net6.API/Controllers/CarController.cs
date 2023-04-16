using EasyCaching.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multitenant.Net6.API.Helpers;
using Multitenant.Net6.API.ViewModel;
using Multitenant.Net6.Application.Commands.Car;
using Multitenant.Net6.Application.Queries.Car;

namespace Multitenant.Net6.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IEasyCachingProvider _caching;

        public CarController(IMediator mediator,
            IEasyCachingProvider caching)
        {
            _caching = caching;

            _mediator = mediator;
        }

        [HttpPost(Name = "Car")]
        public async Task<IActionResult> Create([FromBody] CreateCarCommandVM commandVM)
        {
         
            await _mediator.Send(new CreateCarCommand(commandVM.Name,
                commandVM.Price.GetValueOrDefault(),
                commandVM.VIN,
                commandVM.Transmission,
                commandVM.ExteriorColor,
                commandVM.InteriorColor,
                HttpContext.GetTenantIdFromHeader()));

            return Ok();
        }

        [HttpPut(Name = "Car")]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommandVM commandVM)
        {

            await _mediator.Send(new UpdateCarCommand(commandVM.Id,
                commandVM.Name,
                commandVM.Price.GetValueOrDefault(),
                commandVM.VIN,
                commandVM.Transmission,
                commandVM.ExteriorColor,
                commandVM.InteriorColor));

            return Ok();
        }

        [HttpGet(Name = "Car")]
        public async Task<IActionResult> Get()
        {
            var tenantId = HttpContext.GetTenantIdFromHeader();

            var result = await _caching.GetAsync(tenantId, async () =>
                {
                    return await _mediator.Send(new GetCarByTenantId(HttpContext.GetTenantIdFromHeader()));
                }, TimeSpan.FromMinutes(25));

            return Ok(result.Value);
        }
    }
}
