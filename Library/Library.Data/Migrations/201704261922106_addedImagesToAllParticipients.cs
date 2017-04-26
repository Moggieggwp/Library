namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImagesToAllParticipients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publisher", "ImageName", c => c.String());
            AddColumn("dbo.Writer", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writer", "ImageName");
            DropColumn("dbo.Publisher", "ImageName");
        }
    }
}
