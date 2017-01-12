namespace OnlineQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "Admin_ID", "dbo.Admins");
            DropIndex("dbo.Admins", new[] { "Admin_ID" });
            DropColumn("dbo.Admins", "Admin_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Admin_ID", c => c.Int());
            CreateIndex("dbo.Admins", "Admin_ID");
            AddForeignKey("dbo.Admins", "Admin_ID", "dbo.Admins", "ID");
        }
    }
}
