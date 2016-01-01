namespace Haiku.Data.MsSqlMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_User_AccessToken_Length_To_128 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "AccessToken", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "AccessToken", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
