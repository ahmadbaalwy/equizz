namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswersSnapshot_and_Answers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrueOrFalseAnswer = c.Boolean(nullable: false),
                        MCQAnswer = c.Int(nullable: false),
                        OpenQuestionAnswer = c.String(),
                        answersSnapshot_ID = c.Int(),
                        question_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnswersSnapshots", t => t.answersSnapshot_ID)
                .ForeignKey("dbo.Questions", t => t.question_ID)
                .Index(t => t.answersSnapshot_ID)
                .Index(t => t.question_ID);
            
            CreateTable(
                "dbo.AnswersSnapshots",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        createdOn = c.DateTime(nullable: false),
                        lastChangedOn = c.DateTime(nullable: false),
                        quizz_ID = c.Int(),
                        student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Quizzs", t => t.quizz_ID)
                .ForeignKey("dbo.Students", t => t.student_ID)
                .Index(t => t.quizz_ID)
                .Index(t => t.student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "question_ID", "dbo.Questions");
            DropForeignKey("dbo.AnswersSnapshots", "student_ID", "dbo.Students");
            DropForeignKey("dbo.AnswersSnapshots", "quizz_ID", "dbo.Quizzs");
            DropForeignKey("dbo.Answers", "answersSnapshot_ID", "dbo.AnswersSnapshots");
            DropIndex("dbo.AnswersSnapshots", new[] { "student_ID" });
            DropIndex("dbo.AnswersSnapshots", new[] { "quizz_ID" });
            DropIndex("dbo.Answers", new[] { "question_ID" });
            DropIndex("dbo.Answers", new[] { "answersSnapshot_ID" });
            DropTable("dbo.AnswersSnapshots");
            DropTable("dbo.Answers");
        }
    }
}
