using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;
using WebEnv.Util.Mailer.Settings;

namespace WebEnv.Util.Mailer
{
    public class EmailService
    {
        public SmtpSettings BuildSmtpSettings(
            string emailFromName,
            string emailFromAddress,
            string emailSmtpHost,
            int emailSmtpPort,
            string emailSmtpUsername,
            string emailSmtpPassword
            )
        {
            return new SmtpSettings
            {
                EmailFromName = emailFromName,
                EmailFromAddress = emailFromAddress,
                EmailSmtpHost = emailSmtpHost,
                EmailSmtpPort = emailSmtpPort,
                EmailSmtpUsername = emailSmtpUsername,
                EmailSmtpPassword = emailSmtpPassword,
            };
        }

        public MimeMessage CreateHtmlMessage(
            SmtpSettings smtpSettings,
            string emailToName,
            string emailToAddress,
            string emailSubject,
            string emailBody)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(emailToName, emailToAddress));
            message.From.Add(new MailboxAddress(smtpSettings.EmailFromName, smtpSettings.EmailFromAddress));
            message.Subject = emailSubject;
            message.Body = new TextPart("html") { Text = emailBody };

            return message;
        }

        public async Task SendEmailAsync(SmtpSettings smtpSettings, MimeMessage message)
        {
            var smtpClient = new SmtpClient
            {
                Timeout = 10000
            };
            try
            {
                await smtpClient.ConnectAsync(smtpSettings.EmailSmtpHost, smtpSettings.EmailSmtpPort, true);
                await smtpClient.AuthenticateAsync(smtpSettings.EmailSmtpUsername, smtpSettings.EmailSmtpPassword);

                await smtpClient.SendAsync(message);

                await smtpClient.DisconnectAsync(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SendEmail(SmtpSettings smtpSettings, MimeMessage message)
        {
            var smtpClient = new SmtpClient
            {
                Timeout = 10000
            };
            try
            {
                smtpClient.Connect(smtpSettings.EmailSmtpHost, smtpSettings.EmailSmtpPort, true);
                smtpClient.Authenticate(smtpSettings.EmailSmtpUsername, smtpSettings.EmailSmtpPassword);

                smtpClient.Send(message);

                smtpClient.Disconnect(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
