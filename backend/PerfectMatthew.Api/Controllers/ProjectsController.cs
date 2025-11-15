using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatthew.Api.Database;
using PerfectMatthew.Api.Models;

namespace PerfectMatthew.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects
                .OrderByDescending(p => p.StartDate)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        [HttpGet("featured")]
        public async Task<ActionResult<IEnumerable<Project>>> GetFeaturedProjects()
        {
            return await _context.Projects
                .Where(p => p.Featured)
                .OrderByDescending(p => p.StartDate)
                .ToListAsync();
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByCategory(ProjectCategory category)
        {
            return await _context.Projects
                .Where(p => p.Category == category)
                .OrderByDescending(p => p.StartDate)
                .ToListAsync();
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByStatus(ProjectStatus status)
        {
            return await _context.Projects
                .Where(p => p.Status == status)
                .OrderByDescending(p => p.StartDate)
                .ToListAsync();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}