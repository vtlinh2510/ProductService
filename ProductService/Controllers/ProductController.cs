﻿using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public IActionResult GetAllProducts()
		{
			var products = _productService.GetProducts();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public IActionResult GetProductById(int id)
		{
			var product = _productService.GetProductById(id);
			if (product == null) return NotFound();
			return Ok(product);
		}

		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			_productService.AddProduct(product);
			return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateProduct(int id, Product product)
		{
			if (id != product.Id) return BadRequest();
			_productService.UpdateProduct(product);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			_productService.DeleteProduct(id);
			return NoContent();
		}
	}

}
