using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCardinal.Data;
using WebAppCardinal.Dto;
using WebAppCardinal.Models;

namespace WebAppCardinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SkillController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Character>> CreateSkill(CreateSkillDto request)
        {
            var character = await _context.Characters
                .Where(c => c.Id == request.CharacterId)
                .Include(c => c.Weapon)
                .Include(c => c.SkillList)
                .FirstOrDefaultAsync();

            if (character == null)
                return NotFound();
            
            var skill = await _context.Skills.FindAsync(request.SkillId);
            if (skill == null)
                return NotFound();

            character.SkillList.Add(skill);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}
