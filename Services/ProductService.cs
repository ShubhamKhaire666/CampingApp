using CampingApp.Data;
using CampingApp.Extensions;
using CampingApp.Models;
using CampingApp.Services.Contract;

namespace CampingApp.Services
{
    public class ProductService : IProductService
    {
        private readonly CampingDbContext _dbContext;

        public ProductService(CampingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProductModel>> GetProducts()
        {
			try
			{
                var products = await _dbContext.products.Convert(_dbContext);
                return products;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
