using CampingApp.Models;

namespace CampingApp.Services.Contract
{
	public interface IEmployeeManagementService
	{
		Task<List<EmployeeModel>> GetEmployees();
	}
}
