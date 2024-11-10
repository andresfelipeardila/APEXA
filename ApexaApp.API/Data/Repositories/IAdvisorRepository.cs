using ApexaApp.API.Models;

namespace ApexaApp.API.Data.Repositories
{
    public interface IAdvisorRepository
    {
        Task<IReadOnlyList<Advisor>> GetAdvisorsAsync();
        Task<IReadOnlyList<Advisor>> GetAdvisorByHealthStatusAsync(string healthStatus);
    }
}