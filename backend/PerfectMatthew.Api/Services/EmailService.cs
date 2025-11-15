namespace PerfectMatthew.Api.Services
{

    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _configuration;

        public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task SendContactEmailAsync(string name, string email, string subject, string message)
        {
            // Log the contact message
            _logger.LogInformation(
                "Contact form submission received:\n" +
                "Name: {Name}\n" +
                "Email: {Email}\n" +
                "Subject: {Subject}\n" +
                "Message: {Message}",
                name, email, subject, message);

            // TODO: Implement actual email sending using SMTP or email service provider


            await Task.CompletedTask;
        }
    }
}
