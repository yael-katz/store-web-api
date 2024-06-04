using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> Get(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<List<Product>> Get();

    }
}