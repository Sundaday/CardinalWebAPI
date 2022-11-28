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
    public class CharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters(int userId)
        {
            return await _context.Characters
                .Where(c => c.UserId == userId)
                .Include(w => w.Weapon)
                .Include(s => s.SkillList)
                .ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacters(CreateCharacterDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var newCharacter = new Character
            {
                NameCharacter = request.Name,
                RpgClass = request.RpgClass,
                User = user,
            };

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            return await GetCharacters(newCharacter.UserId);
        }
    }
}
