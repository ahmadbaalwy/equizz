namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class class_code : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EClasses", "code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EClasses", "code");
        }
    }
}
