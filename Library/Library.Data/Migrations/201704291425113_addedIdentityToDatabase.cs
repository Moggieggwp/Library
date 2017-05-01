namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIdentityToDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "User_UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Order", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Order", name: "User_UserId", newName: "User_Id");
            DropPrimaryKey("dbo.ApplicationUser");
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ApplicationUser", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ApplicationUser", "Email", c => c.String());
            AddColumn("dbo.ApplicationUser", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationUser", "PasswordHash", c => c.String());
            AddColumn("dbo.ApplicationUser", "SecurityStamp", c => c.String());
            AddColumn("dbo.ApplicationUser", "PhoneNumber", c => c.String());
            AddColumn("dbo.ApplicationUser", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationUser", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationUser", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.ApplicationUser", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationUser", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "UserName", c => c.String());
            AlterColumn("dbo.Order", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ApplicationUser", "Id");
            CreateIndex("dbo.Order", "User_Id");
            AddForeignKey("dbo.Order", "User_Id", "dbo.ApplicationUser", "Id");
            DropColumn("dbo.ApplicationUser", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "UserId", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.Order", "User_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.IdentityRole");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.AspNetUserClaims", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Order", new[] { "User_Id" });
            DropPrimaryKey("dbo.ApplicationUser");
            AlterColumn("dbo.Order", "User_Id", c => c.Long(nullable: false));
            DropColumn("dbo.ApplicationUser", "UserName");
            DropColumn("dbo.ApplicationUser", "AccessFailedCount");
            DropColumn("dbo.ApplicationUser", "LockoutEnabled");
            DropColumn("dbo.ApplicationUser", "LockoutEndDateUtc");
            DropColumn("dbo.ApplicationUser", "TwoFactorEnabled");
            DropColumn("dbo.ApplicationUser", "PhoneNumberConfirmed");
            DropColumn("dbo.ApplicationUser", "PhoneNumber");
            DropColumn("dbo.ApplicationUser", "SecurityStamp");
            DropColumn("dbo.ApplicationUser", "PasswordHash");
            DropColumn("dbo.ApplicationUser", "EmailConfirmed");
            DropColumn("dbo.ApplicationUser", "Email");
            DropColumn("dbo.ApplicationUser", "Id");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            AddPrimaryKey("dbo.ApplicationUser", "UserId");
            RenameColumn(table: "dbo.Order", name: "User_Id", newName: "User_UserId");
            CreateIndex("dbo.Order", "User_UserId");
            AddForeignKey("dbo.Order", "User_UserId", "dbo.ApplicationUser", "UserId");
        }
    }
}
