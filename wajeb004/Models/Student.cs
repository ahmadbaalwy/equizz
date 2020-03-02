using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wajeb004.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public virtual EClass eClass { get; set; }
        public DateTime JoinDate { get; set; }

    }
}