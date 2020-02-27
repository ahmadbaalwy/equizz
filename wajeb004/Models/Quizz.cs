using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wajeb004.Models
{
    public class Quizz
    {
        public int ID { get; set; }
        public string QuizzName { get; set; }
        public virtual EClass eclass { get; set; }
    }
}