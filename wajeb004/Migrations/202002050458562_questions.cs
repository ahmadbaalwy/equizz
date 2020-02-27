namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        QuestionType = c.String(),
                        score = c.Int(nullable: false),
                        isTrue = c.Boolean(nullable: false),
                        opt1 = c.String(),
                        opt2 = c.String(),
                        opt3 = c.String(),
                        opt4 = c.String(),
                        quizz_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Quizzs", t => t.quizz_ID)
                .Index(t => t.quizz_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "quizz_ID", "dbo.Quizzs");
            DropIndex("dbo.Questions", new[] { "quizz_ID" });
            DropTable("dbo.Questions");
        }
    }
}
