namespace OnlineQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "SelectedAnswer", c => c.String());
            AddColumn("dbo.Admins", "Admin_ID", c => c.Int());
            AddForeignKey("dbo.Admins", "Admin_ID", "dbo.Admins", "ID");
            CreateIndex("dbo.Admins", "Admin_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Admins", new[] { "Admin_ID" });
            DropForeignKey("dbo.Admins", "Admin_ID", "dbo.Admins");
            DropColumn("dbo.Admins", "Admin_ID");
            DropColumn("dbo.Admins", "SelectedAnswer");
        }
    }
}
