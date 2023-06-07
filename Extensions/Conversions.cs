using CampingApp.Entities;
using CampingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CampingApp.Extensions
{
	public static class Conversions
	{
		public static async Task<List<EmployeeModel>> Convert(this IQueryable<Employee> employees)
		{
			return await (from e in employees
						  select new EmployeeModel
						  {
							  Id = e.Id,
							  FirstName = e.FirstName,
							  LastName = e.LastName,
							  EmployeeJobTitleId = e.EmployeeJobTitleId,
							  Email = e.Email,
							  DateOfBirth = e.DateOfBirth,
							  ReportToEmpId = e.ReportToEmpId,
							  Gender = e.Gender,
							  ImagePath = e.ImagePath
						  }).ToListAsync();
		}
	}
}
