using Bn_API.Data;
using Bn_API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Api.Dtos.OrderHeader;
using My_Api.Dtos.Product;
using My_Api.Mappers;

namespace My_Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Products, requires token, (?PageNumber=x, PageSize=x for pagination default page size - 20)
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            var lists = await _context.products.ToListAsync();
            var datList = lists.Select(s => s.to_productDto()).Skip(skipNumber).Take(query.PageSize);
            return Ok(datList);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductDto CreateLine)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var createLines = CreateLine.createProductDto();
            await _context.products.AddAsync(createLines);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = createLines.prod_id }, createLines.prod_id);
        }


        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto updateDtoProduct)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var lineModel = await _context.products.FirstOrDefaultAsync(x => x.prod_id == id);
            if (lineModel == null) { return NotFound(); }

            lineModel.prod_code = updateDtoProduct.prod_code;
            lineModel.prod_name = updateDtoProduct.prod_name;
            lineModel.prod_description = updateDtoProduct.prod_description;
            lineModel.prod_qty = updateDtoProduct.prod_qty;
            lineModel.prod_status = updateDtoProduct.prod_status;
            lineModel.prod_price = updateDtoProduct.prod_price;
            lineModel.prod_dateAdded = updateDtoProduct.prod_dateAdded;


            await _context.SaveChangesAsync();
            return Ok(lineModel.to_productDto());
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ItemModel = await _context.products.FirstOrDefaultAsync(x => x.prod_id == id);
            if (ItemModel == null) { return NotFound(); }
            _context.products.Remove(ItemModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
