﻿using CampingApp.Entities;
using CampingApp.Models;

namespace CampingApp.Services.Contract
{
	public interface IEmployeeManagementService
	{
		Task<List<EmployeeModel>> GetEmployees();
		Task<List<EmployeeJobTitle>> GetJobTitles();
		Task<List<ReportToModel>> GetReportToEmployees();
		Task<Employee> AddEmployee(EmployeeModel employeeModel);
		Task UpdateEmployee(EmployeeModel employeeModel);
		Task DeleteEmployee(int Id);
	}
}
