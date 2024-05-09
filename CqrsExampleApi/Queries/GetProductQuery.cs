using CqrsExampleApi.Data;
using CqrsExampleApi.Entities;
using System.Linq;

namespace CqrsExampleApi.Queries
{
    public class GetProductQuery
    {
        private readonly ApplicationDbContext _context;

        public GetProductQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product Execute(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
