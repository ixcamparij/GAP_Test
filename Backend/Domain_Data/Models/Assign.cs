using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Models
{
    public class Assign
    {
        public virtual int Id { get; set; }

        public virtual int CustomerId { get; set; }

        public virtual string CustomerName { get; set; }

        public virtual int PolicyId { get; set; }

        public virtual string PolicyName { get; set; }

        public virtual bool Status { get; set; }
    }
}
