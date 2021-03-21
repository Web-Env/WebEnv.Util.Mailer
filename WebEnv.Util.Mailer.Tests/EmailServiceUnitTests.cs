using MimeKit;
using WebEnv.Util.Mailer.Settings;
using Xunit;

namespace WebEnv.Util.Mailer.Tests
{
    [Trait("Category", "Unit")]
    public class EmailServiceUnitTests
    {
        [Fact]
        public void BuildSmtpSettings_ShouldReturnSmtpSettings()
        {
            //Arrange
            var emailService = new EmailService();

            //Act
            var smtpSettings = emailService.BuildSmtpSettings(
                EmailServiceTestConsts.EmailFromName,
                EmailServiceTestConsts.EmailFromAddress,
                EmailServiceTestConsts.EmailSmtpHost,
                EmailServiceTestConsts.EmailSmtpPort,
                EmailServiceTestConsts.EmailSmtpUsername,
                EmailServiceTestConsts.EmailSmtpPassword);

            //Assert
            Assert.NotNull(smtpSettings);
            Assert.IsType<SmtpSettings>(smtpSettings);
        }

        [Fact]
        public void CreateHtmlMessage_ShouldReturnMimeMessage()
        {
            //Arrange
            var emailService = new EmailService();
            var smtpSettings = EmailServiceTestHelpers.BuildDummySmtpSettings();

            //Act
            var message = emailService.CreateHtmlMessage(
                smtpSettings,
                EmailServiceTestConsts.EmailToName,
                EmailServiceTestConsts.EmailToAddress,
                EmailServiceTestConsts.EmailSubject,
                EmailServiceTestConsts.EmailBody);

            //Assert
            Assert.IsType<MimeMessage>(message);
            Assert.IsType<MailboxAddress>(message.To[0]);
            Assert.IsType<MailboxAddress>(message.From[0]);
            Assert.Equal(EmailServiceTestConsts.EmailToName, message.To[0].Name);
            Assert.Equal(EmailServiceTestConsts.EmailFromName, message.From[0].Name);
            Assert.Equal(EmailServiceTestConsts.EmailSubject, message.Subject);
        }
    }
}
