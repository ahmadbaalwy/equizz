namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class null_boolean : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "TrueOrFalseAnswer", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answers", "TrueOrFalseAnswer", c => c.Boolean(nullable: false));
        }
    }
}
