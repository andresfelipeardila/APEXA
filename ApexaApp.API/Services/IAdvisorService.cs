using ApexaApp.API.Models;

namespace ApexaApp.API.Services
{
    public interface IAdvisorService
    {
        Task<IReadOnlyList<Advisor>> GetAllAdvisorsAsync();
        Task<IReadOnlyList<Advisor>> GetAdvisorsByHealthStatusAsync(string healthStatus);
    }
}