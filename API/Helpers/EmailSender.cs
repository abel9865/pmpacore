using System;
using System.Threading.Tasks;
using System.Web;
using Domain;
using MailKit.Net.Smtp;
using MimeKit;

namespace API.Helpers
{
    public class EmailSender
    {
       public static async Task<bool> SendEmailAsync(AppUser user,string resetToken, string url)
        {
            var encodedResetToken = HttpUtility.UrlEncode(resetToken);
            var urlToUse = url + "resetpassword?p=" + encodedResetToken;

            var emailMessage = string.Format("<p>To reset your password, click on the link below. This link will expire in one hour. </p> <p> Click here to reset password {0} </p>", urlToUse);
            var subject = "Password reset request";
           
            var sendMail = await SendEmailAsyncCore(user, subject, emailMessage);
            return sendMail;
        }

        public static async Task<bool> SendEmailAsyncCore(AppUser user, string subject, string emailMessage)
        {

            var opResult = false;
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("MergencePro", "mergencepro@test.com"));
                mimeMessage.To.Add(MailboxAddress.Parse(user.Email));
                mimeMessage.Subject = subject;
                var bodyBuilder = new BodyBuilder { HtmlBody = emailMessage };
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                //to authenticate
                await client.AuthenticateAsync("abel9865@gmail.com", "gtpiavzufsutnwft");

                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
                opResult = true;
            }
            catch (Exception ex)
            {

            }

            return opResult;
         
        }
    }
}
