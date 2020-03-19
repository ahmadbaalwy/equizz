using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wajeb004.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public virtual AnswersSnapshot answersSnapshot { get; set; }
        public virtual Question question { get; set; }

        public bool? TrueOrFalseAnswer { get; set; }
        public Question.CorrectOption MCQAnswer { get; set; }
        public string OpenQuestionAnswer { get; set; }
        public int questionSequence { get; set; }
        public bool isLastQuestion { get; set; }

    }
}