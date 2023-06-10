using CampingApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampingApp.Data
{
	public class CampingDbContext:DbContext
	{

		public CampingDbContext(DbContextOptions<CampingDbContext> options):base(options)
        {

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//SeedData.AddEmployeeData(modelBuilder);
			 SeedDataPostGreSql.AddEmployeeData(modelBuilder);
		}

		public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeJobTitle> EmployeeJobTitles { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> products { get; set; }
   
	
	}
}
