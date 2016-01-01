namespace Haiku.Data.MySqlMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haikus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, unicode: false),
                        DatePublished = c.DateTime(nullable: false, precision: 0),
                        UserId = c.Int(nullable: false),
                        Rating = c.Double(),
                        RatingsSum = c.Int(nullable: false),
                        RatingsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        HaikuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Haikus", t => t.HaikuId, cascadeDelete: true)
                .Index(t => t.HaikuId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(unicode: false),
                        DateSent = c.DateTime(nullable: false, precision: 0),
                        HaikuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Haikus", t => t.HaikuId, cascadeDelete: true)
                .Index(t => t.HaikuId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nickname = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        AccessToken = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Role = c.Int(nullable: false),
                        Rating = c.Double(),
                        HaikusRatingSum = c.Double(nullable: false),
                        HaikusCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Haikus", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reports", "HaikuId", "dbo.Haikus");
            DropForeignKey("dbo.Ratings", "HaikuId", "dbo.Haikus");
            DropIndex("dbo.Reports", new[] { "HaikuId" });
            DropIndex("dbo.Ratings", new[] { "HaikuId" });
            DropIndex("dbo.Haikus", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Reports");
            DropTable("dbo.Ratings");
            DropTable("dbo.Haikus");
        }
    }
}
