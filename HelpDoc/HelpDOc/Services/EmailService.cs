
using MailKit.Net.Smtp;
using MimeKit;

public class EmailService 
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _username;
    private readonly string _password;

    public EmailService(string smtpServer, int smtpPort, string username, string password)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _username = username;
        _password = password;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Mirella", _username));
        emailMessage.To.Add(new MailboxAddress("Cliente", toEmail));
        emailMessage.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = body };
        emailMessage.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Timeout = 5000; // Define o timeout para 10 segundos (em milissegundos)
            
            await client.ConnectAsync(_smtpServer, _smtpPort, true);
            await client.AuthenticateAsync(_username, _password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}