using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wajeb004.Models
{
    public partial class Question
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public int score { get; set; }
        public virtual Quizz quizz { get; set; }
        public Boolean isTrue { get; set; }
        public string opt1 { get; set; }
        public string opt2 { get; set; }
        public string opt3 { get; set; }
        public string opt4 { get; set; }
        
        public CorrectOption correctOption { get; set; }
        
    }
}