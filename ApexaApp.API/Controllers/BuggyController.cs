using System.Reflection.Metadata.Ecma335;
using ApexaApp.API.Data;
using ApexaApp.API.Dtos;
using ApexaApp.API.Errors;
using ApexaApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApexaApp.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApexaContext _context;
        public BuggyController(ApexaContext context)
        {
            _context = context;
        }

        // [HttpGet("testauth")]
        // [Authorize]
        // public ActionResult<string> GetSecretText()
        // {
        //     return "secret stuff";
        // }

        // [HttpGet("notfound")]
        // public ActionResult GetNotFoundRequest()
        // {
        //     var thing = _context.Advisors.Find(42);

        //     if(thing == null)
        //     {
        //         return NotFound(new ApiResponse(404));
        //     }

        //     return Ok();
        // }

        // [HttpGet("servererror")]
        // public ActionResult GetServerError()
        // {
        //     var thing = _context.Advisors.Find(42);

        //     var thingToReturn = thing.ToString();

        //     return Ok();
        // }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        // [HttpGet("badrequest/{id}")]
        // public ActionResult GetBadRequest(int id)
        // {
        //     return Ok();
        // }

        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("internalerror")]
        public IActionResult GetInternalError()
        {
            throw new Exception("This is a new exception");
        }

        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized(int id)
        {
            return Unauthorized();
        }

        [HttpPost("validationerror")]
        public IActionResult GetValidationError(AdvisorDto advisor)
        {
            return Ok();
        }
        
    }
}