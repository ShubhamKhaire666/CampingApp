using CampingApp.Data;
using CampingApp.Extensions;
using CampingApp.Models;
using CampingApp.Services.Contract;

namespace CampingApp.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly CampingDbContext dbContext;

        public OrganizationService(CampingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<OrganizationModel>> GetHierarchy()
        {
            try
            {
                return await dbContext.Employees.ConvertToHierarchy(dbContext); 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
