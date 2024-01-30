using MailKit.Net.Smtp;
using MimeKit;

namespace Soicheek.BL.Helpers;

public class InfoSmtpClient : IDisposable
{
    private SmtpClient client;
    public const string Email = $"***";
    private const string Host = "smtp.endora.cz";
    private const int Port = 587;


    public InfoSmtpClient() 
    {
        client = new SmtpClient();
        client.Connect(Host, Port, MailKit.Security.SecureSocketOptions.StartTls);
        client.Authenticate(Email);
    }

    public async Task<string> SendAsync(MimeMessage message)
    {
        return await client.SendAsync(message);
    }

    public void Dispose()
    {
        client.Disconnect(true);
        client.Dispose();
    }
}
