using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Data;
using ProductWebAPI.Modals;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext dbContext;


        public ProductController(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var product = await dbContext.Products.ToListAsync();
            return Ok(product);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async  Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = dbContext.Products.FindAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
        

        

        [HttpPost]
        public async Task<IActionResult> SendProducts(SendProducts sendProduct)
        {

            var product = new Product() {
                ProductName = sendProduct.ProductName,
                Price = sendProduct.Price,
                Qty = sendProduct.Qty
            };
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
                return Ok(product);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id,  UpdateProduct updateProduct)
        {
            var product = dbContext.Products.Find(id);
            if(product != null)
            {
                product.Qty = updateProduct.Qty;
                product.Price = updateProduct.Price;
                product.ProductName = updateProduct.ProductName;
                
                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deleteAsync([FromRoute] int id)
        {
            var product = await  dbContext.Products.FindAsync(id);
            if (product != null)
            {
                 dbContext.Products.Remove(product);
                return Ok($"{product.ProductName} has been deleted");
            }
            else
            {
                return NotFound();
            }
            
            
        }

    }
}