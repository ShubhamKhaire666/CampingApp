using CampingApp.Models;

namespace CampingApp.Services.Contract
{
    public interface IProductService
    {

        Task<List<ProductModel>> GetProducts();
    }
}
