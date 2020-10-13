using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;



namespace ChatAPI.Utils
{
    public class SendEmail
    {
        public HttpStatusCode SendEmailViaWebApi(IEnumerable<string> productNameList, string customerMailId)
        {
            try
            {
                using var smtp = new SmtpClient
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("Sender Username", "Sender Password")
                };

                // send the email
                var mailBody = new StringBuilder();
                mailBody.Append("Please find the following customer email id and selected product(s).\n");
                mailBody.Append("Customer Email Id: " + customerMailId + "\n");
                mailBody.Append("Selected product(s):\n");

                foreach (var (productName, index) in productNameList.Select(
                    (productName, index) => (productName, index)))
                {
                    mailBody.Append(index + ". " + productName + "\n");

                }

                smtp.Send("Sender@Email.com", "receiver@Email.com", "Alert: Customer Requirement", mailBody.ToString());
                return HttpStatusCode.OK;
            }
            catch (SmtpException)
            {
                return HttpStatusCode.BadRequest;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
