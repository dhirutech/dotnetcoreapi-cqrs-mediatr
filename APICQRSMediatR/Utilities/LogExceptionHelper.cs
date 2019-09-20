using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APICQRSMediatR.Utilities
{
    public static class LogExceptionHelper
    {
        public static ObjectResult CreateApiError(Exception ex, ILogger logger)
        {
            logger.LogError(ex.Message);
            var errorStatus = HttpStatusCode.InternalServerError;
            var res = new ObjectResult(ex.Message);
            res.StatusCode = (int?)errorStatus;
            return res;
        }
    }
}
