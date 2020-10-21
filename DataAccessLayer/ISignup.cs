using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using DataModel;

namespace DataAccessLayer
{
    public interface ISignup
    {
       public HttpStatusCode RegisterUser(DataModel.UserData userData);
    }
}
