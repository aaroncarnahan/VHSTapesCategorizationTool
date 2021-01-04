namespace VTCT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lordohlord : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VHSTape", "Collection_CollectionID", "dbo.Collection");
            DropIndex("dbo.VHSTape", new[] { "Collection_CollectionID" });
            DropColumn("dbo.VHSTape", "Collection_CollectionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VHSTape", "Collection_CollectionID", c => c.Int());
            CreateIndex("dbo.VHSTape", "Collection_CollectionID");
            AddForeignKey("dbo.VHSTape", "Collection_CollectionID", "dbo.Collection", "CollectionID");
        }
    }
}
