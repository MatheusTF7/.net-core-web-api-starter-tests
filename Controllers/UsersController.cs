using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWebVale.Filter;
using ProjetoWebVale.Models;
using ProjetoWebVale.Utils;

namespace teams_back.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ProjetoWebValeDbContext _context;

        public UsersController(ProjetoWebValeDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUser(UserFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new QueryResult<User>();
            var query = _context.User.AsQueryable();

            if (filter.Id.HasValue)
                query = query.Where(c => c.Id == filter.Id.Value);

            result.PagingData.Page = filter.Page;
            result.PagingData.PageSize = filter.PageSize;
            result.PagingData.TotalItems = await query.CountAsync();
            result.TotalItems = await query.CountAsync();

            if (filter.getAll != true)
                query = query.ApplyPaging(filter);

            result.PagingData.PageItems = await query.CountAsync();

            result.Items = await query.ToListAsync();

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] UserLogin user) {
            var userLogin = _context.User.FirstOrDefault(c => c.Username == user.Username && c.Password == user.Password);
            if (userLogin != null)
                return Ok(new { message = "Login efetuado com sucesso"});
            else return BadRequest(new { message = "Informações inválidas"});
        }
        

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] long id, [FromBody] User User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != User.Id)
            {
                return BadRequest();
            }

            _context.Entry(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User.Password = User.NewPassword;

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = User.Id }, User);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var User = await _context.User.SingleOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            _context.User.Remove(User);
            await _context.SaveChangesAsync();

            return Ok(User);
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}