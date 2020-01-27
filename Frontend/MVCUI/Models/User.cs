using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Models
{
    public class User : Person
    {
        public string UserId { get; set; }

        public string Password { get; set; }
    }
}