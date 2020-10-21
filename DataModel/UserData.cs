using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel
{
    public class UserData
    {
        public string Email { get; set; } 
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
