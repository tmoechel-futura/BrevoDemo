// See https://aka.ms/new-console-template for more information

using SendGridConsoleApp.Services;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mail;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Xml.Linq;
using BrevoConsoleApp.Model;

Console.WriteLine("Hello, Brevo !");

string _brevoApiIKey = "";
long _templateId = 6;
string _recipientEmail = "t.moechel@gmail.com";
string _recipientName = "Thomas Möchel";
string _senderEmail = "t.moechel@futura-solutions.de";
string _senderName = "Thomas Möchel";
string _emailSubject = "Test Brevo Mail";
string _plainText = "This is a simple plain text";
string _htmlContent = "<html><head></head><body><p>Hello,</p>This is my first transactional email sent from Brevo.</p></body></html>";


Configuration.Default.ApiKey.Add("api-key", _brevoApiIKey);

var apiAccountInstance = new AccountApi();

var apiTransactionalInstance = new TransactionalEmailsApi();



try
{
    // Get your account information, plan and credits details
    GetAccount resultAccount = apiAccountInstance.GetAccount();
    Debug.WriteLine(resultAccount);

    SendSmtpEmailSender emailSender = new SendSmtpEmailSender(_senderName, _senderEmail);

    SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(_recipientEmail, _recipientName);

    List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>
    {
        smtpEmailTo
    };

    RfqMailParameter mailParameter = new RfqMailParameter()
    {
        Rfq = new Rfq() { Name = "RFQ1234", Number = "2134", ClosingDate = "12.09.2023", ContactPersonEmail = "m.koch@futura-solutions.de", ContactPersonName = "Markus Koch" },
        Supplier = new Supplier { LoginCompanyName = "FuturaEr6_Fre", UserLogin = "m.koch" }
    };

    var sendSmtpEmail = new SendSmtpEmail(
            sender: emailSender,
            to: To,
            htmlContent: _htmlContent,
            textContent: _plainText,
            templateId: _templateId,
            subject: _emailSubject,
            _params: mailParameter
        ) ; 
        
        
    CreateSmtpEmail resultMail = apiTransactionalInstance.SendTransacEmail(sendSmtpEmail);
    Debug.WriteLine(resultMail.ToJson());
    Console.WriteLine(resultMail.ToJson());
    Console.ReadLine();

}
catch (Exception e)
{
    Debug.Print("Exception when calling Brevo API: " + e.Message);
}


Console.WriteLine("Done");
