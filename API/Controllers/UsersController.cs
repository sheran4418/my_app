using Bn_API.Data;
using Bn_API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Api.Dtos.OrderHeader;
using My_Api.Dtos.Users;
using My_Api.Mappers;

namespace My_Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all users, requires token, (?PageNumber=x, PageSize=x for pagination default page size - 20)
        /// </summary>

        [HttpGet]
        [Authorize]       
        public async Task<IActionResult> Get([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            var items = await _context.users.ToListAsync();
            var itemD = items.Select(s => s.to_usersDto()).Skip(skipNumber).Take(query.PageSize);
            return Ok(itemD);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateUserDto CreateLine)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var createLines = CreateLine.to_CreateusersDto();
            await _context.users.AddAsync(createLines);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = createLines.user_id }, createLines.user_id);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateDtoHeader)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var lineModel = await _context.users.FirstOrDefaultAsync(x => x.user_id == id);
            if (lineModel == null) { return NotFound(); }

            lineModel.u_name = updateDtoHeader.u_name;
            lineModel.username = updateDtoHeader.username;
            lineModel.u_password = updateDtoHeader.u_password;
            lineModel.u_email = updateDtoHeader.u_email;
            lineModel.u_fname = updateDtoHeader.u_fname;
            lineModel.u_lname = updateDtoHeader.u_lname;
            lineModel.u_isactive = updateDtoHeader.u_isactive;


            await _context.SaveChangesAsync();
            return Ok(lineModel.to_usersDto());
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ItemModel = await _context.users.FirstOrDefaultAsync(x => x.user_id == id);
            if (ItemModel == null) { return NotFound(); }
            _context.users.Remove(ItemModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
