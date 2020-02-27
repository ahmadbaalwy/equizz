using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace wajeb004.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string courseName { get; set; }
        public string description { get; set; }
        public string UserID { get; set; }
        public virtual ICollection<EClass> eclasses { get;set;}
        


    }
}