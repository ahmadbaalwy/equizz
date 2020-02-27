namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctOption_enum3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "correctOption", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "correctOptio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "correctOptio", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "correctOption");
        }
    }
}
