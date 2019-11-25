using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWebVale.Models;

namespace teams_back.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly ProjetoWebValeDbContext _context;

        public TasksController(ProjetoWebValeDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<ProjetoWebVale.Models.Task> GetTask()
        {
            return _context.Task.ToList();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Task = await _context.Task.SingleOrDefaultAsync(m => m.Id == id);

            if (Task == null)
            {
                return NotFound();
            }

            return Ok(Task);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask([FromRoute] long id, [FromBody] ProjetoWebVale.Models.Task Task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Task.Id)
            {
                return BadRequest();
            }

            _context.Entry(Task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        [HttpPost]
        public async Task<IActionResult> PostTask([FromBody] ProjetoWebVale.Models.Task Task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Task.Add(Task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = Task.Id }, Task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Task = await _context.Task.SingleOrDefaultAsync(m => m.Id == id);
            if (Task == null)
            {
                return NotFound();
            }

            _context.Task.Remove(Task);
            await _context.SaveChangesAsync();

            return Ok(Task);
        }

        private bool TaskExists(long id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}