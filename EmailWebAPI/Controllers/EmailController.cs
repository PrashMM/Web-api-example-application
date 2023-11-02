using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace EmailWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ruth.schowalter@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("ruth.schowalter@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email",587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ruth.schowalter@ethereal.email", "KuErRDjvvEDU1pyqqF");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();

        }   
    }
}
