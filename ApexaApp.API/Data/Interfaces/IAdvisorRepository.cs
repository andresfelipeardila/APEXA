using ApexaApp.API.Models;

namespace ApexaApp.API.Data.Interfaces
{
    public interface IAdvisorRepository
    {
        Task<IReadOnlyList<Advisor>> GetAdvisorsAsync();
        Task<IReadOnlyList<Advisor>> GetAdvisorByHealthStatusAsync(string healthStatus);
        Task<Advisor> GetAdvisorByIdAsync(int id);
    }
}