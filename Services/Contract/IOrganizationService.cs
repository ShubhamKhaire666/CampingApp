using CampingApp.Models;

namespace CampingApp.Services.Contract
{
    public interface IOrganizationService
    {
        Task<List<OrganizationModel>> GetHierarchy();
    }
}
