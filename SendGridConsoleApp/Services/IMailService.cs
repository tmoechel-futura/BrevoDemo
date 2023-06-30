namespace SendGridServer.Services;

public interface IMailService
{
    Task SendMailAsync(string fromEmail, string fromEmailName, string toMail, string toEmailName, string subject, string plainTextContent, string htmlContent, string apiKey);
}