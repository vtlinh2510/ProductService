using ProductService.Models;

namespace ProductService.Services
{
	public interface IProductService
	{
		IEnumerable<Product> GetProducts();
		Product GetProductById(int id);
		void AddProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int id);
	}
}
