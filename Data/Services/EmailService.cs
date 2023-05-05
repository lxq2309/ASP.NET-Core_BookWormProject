using SendGrid.Helpers.Mail;
using SendGrid;

namespace BookWormProject.Data.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;

        public EmailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendCodeAsync(string email, string code)
        {
            var from = new EmailAddress("saobangkhoc10x@gmail.com", "BookWorm");
            var to = new EmailAddress(email, "");
            var subject = "Reset Password";
            var htmlContent = $"<p><strong>Your verification code is: <span style='color: red;'>{code}</span></strong></p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);

            var response = await _sendGridClient.SendEmailAsync(msg);
        }

        public async Task SendPasswordAsync(string email, string password)
        {
            var from = new EmailAddress("saobangkhoc10x@gmail.com", "BookWorm");
            var to = new EmailAddress(email, "");
            var subject = "Reset Password";
            var htmlContent = $"<p><strong>Your new password is: <span style='color: green;'>{password}</span></strong></p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);

            var response = await _sendGridClient.SendEmailAsync(msg);
        }
    }
}
