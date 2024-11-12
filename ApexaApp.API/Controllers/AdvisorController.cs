using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApexaApp.API.Data.Interfaces;
using ApexaApp.API.Data.Repositories;
using ApexaApp.API.Data.Specifications;
using ApexaApp.API.Dtos;
using ApexaApp.API.Errors;
using ApexaApp.API.Helpers;
using ApexaApp.API.Models;
using ApexaApp.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApexaApp.API.Controllers
{
    public class AdvisorController : BaseApiController
    {
        private readonly IAdvisorService _advisorService;
        private readonly IGenericRepository<Advisor> _advisorRepo;
        private readonly IMapper _mapper;

        public AdvisorController(IAdvisorService advisorService, 
        IGenericRepository<Advisor> advisorRepo, 
        IMapper mapper)
        {
            _advisorService = advisorService;
            _advisorRepo = advisorRepo;
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

        /// <summary>
        /// Get Advisors based on the Advisors Spec Params(We could add search field or other filters)
        /// </summary>
        /// <param name="advisorParams">Params we need to filter the advisors list</param>
        /// <returns>Filtered list of Advisors(Paginated)</returns>
        [HttpGet]
        public async Task<ActionResult<Pagination<AdvisorDto>>> GetAdvisors(
            [FromQuery]AdvisorSpecParams advisorParams) 
        {

            var spec = new AdvisorsSpecification(advisorParams);

            var countSpec = new AdvisorsForCountSpecification(advisorParams);

            var advisors = await _advisorRepo.ListAsync(spec);

            var totalItems = await _advisorRepo.CountAsync(countSpec);
               
            var data = _mapper.Map<IReadOnlyList<Advisor>, IReadOnlyList<AdvisorDto>>(advisors);

            return Ok(new Pagination<AdvisorDto>(advisorParams.PageIndex,
            advisorParams.PageSize, totalItems, data));
        }

        /// <summary>
        /// Delete an advisor 
        /// </summary>
        /// <param name="id">Id of the Advisor to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvisor(int id) 
        {
            var advisor = await _advisorService.GetAdvisorByIdAsync(id);
            
            //In case it doesn't find the advisor throws an error
            if(advisor==null)
                return NotFound();

            await _advisorService.DeleteAdvisorByIdAsync(id);
            return Ok();
        }

        /// <summary>
        /// Adds a new advisor
        /// </summary>
        /// <param name="advisor">Advisor object</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public async Task<IActionResult> AddAdvisor(AdvisorDto advisor)
        {
            var advisorToAdd = await _advisorService.GetAdvisorByIdAsync(advisor.Id);
            
            //In case it doesn't find the advisor throws an error
            if(advisorToAdd!=null)
                throw new Exception("Advisor already created with that SIN Number");

            var newAdvisor = _mapper.Map<Advisor>(advisor);

            await _advisorService.AddAdvisor(newAdvisor);

            return Ok();
        }

        /// <summary>
        /// Updates an advisor
        /// </summary>
        /// <param name="advisor">Advisor to update</param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAdvisor(AdvisorDto advisor)
        {
            if(advisor == null)
                 return NotFound();

            var advisorToUpdate = _mapper.Map<Advisor>(advisor);

            await _advisorService.UpdateAdvisor(advisorToUpdate);

            return Ok();

        }
    }
}