using CampingApp.Data;
using CampingApp.Extensions;
using CampingApp.Models;
using CampingApp.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace CampingApp.Services
{
	public class EmployeeManagementService : IEmployeeManagementService
	{
		private readonly CampingDbContext _dbContext;

		public EmployeeManagementService(CampingDbContext dbContext)
        {
			_dbContext = dbContext;
		}
        public async Task<List<EmployeeModel>> GetEmployees()
		{
			try
			{
				return await _dbContext.Employees.Convert();
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
