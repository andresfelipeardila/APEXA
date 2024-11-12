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
    /// <summary>
    /// Controller to test the API common errors
    /// </summary>
    public class BuggyController : BaseApiController
    {
        private readonly ApexaContext _context;
        public BuggyController(ApexaContext context)
        {
            _context = context;
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }


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