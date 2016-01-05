namespace Haiku.Data.MySqlMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Indexes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Users", "Nickname", true, "IX_User_Nickname");
            CreateIndex("Users", "AccessToken", true, "IX_User_AccessToken");
        }
        
        public override void Down()
        {
            DropIndex("Users", "IX_User_Nickname");
            DropIndex("Users", "IX_User_AccessToken");
        }
    }
}
