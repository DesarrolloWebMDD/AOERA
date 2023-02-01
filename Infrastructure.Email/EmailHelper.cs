using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Infrastructure.Email
{
    public class EmailHelper : IEmailHelper
    {
        private readonly EmailSettings _emailSettings;

        public EmailHelper(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task Send(Email email)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _emailSettings.Address,
                    Password = _emailSettings.Password
                };

                client.Credentials = credential;
                client.Host = _emailSettings.Host;
                client.Port = _emailSettings.Port;
                client.EnableSsl = _emailSettings.EnableSsl;

                using (var emailMessage = new MailMessage())
                {
                    if (email.AddressList != null && email.AddressList.Count > 0)
                    {
                        foreach (var address in email.AddressList) emailMessage.To.Add(address);
                    }
                    else throw new Exception("Debes incluir al menos una dirección de correo destinatario.");
                    emailMessage.From = new MailAddress(_emailSettings.Address);
                    emailMessage.Subject = email.Subject;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = email.Body;

                    if (email.BccAddressList != null && email.BccAddressList.Count > 0)
                    {
                        foreach (var bccAddress in email.BccAddressList) emailMessage.Bcc.Add(bccAddress);
                    }

                    if (email.FileList != null && email.FileList.Count > 0)
                        foreach (var file in email.FileList)
                            if (file.Path != null && file.Path.Trim() != "")
                                emailMessage.Attachments.Add(new Attachment(file.Path));
                            else
                                emailMessage.Attachments.Add(new Attachment(file.Stream, file.Name));

                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    try
                    {
                        await client.SendMailAsync(emailMessage);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ha ocurrido un problema al intentar enviar el correo.", ex);
                    }
                }
            }
        }
    }
}