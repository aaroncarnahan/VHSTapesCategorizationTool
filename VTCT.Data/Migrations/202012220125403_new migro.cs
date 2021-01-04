namespace VTCT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collection",
                c => new
                    {
                        CollectionID = c.Int(nullable: false, identity: true),
                        CollectionOwnerID = c.Guid(nullable: false),
                        CollectionName = c.String(nullable: false),
                        CollectionDescription = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.CollectionID);
            
            AddColumn("dbo.VHSTape", "Collection_CollectionID", c => c.Int());
            CreateIndex("dbo.VHSTape", "Collection_CollectionID");
            AddForeignKey("dbo.VHSTape", "Collection_CollectionID", "dbo.Collection", "CollectionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VHSTape", "Collection_CollectionID", "dbo.Collection");
            DropIndex("dbo.VHSTape", new[] { "Collection_CollectionID" });
            DropColumn("dbo.VHSTape", "Collection_CollectionID");
            DropTable("dbo.Collection");
        }
    }
}
