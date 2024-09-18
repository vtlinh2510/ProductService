using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Services
{
	public class ProductService:IProductService
	{
		private readonly ApplicationDbContext _context;

		public ProductService(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Product> GetProducts()
		{
			return _context.Products.ToList();
		}

		public Product GetProductById(int id)
		{
			return _context.Products.Find(id);
		}

		public void AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}

		public void UpdateProduct(Product product)
		{
			_context.Entry(product).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteProduct(int id)
		{
			var product = _context.Products.Find(id);
			if (product != null)
			{
				_context.Products.Remove(product);
				_context.SaveChanges();
			}
		}
	}
}
