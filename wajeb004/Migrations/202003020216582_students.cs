namespace wajeb004.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class students : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        eClass_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EClasses", t => t.eClass_ID)
                .Index(t => t.eClass_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "eClass_ID", "dbo.EClasses");
            DropIndex("dbo.Students", new[] { "eClass_ID" });
            DropTable("dbo.Students");
        }
    }
}
