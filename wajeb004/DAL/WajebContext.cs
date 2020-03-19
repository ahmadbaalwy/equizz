using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using wajeb004.Models;

namespace wajeb004.DAL
{
    public class WajebContext: DbContext

    {
        public WajebContext() : base("DefaultConnection") { }
        public DbSet<EClass> EClasses { get; set; }
        public DbSet<Course> Courses { get; set; }

        public System.Data.Entity.DbSet<wajeb004.Models.Quizz> Quizzs { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<AnswersSnapshot> AnswersSnapshots { get; set; }

        public DbSet<Answer> Answers { get; set; }

    }
}