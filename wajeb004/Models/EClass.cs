using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wajeb004.Models
{
    public class EClass
    {
        public int ID { get; set; }
        public string EClassName { get; set; }
        public string year { get; set; }
        public string grade { get; set; }
        
        public string description { get; set; }

        public string code { get; set; }

        public virtual Course course { get; set; }

        public virtual ICollection<Quizz> quizzs { get; set; }
        public virtual ICollection<Student> students { get; set; }


    }
}