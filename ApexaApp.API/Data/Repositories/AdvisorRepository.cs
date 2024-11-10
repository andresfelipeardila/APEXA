using ApexaApp.API.Models;
using Microsoft.EntityFrameworkCore;
using static ApexaApp.API.Helpers.Enums;

namespace ApexaApp.API.Data.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly ApexaContext _context;
   
        public AdvisorRepository(ApexaContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Advisor>> GetAdvisorsAsync()
        {
            return await _context.Advisors.ToListAsync();
        }

        public async Task<IReadOnlyList<Advisor>> GetAdvisorByHealthStatusAsync(string healthStatus)
        {
            return await _context.Advisors
            .Where(a => a.HealthStatus == Enum.Parse<HealthStatus>(healthStatus))
            .ToListAsync();
        }
    }
}