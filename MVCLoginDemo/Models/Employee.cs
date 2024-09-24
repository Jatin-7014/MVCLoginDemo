using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLoginDemo.Models
{
    public class Employee
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email {  get; set; }
    }
}