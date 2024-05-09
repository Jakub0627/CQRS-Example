using CqrsExampleApi.Data;
using CqrsExampleApi.Entities;

namespace CqrsExampleApi.Commands
{
    public class CreateProductCommand
    {
        private readonly ApplicationDbContext _context;

        public CreateProductCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Execute(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
