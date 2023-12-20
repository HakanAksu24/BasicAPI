using BasicAPI.Abstract;
using BasicAPI.Data;
using BasicAPI.Entities;
using BasicAPIApp.Concrete;

namespace BasicAPI.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        //public Task<IEnumerable<Product>> GetProductWithCategoryId(int id)
        //{
        //    return _context.Products.Where()
        //}
    }
}
