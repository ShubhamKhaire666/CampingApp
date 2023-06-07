using CampingApp.Data;
using CampingApp.Entities;
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

		public async Task<List<EmployeeJobTitle>> GetJobTitles()
		{
			try
			{
				return await _dbContext.EmployeeJobTitles.ToListAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
