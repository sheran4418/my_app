using Bn_API.Data;
using Bn_API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Api.Dtos.OrderHeader;
using My_Api.Dtos.OrderLine;
using My_Api.Mappers;

namespace My_Api.Controllers
{
    [Route("api/orderheader")]
    [ApiController]
    public class OrderHeaderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderHeaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
       // [Authorize]
        public async Task<IActionResult> Get([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            var items = await _context.orderHeader.ToListAsync();
            var itemD = items.Select(s => s.to_orderHeaderDto()).Skip(skipNumber).Take(query.PageSize);
            return Ok(itemD);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHeaderDto CreateLine)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var createLines = CreateLine.CreateHeadereDto();
            await _context.orderHeader.AddAsync(createLines);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = createLines.ord_id }, createLines.ord_id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderHeaderDto updateDtoHeader)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var lineModel = await _context.orderHeader.FirstOrDefaultAsync(x => x.ord_id == id);
            if (lineModel == null) { return NotFound(); }

            lineModel.user_id = updateDtoHeader.user_id;
            lineModel.date = updateDtoHeader.date;
            lineModel.Headerstate = updateDtoHeader.Headerstate;
       

            await _context.SaveChangesAsync();
            return Ok(lineModel.to_orderHeaderDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var p = _context.Database.ExecuteSqlRaw("orderHeader_del  @ordId=" + id + ", @ex_type='delHeader'");
            return Ok("Deleted");
        }

    }
}
