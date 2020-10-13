using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using DataModel;
using ChatAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/chatapp")]
    [ApiController]
    public class ChatAppController : ControllerBase
    {
        private readonly FilterUtil _filter;
        

        public ChatAppController(DataAccessLayer.IProductManagement productDb )
        {
            _filter = new FilterUtil(productDb);
           
        }

        // GET: api/chat-app
        [HttpGet]
        public IEnumerable<ProductDataModel> FilterProducts([FromQuery] Filter filtersList)
        {
            return _filter.ProductFilter(filtersList);
        }
        

         // POST: api/ChatApp
         [HttpPost]
         public bool Post([FromBody] string productName,[FromBody] string stringEmail)
         {
            return SendEmailViaWebApi(productName,stringEmail);
         }
         private bool SendEmailViaWebApi(string productName, string stringEmail)
         {
             try
             {
                 using SmtpClient smtp = new SmtpClient
                 {
                     DeliveryMethod = SmtpDeliveryMethod.Network,
                     UseDefaultCredentials = false,
                     EnableSsl = true,
                     Host = "smtp.gmail.com",
                     Port = 587,
                     Credentials = new NetworkCredential("Sender Username", "Sender Password")
                 };
                 // send the email
                 var body = "The customer has selected this "+ "\nProductName: "+productName+"\nCustomer Email:" +stringEmail;
                 smtp.Send("Sender@Email.com", "receiver@Email.com", "Test Email Subject", body);
                 return true;
             }
             catch (SmtpException)
             {
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }

             
             
         }
    }
}
