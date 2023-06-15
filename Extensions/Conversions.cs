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
            return await (from prod in products
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

        public static async Task<List<ClientModel>> Convert(this IQueryable<Client> clients, CampingDbContext _dbcontext)
        {
            return await (from client in clients
                          join r in _dbcontext.RetailOutlets
                          on client.RetailOutletId equals r.Id
                          select new ClientModel
                          {
                              Id = client.Id,
                              Email = client.Email,
                              FirstName = client.FirstName,
                              LastName = client.LastName,
                              JobTitle = client.JobTitle,
                              PhoneNumber = client.PhoneNumber,
                              RetailOutletId = client.RetailOutletId,
                              RetailOutletName = r.Name,
                              RetailOutletLocation = r.Location
                          }).ToListAsync();
        }

        public static async Task<List<OrganizationModel>> ConvertToHierarchy(this IQueryable<Employee> employees, CampingDbContext dbContext)
        {
            return await (from e in employees
                          join t in dbContext.EmployeeJobTitles
                          on e.EmployeeJobTitleId equals t.EmployeeJobTitleId
                          orderby e.Id
                          select new OrganizationModel
                          {
                              EmployeeId = e.Id.ToString(),
                              ReportsToId = e.ReportToEmpId != null ? e.ReportToEmpId.ToString() : "",
                              Email = e.Email,
                              FirstName = e.FirstName,
                              LastName = e.LastName,
                              ImagePath = e.ImagePath,
                              JobTitle = t.Name
                          }).ToListAsync();
        }
        public static Appointment Convert(this AppointmentModel appointments)
        {
            return new Appointment
            {
                EmployeeId = appointments.Id,
                Description = appointments.Description,
                IsAllDay = appointments.IsAllDay,
                RecurrenceException = appointments.RecurrenceException,
                RecurrenceId = appointments.RecurrenceId,
                RecurrenceRule = appointments.RecurrenceRule,
                StartTime = appointments.StartTime,
                EndTime = appointments.EndTime,
                Location = appointments.Location,
                Subject = appointments.Subject
            };
        }

        public static async Task<List<AppointmentModel>> Convert(this IQueryable<Appointment> appointment)
        {

            return await (from a in appointment
                          select new AppointmentModel
                          {
                              Id = a.Id,
                              EmployeeId = a.EmployeeId,
                              Description = a.Description,
                              IsAllDay = a.IsAllDay,
                              RecurrenceException = a.RecurrenceException,
                              RecurrenceId = a.RecurrenceId,
                              RecurrenceRule = a.RecurrenceRule,
                              StartTime = a.StartTime,
                              EndTime = a.EndTime,
                              Location = a.Location,
                              Subject = a.Subject
                          }).ToListAsync();
        }

        public static async Task<Employee> GetEmployeeObject(this System.Security.Claims.ClaimsPrincipal user, CampingDbContext dbContext)
        {
            var emailAddress = user.Identity.Name;
            var employee = await dbContext.Employees.Where(e => e.Email.ToLower() == emailAddress.ToLower()).SingleOrDefaultAsync();

            return employee;
        }

    }
}
