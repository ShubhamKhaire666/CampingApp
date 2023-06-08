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

		public async Task<Employee> AddEmployee(EmployeeModel employeeModel)
		{
			try
			{
				Employee employeeToAdd = employeeModel.Convert();

				var result = await _dbContext.Employees.AddAsync(employeeToAdd);
				await _dbContext.SaveChangesAsync();

				return result.Entity;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task DeleteEmployee(int Id)
		{
			try
			{
				Employee employeeToDelete = await _dbContext.Employees.FindAsync(Id);

				if (employeeToDelete != null)
				{
					_dbContext.Remove(employeeToDelete);

					await _dbContext.SaveChangesAsync();
				}

			}
			catch (Exception)
			{

				throw;
			}
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

		public async Task<List<ReportToModel>> GetReportToEmployees()
		{
			try
			{
				var employees = await (from e in _dbContext.Employees join
									   j in _dbContext.EmployeeJobTitles
									   on e.EmployeeJobTitleId equals j.EmployeeJobTitleId
									   where j.Name.ToUpper() == "TL" || j.Name.ToUpper() == "SM"
									   select new ReportToModel
									   {
										   ReportToEmpId = e.Id,
										   ReportToName = e.FirstName + " " + e.LastName.Substring(0, 1).ToUpper() + "."
									   }).ToListAsync();

				employees.Add(new ReportToModel { ReportToEmpId = null, ReportToName = "<None>" });
				return employees.OrderBy(o=>o.ReportToEmpId).ToList();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task UpdateEmployee(EmployeeModel employeeModel)
		{
			try
			{
				Employee employeeToUpdate = await _dbContext.Employees.FindAsync(employeeModel.Id);

				if(employeeToUpdate != null)
				{
					employeeToUpdate.Email = employeeModel.Email;
					employeeToUpdate.FirstName = employeeModel.FirstName;
					employeeToUpdate.LastName = employeeModel.LastName;
					employeeToUpdate.Gender = employeeModel.Gender;
					employeeToUpdate.DateOfBirth = employeeModel.DateOfBirth;
					employeeToUpdate.ReportToEmpId = employeeModel.ReportToEmpId;
					employeeToUpdate.EmployeeJobTitleId = employeeModel.EmployeeJobTitleId;
					employeeToUpdate.ImagePath = employeeModel.ImagePath;
				
					await _dbContext.SaveChangesAsync();
				}

			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}
