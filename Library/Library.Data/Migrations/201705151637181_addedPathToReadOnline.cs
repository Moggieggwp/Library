namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPathToReadOnline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "PathToReadOnline", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "PathToReadOnline");
        }
    }
}
