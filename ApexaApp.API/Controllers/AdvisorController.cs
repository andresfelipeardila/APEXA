using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApexaApp.API.Data.Repositories;
using ApexaApp.API.Dtos;
using ApexaApp.API.Errors;
using ApexaApp.API.Models;
using ApexaApp.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApexaApp.API.Controllers
{
    public class AdvisorController : BaseApiController
    {
        private readonly IAdvisorService _advisorService;
        private readonly IMapper _mapper;

        public AdvisorController(IAdvisorService advisorService, IMapper mapper)
        {
            _advisorService = advisorService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all advisors 
        /// </summary>
        /// <returns>List of all advisors</returns>
        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<AdvisorDto>>> GetAllAdvisorsAsync()
        {
            var advisors = await _advisorService.GetAllAdvisorsAsync();

            if(advisors == null) return NotFound(new ApiResponse(404));

            var data = _mapper.Map<IReadOnlyList<Advisor>, IReadOnlyList<AdvisorDto>>(advisors);

            return Ok(data);
        }

        // <summary>
        // Get all advisors by Health Status
        // </summary>
        // <param name="healthStatus">Heal Statatus(Green, Yellow, Red)</param>
        // <returns>List of advisors</returns>
        [HttpGet("healthstatus/{healthStatus}")]
        public async Task<ActionResult<IReadOnlyList<AdvisorDto>>> GetAllAdvisorsByHealthStatusAsync(string healthStatus)
        {
            var advisors = await _advisorService.GetAdvisorsByHealthStatusAsync(healthStatus);

            if(advisors == null) return NotFound(new ApiResponse(404));

            var data = _mapper.Map<IReadOnlyList<Advisor>, IReadOnlyList<AdvisorDto>>(advisors);

            return Ok(data);
        }
    }
}