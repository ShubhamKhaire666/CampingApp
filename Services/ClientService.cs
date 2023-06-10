using CampingApp.Data;
using CampingApp.Extensions;
using CampingApp.Models;
using CampingApp.Services.Contract;

namespace CampingApp.Services
{
	public class ClientService : IClientService
	{
		private readonly CampingDbContext dbContext;

		public ClientService(CampingDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<List<ClientModel>> GetClients()
		{
			try
			{
				return await this.dbContext.Clients.Convert(dbContext);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
