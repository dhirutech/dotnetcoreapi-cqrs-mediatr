using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using APICQRSMediatR.Models;
using APICQRSMediatR.Queries;
using APICQRSMediatR.Security.Logics;
using APICQRSMediatR.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APICQRSMediatR.Controllers
{
    [Route("api/product")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger = null;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET api/product
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new FindAllQuery());
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return LogExceptionHelper.CreateApiError(ex, _logger);
            }
        }

        // GET api/product/{code}
        [HttpGet("{code}")]
        public async Task<ActionResult> GetByCode([FromRoute]string code)
        {
            try
            {
                var result = await _mediator.Send(new FindByCodeQuery { Code = code });
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return LogExceptionHelper.CreateApiError(ex, _logger);
            }
        }

        [Authorize(Roles = "Administrator,Analyst")]
        // POST api/product/create
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateProduct request)
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"];
            var idToken = new IdentityToken(AuthenticationHeaderValue.Parse(authorizationHeader));
            try
            {
                _logger.LogInformation($"in create function...UserId-{idToken.UserId} and Role-{idToken.Role}");
                var result = await _mediator.Send(request);
                _logger.LogInformation("out from repo function...");

                throw new Exception("this is test exception");
                //return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return LogExceptionHelper.CreateApiError(ex, _logger);
            }
        }

        [Authorize(Roles = "Administrator,Analyst")]
        // POST api/product/update
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateProduct request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return LogExceptionHelper.CreateApiError(ex, _logger);
            }
        }

        [Authorize(Roles = "Administrator")]
        // POST api/product/delete
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DeleteProduct request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return LogExceptionHelper.CreateApiError(ex, _logger);
            }
        }
    }
}
