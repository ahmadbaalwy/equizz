using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wajeb004.Models
{
    public class AnswersSnapshot
    {
        public int ID { get; set; }
        public virtual Quizz quizz { get; set; }
        public virtual Student student { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
        public string status { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime lastChangedOn { get; set; }

    }
}