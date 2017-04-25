namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Fare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pages = c.Int(nullable: false),
                        IsOrdered = c.Boolean(nullable: false),
                        IssueYear = c.DateTime(nullable: false),
                        Order_Id = c.Long(),
                        Publisher_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .ForeignKey("dbo.Publisher", t => t.Publisher_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        User_UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participation",
                c => new
                    {
                        BookId = c.Long(nullable: false),
                        WriterId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.WriterId })
                .ForeignKey("dbo.Book", t => t.BookId)
                .ForeignKey("dbo.Writer", t => t.WriterId)
                .Index(t => t.BookId)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Writer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participation", "WriterId", "dbo.Writer");
            DropForeignKey("dbo.Participation", "BookId", "dbo.Book");
            DropForeignKey("dbo.Book", "Publisher_Id", "dbo.Publisher");
            DropForeignKey("dbo.Book", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.Order", "User_UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Participation", new[] { "WriterId" });
            DropIndex("dbo.Participation", new[] { "BookId" });
            DropIndex("dbo.Order", new[] { "User_UserId" });
            DropIndex("dbo.Book", new[] { "Publisher_Id" });
            DropIndex("dbo.Book", new[] { "Order_Id" });
            DropTable("dbo.Writer");
            DropTable("dbo.Participation");
            DropTable("dbo.Publisher");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Order");
            DropTable("dbo.Book");
        }
    }
}
