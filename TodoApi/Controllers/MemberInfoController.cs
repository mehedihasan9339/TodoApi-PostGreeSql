using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;


namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberInfoController : ControllerBase
    {
        private readonly TodoContext _context;

        public MemberInfoController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/MemberInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberInfo>>> GetMemberInfos()
        {
            return await _context.MemberInfos.ToListAsync();
        }

        // GET: api/MemberInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberInfo>> GetMemberInfo(long id)
        {
            var memberInfo = await _context.MemberInfos.FindAsync(id);

            if (memberInfo == null)
            {
                return NotFound();
            }

            return memberInfo;
        }

        // PUT: api/MemberInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberInfo(long id, MemberInfo memberInfo)
        {
            if (id != memberInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(memberInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberInfoExists(id))
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

        // POST: api/MemberInfo
        [HttpPost]
        public async Task<ActionResult<MemberInfo>> PostMemberInfo(MemberInfo memberInfo)
        {
            _context.MemberInfos.Add(memberInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMemberInfo), new { id = memberInfo.id }, memberInfo);
        }

        // DELETE: api/MemberInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberInfo(long id)
        {
            var memberInfo = await _context.MemberInfos.FindAsync(id);
            if (memberInfo == null)
            {
                return NotFound();
            }

            _context.MemberInfos.Remove(memberInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberInfoExists(long id)
        {
            return _context.MemberInfos.Any(e => e.id == id);
        }
    }
}
