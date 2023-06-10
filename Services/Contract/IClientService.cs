using CampingApp.Models;

namespace CampingApp.Services.Contract
{
	public interface IClientService
	{
		Task<List<ClientModel>> GetClients();
	}
}
