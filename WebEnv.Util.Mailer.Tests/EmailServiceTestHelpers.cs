using Microsoft.Extensions.Configuration;
using WebEnv.Util.Mailer.Settings;

namespace WebEnv.Util.Mailer.Tests
{
    public static class EmailServiceTestHelpers
    {
        public static SmtpSettings BuildDummySmtpSettings()
        {
            return new SmtpSettings
            {
                EmailFromName = EmailServiceTestConsts.EmailFromName,
                EmailFromAddress = EmailServiceTestConsts.EmailFromAddress,
                EmailSmtpHost = EmailServiceTestConsts.EmailSmtpHost,
                EmailSmtpPort = EmailServiceTestConsts.EmailSmtpPort,
                EmailSmtpUsername = EmailServiceTestConsts.EmailSmtpUsername,
                EmailSmtpPassword = EmailServiceTestConsts.EmailSmtpPassword
            };
        }

        public static SmtpSettings BuildValidSmtpSettings()
        {
            var smtpConfig = new ConfigurationBuilder()
                   .AddJsonFile("SmtpSettings.json")
                   .Build();

            return new SmtpSettings
            {
                EmailFromName = smtpConfig["SmtpSettings:emailFromName"],
                EmailFromAddress = smtpConfig["SmtpSettings:emailFromAddress"],
                EmailSmtpHost = smtpConfig["SmtpSettings:emailSmtpHost"],
                EmailSmtpPort = int.Parse(smtpConfig["SmtpSettings:emailSmtpPort"]),
                EmailSmtpUsername = smtpConfig["SmtpSettings:emailSmtpUsername"],
                EmailSmtpPassword = smtpConfig["SmtpSettings:emailSmtpPassword"]
            };
        }
    }
}
