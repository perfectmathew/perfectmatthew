using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatthew.Api.Database;
using PerfectMatthew.Api.Models;
using PerfectMatthew.Api.Services;

namespace PerfectMatthew.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(
            AppDbContext context, 
            IEmailService emailService,
            ILogger<ContactController> logger)
        {
            _context = context;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ContactMessage>> PostContactMessage(ContactMessage contactMessage)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(contactMessage.Name) ||
                string.IsNullOrWhiteSpace(contactMessage.Email) ||
                string.IsNullOrWhiteSpace(contactMessage.Message))
            {
                return BadRequest(new { error = "Name, Email, and Message are required fields." });
            }

            // Validate email format
            if (!IsValidEmail(contactMessage.Email))
            {
                return BadRequest(new { error = "Invalid email format." });
            }

            contactMessage.CreatedAt = DateTime.UtcNow;
            _context.ContactMessages.Add(contactMessage);
            await _context.SaveChangesAsync();

            // Send email notification
            try
            {
                await _emailService.SendContactEmailAsync(
                    contactMessage.Name,
                    contactMessage.Email,
                    contactMessage.Subject ?? "No Subject",
                    contactMessage.Message
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email notification");
                // Continue even if email fails - message is saved to database
            }

            return Ok(new 
            { 
                message = "Thank you for your message! I'll get back to you soon.",
                id = contactMessage.Id
            });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ContactMessage>> GetContactMessage(int id)
        {
            var contactMessage = await _context.ContactMessages.FindAsync(id);

            if (contactMessage == null)
            {
                return NotFound();
            }

            return contactMessage;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ContactMessage>>> GetContactMessages()
        {
            return await _context.ContactMessages
                .OrderByDescending(cm => cm.CreatedAt)
                .ToListAsync();
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}