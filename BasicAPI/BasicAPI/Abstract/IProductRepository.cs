using BasicAPI.Entities;

namespace BasicAPI.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        //Task<IEnumerable<Product>> GetProductWithCategoryId(int id);
        //Gerekli özel durum tanımlamaları için açıldı.
    }
}
