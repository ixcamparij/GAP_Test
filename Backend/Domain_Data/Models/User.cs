using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Data.Models
{
    public class User : Person
    {
        public virtual string UserId { get; set; }

        public virtual string Password { get; set; }
    }
}
