using CampingApp.Data;
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

		public static Employee Convert(this EmployeeModel employeeModel)
		{
			return new Employee
			{
				FirstName = employeeModel.FirstName,
				LastName = employeeModel.LastName,
				EmployeeJobTitleId = employeeModel.EmployeeJobTitleId,
				Email = employeeModel.Email,
				DateOfBirth = employeeModel.DateOfBirth,
				ReportToEmpId = employeeModel.ReportToEmpId,
				Gender = employeeModel.Gender,
				ImagePath = employeeModel.Gender.ToUpper() == "MALE" ? "/Images/Profile/MaleDefault.jpg" :
				"/Images/Profile/FemaleDefault.jpg"
			};
		}

		public static async Task<List<ProductModel>> Convert(this IQueryable<Product> products, CampingDbContext _dbcontext)
		{
			return await ( from prod in products
						   join prodCat in _dbcontext.ProductCategories
						   on prod.CategoryId equals prodCat.Id
						   select new ProductModel
						   {
							   Id = prod.Id,
							   Name = prod.Name,
							   Description = prod.Description,
							   ImagePath = prod.ImagePath,
							   Price = prod.Price,
							   CategoryId = prod.CategoryId,
							   CategoryName = prodCat.Name
						   }).ToListAsync();
		}
	}
}
