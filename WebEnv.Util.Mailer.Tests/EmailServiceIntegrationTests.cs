using System;
using System.Threading.Tasks;
using Xunit;

namespace WebEnv.Util.Mailer.Tests
{
    [Trait("Category", "Integration")]
    public class EmailServiceIntegrationTests
    {
        [Fact]
        public async Task SendEmailAsync_WithInvalidSmtpSettings_ShouldThrowException()
        {
            //Arrange
            var emailService = new EmailService();
            var smtpSettings = EmailServiceTestHelpers.BuildDummySmtpSettings();
            var message = emailService.CreateHtmlMessage(
                smtpSettings,
                EmailServiceTestConsts.EmailToName,
                EmailServiceTestConsts.EmailToAddress,
                EmailServiceTestConsts.EmailSubject,
                EmailServiceTestConsts.EmailBody);

            //Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await emailService.SendEmailAsync(smtpSettings, message));
        }

        [Fact]
        public void SendEmail_WithInvalidSmtpSettings_ShouldThrowException()
        {
            //Arrange
            var emailService = new EmailService();
            var smtpSettings = EmailServiceTestHelpers.BuildDummySmtpSettings();
            var message = emailService.CreateHtmlMessage(
                smtpSettings,
                EmailServiceTestConsts.EmailToName,
                EmailServiceTestConsts.EmailToAddress,
                EmailServiceTestConsts.EmailSubject,
                EmailServiceTestConsts.EmailBody);

            //Act & Assert
            Assert.ThrowsAny<Exception>(() => emailService.SendEmail(smtpSettings, message));
        }

        [Fact]
        public async Task SendEmailAsync_WithValidSmtpSettings_ShouldNotThrowException()
        {
            //Arrange
            var emailService = new EmailService();
            var smtpSettings = EmailServiceTestHelpers.BuildValidSmtpSettings();
            var message = emailService.CreateHtmlMessage(
                smtpSettings,
                EmailServiceTestConsts.EmailToName,
                EmailServiceTestConsts.EmailToAddress,
                EmailServiceTestConsts.EmailSubject,
                EmailServiceTestConsts.EmailBody);

            //Act & Assert
            await emailService.SendEmailAsync(smtpSettings, message);
        }

        [Fact]
        public void SendEmail_WithValidSmtpSettings_ShouldNotThrowException()
        {
            //Arrange
            var emailService = new EmailService();
            var smtpSettings = EmailServiceTestHelpers.BuildValidSmtpSettings();
            var message = emailService.CreateHtmlMessage(
                smtpSettings,
                EmailServiceTestConsts.EmailToName,
                EmailServiceTestConsts.EmailToAddress,
                EmailServiceTestConsts.EmailSubject,
                EmailServiceTestConsts.EmailBody);

            //Act & Assert
            emailService.SendEmail(smtpSettings, message);
        }
    }
}
