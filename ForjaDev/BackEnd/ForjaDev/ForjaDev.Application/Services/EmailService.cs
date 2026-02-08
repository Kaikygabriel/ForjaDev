using Microsoft.Extensions.Configuration;
using MimeKit;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Services;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace ForjaDev.Application.Services;

public class EmailService : IServiceEmail
{
        private readonly IConfiguration _configuration;
    
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public async Task Send(EmailSendBuilder emailBuilder)
        {
            var mensagem = new MimeMessage();
        
            mensagem.From.Add(new MailboxAddress("monetra", _configuration["EmailConfig:Email"]));
            
            mensagem.To.Add(new MailboxAddress(emailBuilder.Name, emailBuilder.ToAddress));
        
            mensagem.Subject = emailBuilder.Title;
            mensagem.Body = new TextPart("html") { Text = emailBuilder.Body };
    
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                
                await client.AuthenticateAsync(_configuration["EmailConfig:Email"], _configuration["EmailConfig:key"]);
    
                await client.SendAsync(mensagem);
                await client.DisconnectAsync(true);
            }        
        }

    
}