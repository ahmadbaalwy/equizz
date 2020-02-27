namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctAnswer_enum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "opt1_isTrue");
            DropColumn("dbo.Questions", "opt2_isTrue");
            DropColumn("dbo.Questions", "opt3_isTrue");
            DropColumn("dbo.Questions", "op4_isTrue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "op4_isTrue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questions", "opt3_isTrue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questions", "opt2_isTrue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questions", "opt1_isTrue", c => c.Boolean(nullable: false));
        }
    }
}
