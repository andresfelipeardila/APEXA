using ApexaApp.API.Models;

namespace ApexaApp.API.Services
{
    public interface IAdvisorService
    {
        Task<IReadOnlyList<Advisor>> GetAllAdvisorsAsync();
        Task<IReadOnlyList<Advisor>> GetAdvisorsByHealthStatusAsync(string healthStatus);
        Task DeleteAdvisorByIdAsync(int id);
        Task<Advisor> GetAdvisorByIdAsync(int id);
        Task AddAdvisor(Advisor advisor);
        Task UpdateAdvisor(Advisor advisor);
    }
}