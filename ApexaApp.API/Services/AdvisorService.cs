using ApexaApp.API.Data.Interfaces;
using ApexaApp.API.Data.Repositories;
using ApexaApp.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<Advisor> GetAdvisorByIdAsync(int id)
        {
            var advisor = await _advisorRepo.GetAdvisorByIdAsync(id);
            return advisor!;
        }

        public async Task DeleteAdvisorByIdAsync(int id)
        {
            var advisor = await _advisorRepo.GetAdvisorByIdAsync(id);
            if(advisor==null)
                return;
        
            _unitOfWork.Repository<Advisor>().Delete(advisor);
            if(await _unitOfWork.Complete()){
                return;
            }
            throw new Exception("Deleting the advisor failed on save");  
            
        }

        public async Task AddAdvisor(Advisor advisor)
        {
            _unitOfWork.Repository<Advisor>().Add(advisor);
             if(await _unitOfWork.Complete()){
                return;
            }
            throw new Exception("Creating the advisor failed on save");  
        }

        public async Task UpdateAdvisor(Advisor advisor)
        {
            _unitOfWork.Repository<Advisor>().Update(advisor);
             if(await _unitOfWork.Complete()){
                return;
            }
            throw new Exception("Updating the advisor failed on save");  
        }

    }
}