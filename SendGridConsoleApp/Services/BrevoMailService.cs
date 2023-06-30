
using SendGridServer.Services;

namespace SendGridConsoleApp.Services;

class RfqChangedData
{
    public string subject { get; set; }
    public string rfqNumber { get; set; }
    public string submissionDate { get; set; }
    public string shortDescription { get; set; }
    public string purchasingOrganisation { get; set;} 
    
    public LoginData loginData { get; set; }
    
}

public class LoginData
{
    public string companyLogin { get; set; }
    public string userName { get; set; }
}
public class BrevoMailService : IMailService
{
    public async Task SendMailAsync(string fromEmail, string fromEmailName, string toMail, string toEmailName, string subject, string plainTextContent, string htmlContent, string apiKey)
    {
        //// setup the email client  with the API Key
        //var client = new SendGridClient(apiKey);
        
        //// sender receiver info
        //var from = new EmailAddress(fromEmail, fromEmailName);
        //var to = new EmailAddress(toMail, toEmailName);
        
        ////create the message using params
        //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        
        ////sending the message
        //var response = await client.SendEmailAsync(msg);
        
        //if (response.IsSuccessStatusCode)
        //{
        //    Console.WriteLine("Email has been sent successfully");
        //}
    }
    
    public async Task SendMailTemplateAsync(string fromEmail, string fromEmailName, string toMail, string toEmailName, string subject, string plainTextContent, 
        string htmlContent, string apiKey, string templateId)
    {
        //var client = new SendGridClient(apiKey);
        
        var dynamicTemplateData = new RfqChangedData
        {
            subject = "Anfrage Änderung",
            rfqNumber = "10002347",
            submissionDate = "22.07.2023 17:00",
            purchasingOrganisation = "Salzgitter GmbH",
            shortDescription = "Die Anfrage wurde geändert bitte aktualisieren Sie Ihre Daten",
            loginData = new LoginData()
            {
                companyLogin = "LKKDDFF",
                userName = "Alves"
            }
        };
        //var from = new EmailAddress(fromEmail, fromEmailName);
        //var to = new EmailAddress(toMail, toEmailName);
        
        //var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
        //var response = await client.SendEmailAsync(msg);
        
        //if (response.IsSuccessStatusCode)
        //{
        //    Console.WriteLine("Email has been sent successfully");
        //}
    }
}