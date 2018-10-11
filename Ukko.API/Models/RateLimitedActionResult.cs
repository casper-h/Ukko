using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ukko.API.Models
{
    public class RateLimitedActionResult : IActionResult
    {
        private readonly OpenWeatherMapApiError Error;

        public RateLimitedActionResult(OpenWeatherMapApiError error)
        {
            this.Error = error;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(Error)
            {
                StatusCode = StatusCodes.Status429TooManyRequests,
                Value = new { message = Error.Message }
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
