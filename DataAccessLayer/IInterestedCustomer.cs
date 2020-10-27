using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataAccessLayer
{
   public interface IInterestedCustomer
    {
        public HttpStatusCode InterestedCustomer(DataModel.CustomerDetails customer);
        IEnumerable<DataModel.CustomerDetails> GetAllInterestedCustomers();
    }
}
