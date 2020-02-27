namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctOption_enum2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "correctOptio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "correctOptio");
        }
    }
}
