using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCardinal.Data;
using WebAppCardinal.Dto;
using WebAppCardinal.Models;

namespace WebAppCardinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WeaponController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Character>> CreateWeapon(CreateWeaponDto request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
                return NotFound();

            var newWeapon = new Weapon
            {
                Name = request.Name,
                Damage = request.Damage,
                Character = character
            };

            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}
