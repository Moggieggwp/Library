namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _return : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Book", name: "PublisherId", newName: "Publisher_Id");
            RenameIndex(table: "dbo.Book", name: "IX_PublisherId", newName: "IX_Publisher_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Book", name: "IX_Publisher_Id", newName: "IX_PublisherId");
            RenameColumn(table: "dbo.Book", name: "Publisher_Id", newName: "PublisherId");
        }
    }
}
