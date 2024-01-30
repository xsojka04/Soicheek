using Microsoft.AspNetCore.Identity;
using MimeKit;
using Soicheek.DAL.DataModels;

namespace Soicheek.BL.Helpers;

public class EmailSender : IEmailSender<ApplicationUser>
{
    private const string FromName = "Soicheek";

    private MimeMessage createMessage(string fromEmail, string toEmail, string subject, string htmlText)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(FromName, fromEmail));
        message.To.Add(new MailboxAddress(toEmail, toEmail));
        message.Subject = subject;
        message.Body = new TextPart("html")
        {
            Text = htmlText
        };
        return message;
    }

    public async Task SendConfirmationLinkAsync(ApplicationUser user, string emailTo, string confirmationLink)
    {
        var htmlText = $@"Dobrý den,

vítáme Vás v aplikaci. Prosím potvrďte svůj email <a href='{confirmationLink}'>zde</a>.

Tým Soicheek";

        using (var client = new InfoSmtpClient())
        {
            await client.SendAsync(createMessage(InfoSmtpClient.Email, emailTo, emailTo, htmlText));
        }
    }

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string emailTo, string resetCode)
    {
        throw new NotImplementedException();
    }

    public async Task SendPasswordResetLinkAsync(ApplicationUser user, string emailTo, string resetLink)
    {
        var htmlText = $@"Dobrý den,

zaregistrovali jsme u Vás žádost o obnovu hesla. Své heslo si můžete obnovit <a href='{resetLink}'>zde</a>.

Tým Soicheek";

        using (var client = new InfoSmtpClient())
        {
            await client.SendAsync(createMessage(InfoSmtpClient.Email, emailTo, emailTo, htmlText));
        }
    }
}
