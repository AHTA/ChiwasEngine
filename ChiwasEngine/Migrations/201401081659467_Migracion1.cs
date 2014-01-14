namespace ChiwasEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        category_name = c.String(),
                        category_description = c.String(),
                    })
                .PrimaryKey(t => t.category_id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        page_id = c.Int(nullable: false, identity: true),
                        page_date = c.DateTime(nullable: false),
                        page_content = c.String(nullable: false),
                        page_description = c.String(nullable: false, maxLength: 150),
                        page_title = c.String(nullable: false),
                        page_modified = c.DateTime(nullable: false),
                        page_visible = c.Boolean(nullable: false),
                        page_image = c.String(),
                        UserProfile_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.page_id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_UserId)
                .Index(t => t.UserProfile_UserId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        PublicUserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.PagesCategories",
                c => new
                    {
                        Pages_page_id = c.Int(nullable: false),
                        Categories_category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pages_page_id, t.Categories_category_id })
                .ForeignKey("dbo.Pages", t => t.Pages_page_id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Categories_category_id, cascadeDelete: true)
                .Index(t => t.Pages_page_id)
                .Index(t => t.Categories_category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "UserProfile_UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.PagesCategories", "Categories_category_id", "dbo.Categories");
            DropForeignKey("dbo.PagesCategories", "Pages_page_id", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "UserProfile_UserId" });
            DropIndex("dbo.PagesCategories", new[] { "Categories_category_id" });
            DropIndex("dbo.PagesCategories", new[] { "Pages_page_id" });
            DropTable("dbo.PagesCategories");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Pages");
            DropTable("dbo.Categories");
        }
    }
}
