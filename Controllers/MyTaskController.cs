#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud_api.Models;

namespace Crud_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTaskController : ControllerBase
    {
        private readonly MyTaskContext _context;

        public MyTaskController(MyTaskContext context)
        {
            _context = context;
        }

        // GET: api/MyTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTasks()
        {
            return await _context.MyTasks.ToListAsync();
        }

        // GET: api/MyTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyTask>> GetMyTask(long id)
        {
            var myTask = await _context.MyTasks.FindAsync(id);

            if (myTask == null)
            {
                return NotFound();
            }

            return myTask;
        }

        // PUT: api/MyTask/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyTask(long id, MyTask myTask)
        {
            if (id != myTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(myTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTaskExists(id))
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

        // POST: api/MyTask
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyTask>> PostMyTask(MyTask myTask)
        {
            _context.MyTasks.Add(myTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyTask", new { id = myTask.Id }, myTask);
        }

        // DELETE: api/MyTask/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyTask(long id)
        {
            var myTask = await _context.MyTasks.FindAsync(id);
            if (myTask == null)
            {
                return NotFound();
            }

            _context.MyTasks.Remove(myTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyTaskExists(long id)
        {
            return _context.MyTasks.Any(e => e.Id == id);
        }
    }
}
