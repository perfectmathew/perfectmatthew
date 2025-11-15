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
            // For now, we're just logging the message
            
            // Example implementation with SMTP would look like this:
            /*
            var smtpClient = new SmtpClient(_configuration["Email:SmtpServer"])
            {
                Port = int.Parse(_configuration["Email:SmtpPort"]),
                Credentials = new NetworkCredential(
                    _configuration["Email:Username"],
                    _configuration["Email:Password"]
                ),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Email:FromAddress"]),
                Subject = $"Portfolio Contact: {subject}",
                Body = $"Name: {name}\nEmail: {email}\n\nMessage:\n{message}",
                IsBodyHtml = false,
            };
            
            mailMessage.To.Add(_configuration["Email:ToAddress"]);

            await smtpClient.SendMailAsync(mailMessage);
            */

            await Task.CompletedTask;
        }
    }
}
