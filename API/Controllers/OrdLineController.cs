using Bn_API.Data;
using Bn_API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using My_Api.Dtos.OrderLine;
using My_Api.Helpers;
using My_Api.Mappers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace My_Api.Controllers
{
    [Route("api/orderline")]
    [ApiController]
    public class OrdLineController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrdLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OrderlineQuery query)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            var items = await _context.orderLine.ToListAsync();
            var itemD = items.Select(s => s.to_orderLineDto()).Skip(skipNumber).Take(query.PageSize);
            return Ok(itemD);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLineDto CreateLine)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var createLines = CreateLine.CreateorderLineDto();
            await _context.orderLine.AddAsync(createLines);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = createLines.ordLine_id }, createLines.ordLine_id);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLineDto updateDtoItem)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var lineModel = await _context.orderLine.FirstOrDefaultAsync(x => x.ordLine_id == id);
            if (lineModel == null) { return NotFound(); }

            lineModel.product_id = updateDtoItem.product_id;
            lineModel.qty = updateDtoItem.qty;
            lineModel.price = updateDtoItem.price;
            lineModel.Linestate = updateDtoItem.Linestate;
            lineModel.headerId = updateDtoItem.headerId;

            await _context.SaveChangesAsync();
            return Ok(lineModel.to_orderLineDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var p = _context.Database.ExecuteSqlRaw("orderLine_del  @headerId=" + id + ", @ex_type='delLine'");
            return Ok("Deleted");
        }
    }
}
