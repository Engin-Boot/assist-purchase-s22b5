﻿using System.Collections.Generic;
using DataModel;
using ChatAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChatAPI.Controllers
{
    [Route("api/chatapp")]
    [ApiController]
    
    public class ChatAppController : ControllerBase
    {
        private readonly FilterUtil _filter;
        private readonly SendEmail _sendEmail;
        

        public ChatAppController(DataAccessLayer.IProductManagement productDb )
        {
            _filter = new FilterUtil(productDb);
            _sendEmail = new SendEmail();
           
        }

        // GET: api/chatapp
        [HttpGet]
        public IEnumerable<ProductDataModel> FilterProducts([FromQuery] Filter filtersList)
        {
            return _filter.ProductFilter(filtersList);
        }
        

         // POST: api/chatapp
         [HttpPost]
        public HttpStatusCode Post([FromBody] Mailer mailData)
        {
            return _sendEmail.SendEmailViaWebApi(mailData.ProductNameList, mailData.CustomerEmailId);
        }
         
    }
}