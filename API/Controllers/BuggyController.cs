using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("not-found")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }
        [HttpGet("bad-request")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "This is a bad request" });
        }
        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }
        [HttpGet("validation-error")]
        public IActionResult GetValidationError()
        {
            ModelState.AddModelError("Problem1", "This is the first error");
            ModelState.AddModelError("Problem2", "This is the second error");
            return ValidationProblem();
        }
        [HttpGet("server-error")]
        public IActionResult GetServerError()
        {
            throw new Exception("This is a server error");
        }
    }
}