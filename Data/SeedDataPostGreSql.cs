using CampingApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampingApp.Data
{
	public static class SeedDataPostGreSql
	{
		public static void AddEmployeeData(ModelBuilder modelBuilder)
		{
			//Add Employee Job Titles
			modelBuilder.Entity<EmployeeJobTitle>().HasData(new EmployeeJobTitle
			{
				EmployeeJobTitleId = 1,
				Name = "SM",
				Description = "Sales Manager"

			});
			modelBuilder.Entity<EmployeeJobTitle>().HasData(new EmployeeJobTitle
			{
				EmployeeJobTitleId = 2,
				Name = "TL",
				Description = "Team Leader"

			});
			modelBuilder.Entity<EmployeeJobTitle>().HasData(new EmployeeJobTitle
			{
				EmployeeJobTitleId = 3,
				Name = "SR",
				Description = "Sales Rep"
			});
			//Add Employees
			//Sales Manager
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 1,
				FirstName = "Bob",
				LastName = "Jones",
				Email = "bob.jones@oexl.com",
				Gender = "Male",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("10 Feb 1974"), DateTimeKind.Utc),
				ReportToEmpId = null,
				ImagePath = "/Images/Profile/BobJones.jpg",
				EmployeeJobTitleId = 1
			});
			//Team Leaders
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 2,
				FirstName = "Jenny",
				LastName = "Marks",
				Email = "jenny.marks@oexl.com",
				Gender = "Female",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("06 May 1976"), DateTimeKind.Utc),
				ReportToEmpId = 1,
				ImagePath = "/Images/Profile/JennyMarks.jpg",
				EmployeeJobTitleId = 2

			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 3,
				FirstName = "Henry",
				LastName = "Andrews",
				Email = "henry.andrews@oexl.com",
				Gender = "Male",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("06 May 1981"), DateTimeKind.Utc),
				ReportToEmpId = 1,
				ImagePath = "/Images/Profile/HenryAndrews.jpg",
				EmployeeJobTitleId = 2

			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 4,
				FirstName = "John",
				LastName = "Jameson",
				Email = "john.jameson@oexl.com",
				Gender = "Male",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("17 Apr 1984"), DateTimeKind.Utc),
				ReportToEmpId = 1,
				ImagePath = "/Images/Profile/JohnJameson.jpg",
				EmployeeJobTitleId = 2

			});
			//Sales Reps
			//Sales Team for Team Leader Name: Jenny, Id: 2
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 5,
				FirstName = "Noah",
				LastName = "Robinson",
				Email = "noah.robinson@oexl.com",
				Gender = "Male",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("12 Feb 1993"), DateTimeKind.Utc),
				ReportToEmpId = 2,
				ImagePath = "/Images/Profile/NoahRobinson.jpg",
				EmployeeJobTitleId = 3

			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 6,
				FirstName = "Elijah",
				LastName = "Hamilton",
				Email = "elijah.hamilton@oexl.com",
				Gender = "Male",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("17 Jun 1993"), DateTimeKind.Utc),
				ReportToEmpId = 2,
				ImagePath = "/Images/Profile/ElijahHamilton.jpg",
				EmployeeJobTitleId = 3

			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 7,
				FirstName = "Jamie",
				LastName = "Fisher",
				Email = "jamie.fisher@oexl.com",
				Gender = "Male",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("13 Jul 1992"), DateTimeKind.Utc),
				ReportToEmpId = 2,
				ImagePath = "/Images/Profile/JamieFisher.jpg",
				EmployeeJobTitleId = 3
			});
			//Sales Team for Team Leader Name: Henry, Id: 3

			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 8,
				FirstName = "Olivia",
				LastName = "Mills",
				Email = "olivia.mills@oexl.com",
				Gender = "Female",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("17 Apr 1990"), DateTimeKind.Utc),
				ReportToEmpId = 3,
				ImagePath = "/Images/Profile/OliviaMills.jpg",
				EmployeeJobTitleId = 3

			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 9,
				FirstName = "Benjamin",
				LastName = "Lucas",
				Email = "benjamin.lucas@oexl.com",
				Gender = "Male",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("12 Feb 1993"), DateTimeKind.Utc),
				ReportToEmpId = 3,
				ImagePath = "/Images/Profile/BenjaminLucas.jpg",
				EmployeeJobTitleId = 3

			});

			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 10,
				FirstName = "Sarah",
				LastName = "Henderson",
				Email = "sarah.henderson@oexl.com",
				Gender = "Female",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("12 Aug 1993"), DateTimeKind.Utc),
				ReportToEmpId = 3,
				ImagePath = "/Images/Profile/SarahHenderson.jpg",
				EmployeeJobTitleId = 3

			});
			//Sales Team for Team Leader Name: John, Id: 4          
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 11,
				FirstName = "Emma",
				LastName = "Lee",
				Email = "emma.lee@oexl.com",
				Gender = "Female",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("12 Nov 1995"), DateTimeKind.Utc),
				ReportToEmpId = 4,
				ImagePath = "/Images/Profile/EmmaLee.jpg",
				EmployeeJobTitleId = 3

			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 12,
				FirstName = "Ava",
				LastName = "Williams",
				Email = "ava.williams@oexl.com",
				Gender = "Female",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("12 May 1998"), DateTimeKind.Utc),
				ReportToEmpId = 4,
				ImagePath = "/Images/Profile/AvaWilliams.jpg",
				EmployeeJobTitleId = 3

			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 13,
				FirstName = "Angela",
				LastName = "Moore",
				Email = "angela.moore@oexl.com",
				Gender = "Female",
				DateOfBirth = DateTime.SpecifyKind(DateTime.Parse("06 Jul 1994"), DateTimeKind.Utc),
				ReportToEmpId = 4,
				ImagePath = "/Images/Profile/AngelaMoore.jpg",
				EmployeeJobTitleId = 3

			});
		}
	}
}
