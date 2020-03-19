namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questionSequence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "questionSequence", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "isLastQuestion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "isLastQuestion");
            DropColumn("dbo.Answers", "questionSequence");
        }
    }
}
