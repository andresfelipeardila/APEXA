using ApexaApp.API.Data.Interfaces;
using ApexaApp.API.Data.Repositories;
using ApexaApp.API.Models;

namespace ApexaApp.API.Services
{
    public class AdvisorService : IAdvisorService
    {
        private readonly IAdvisorRepository _advisorRepo;
        private readonly IUnitOfWork _unitOfWork;


        public AdvisorService(IAdvisorRepository advisorRepo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _advisorRepo = advisorRepo;
        }
        public async Task<IReadOnlyList<Advisor>> GetAllAdvisorsAsync()
        {
            var advisors = await _unitOfWork.Repository<Advisor>().ListAllAsync();
            return advisors;
        }

        public async Task<IReadOnlyList<Advisor>> GetAdvisorsByHealthStatusAsync(string healthStatus)
        {
            var advisors = await _advisorRepo.GetAdvisorByHealthStatusAsync(healthStatus);
            return advisors;
        }

    }
}