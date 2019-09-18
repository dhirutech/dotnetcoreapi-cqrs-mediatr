using System.Threading.Tasks;
using APICQRSMediatR.Models;
using APICQRSMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APICQRSMediatR.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/product
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await mediator.Send(new FindAllQuery());
            return new OkObjectResult(result);
        }

        // GET api/product/{code}
        [HttpGet("{code}")]
        public async Task<ActionResult> GetByCode([FromRoute]string code)
        {
            var result = await mediator.Send(new FindByCodeQuery { Code = code });
            return new OkObjectResult(result);
        }

        // POST api/product/create
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateProduct request)
        {
            var result = await mediator.Send(request);
            return new OkObjectResult(result);
        }

        // POST api/product/update
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateProduct request)
        {
            var result = await mediator.Send(request);
            return new OkObjectResult(result);
        }

        // POST api/product/delete
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DeleteProduct request)
        {
            var result = await mediator.Send(request);
            return new OkObjectResult(result);
        }
    }
}
