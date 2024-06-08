using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IDapper _dapper;

        public TodoController(TodoContext context, IDapper dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.Include(x => x.memberinfo).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItemViewModel todoItem)
        {
            var data = new TodoItem
            {
                id = todoItem.Id,
                name = todoItem.Name,
                iscomplete = todoItem.IsComplete,
                memberinfoid = todoItem.MemberInfoId
            };

            _context.TodoItems.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.id == id);
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberWiseTodoItems(long memberId)
        {
            var data = await _context.TodoItems.Include(x => x.memberinfo).Where(x => x.memberinfoid == memberId).AsNoTracking().ToListAsync();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberWiseTodoItemsBySP(long memberId)
        {
            var results = await _dapper.FromSqlAsync<MemberTodoItemDTO>($@"CALL get_member_todo_items({memberId});");

            return Ok(results);
        }
    }
}
