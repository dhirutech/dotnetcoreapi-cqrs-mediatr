using APICQRSMediatR.Models;
using APICQRSMediatR.Security.Interfaces;
using APICQRSMediatR.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICQRSMediatR.Controllers
{
    [Route("api/access")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccessController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AccessController> _logger = null;

        public AccessController(IAuthService authService, ILogger<AccessController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("getaccesstoken")]
        public async Task<ActionResult> GetAccessToken(LoginUser loginUser)
        {
            try
            {
                var accessToken = await _authService.GetAccessToken(loginUser.Username, loginUser.Password);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                return Ok(accessToken);
            }
            catch (Exception ex)
            {
                return LogExceptionHelper.CreateApiError(ex, _logger);
            }
        }
    }
}
