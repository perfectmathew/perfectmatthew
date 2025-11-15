using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatthew.Api.Database;
using PerfectMatthew.Api.Models;

namespace PerfectMatthew.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperiencesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExperiencesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperiences()
        {
            return await _context.Experiences
                .OrderByDescending(e => e.StartDate)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);

            if (experience == null)
            {
                return NotFound();
            }

            return experience;
        }

        [HttpGet("current")]
        public async Task<ActionResult<IEnumerable<Experience>>> GetCurrentExperiences()
        {
            return await _context.Experiences
                .Where(e => e.Current)
                .OrderByDescending(e => e.StartDate)
                .ToListAsync();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Experience>> PostExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExperience), new { id = experience.Id }, experience);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutExperience(int id, Experience experience)
        {
            if (id != experience.Id)
            {
                return BadRequest();
            }

            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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
        [Authorize]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experiences.Any(e => e.Id == id);
        }
    }
}