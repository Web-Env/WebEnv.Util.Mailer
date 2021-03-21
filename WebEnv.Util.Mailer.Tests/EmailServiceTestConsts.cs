namespace WebEnv.Util.Mailer.Tests
{
    public static class EmailServiceTestConsts
    {
        public static string EmailFromName { get; } = "WebEnv";
        public static string EmailFromAddress { get; } = "noreply@webenv.io";
        public static string EmailSmtpHost { get; } = "webenv.io";
        public static int EmailSmtpPort { get; } = 465;
        public static string EmailSmtpUsername { get; } = "webenv";
        public static string EmailSmtpPassword { get; } = "SmtpPassword";

        public static string EmailToName { get; } = "Test Testerson";
        public static string EmailToAddress { get; } = "test.testerson@testing.com";
        public static string EmailSubject { get; } = "Email Service Unit Tests";
        public static string EmailBody { get; } = "<html><body><h1>Email Service Unit Tests</h1></body>";
    }
}
