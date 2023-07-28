using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NopClone.Data.Context;
using NopClone.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.WebApi.Controllers
{
    public class ProductsController : ApiBaseController
    {
        private NopCloneDataContext _ctx;

        public ProductsController(NopCloneDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _ctx.Products
                .Include(x => x.Images)
                .Include(x => x.Attributes)
                .Include(x => x.Manufacturer)
                .ToList();

            return products;
        }

        [HttpGet("featured")]
        public IActionResult Featured()
        {
            var featuredProducts = _ctx.Products
                .Include(x => x.Images)
                .Where(x => x.ShowOnHomePage == true)
                .ToList();

            return Ok(featuredProducts);
        }

        // filter products by category
        [HttpGet("filterByCategory/{categoryId}")]
        public IActionResult GetByCategory(String categoryId)
        {
            var products = _ctx.ProductCategories
                .Include(x => x.Product)
                    .ThenInclude(p => p.Images)
                .Include(y => y.Category)
                .Where(x => x.CategoryId.Equals(categoryId))
                .Select(x => new
                {
                    x.CategoryId,
                    Id = x.ProductId,
                    Name = x.Product.Name,
                    x.Product.Price,
                    x.Product.Description,
                    CategoryName = x.Category.Name,
                    x.Category.ViewPath,
                    Images = x.Product.Images,
                    x.Product.StockQty
                })
                .ToList();

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            var product = _ctx.Products
                .Include(x => x.Images)
                .Single(x => x.Id == productId);

            return Ok(product);
        }
        
        
        [HttpPut("removeQtyFromStock/{productId}/{qty}")]
        public IActionResult Update(int productId, int qty)
        {
            var product = _ctx.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null) return NotFound();

            if (qty > product.StockQty)
                return BadRequest();
            
            product.StockQty -= qty;
            _ctx.SaveChanges();

            return Ok(product);
        }
    }
}
