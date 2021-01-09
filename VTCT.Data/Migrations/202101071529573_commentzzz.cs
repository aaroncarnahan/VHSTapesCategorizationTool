namespace VTCT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentzzz : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Collection_CollectionID", "dbo.Collection");
            DropIndex("dbo.Comment", new[] { "Collection_CollectionID" });
            RenameColumn(table: "dbo.Comment", name: "Collection_CollectionID", newName: "CollectionID");
            AlterColumn("dbo.Comment", "CollectionID", c => c.Int(nullable: true));
            CreateIndex("dbo.Comment", "CollectionID");
            AddForeignKey("dbo.Comment", "CollectionID", "dbo.Collection", "CollectionID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "CollectionID", "dbo.Collection");
            DropIndex("dbo.Comment", new[] { "CollectionID" });
            AlterColumn("dbo.Comment", "CollectionID", c => c.Int());
            RenameColumn(table: "dbo.Comment", name: "CollectionID", newName: "Collection_CollectionID");
            CreateIndex("dbo.Comment", "Collection_CollectionID");
            AddForeignKey("dbo.Comment", "Collection_CollectionID", "dbo.Collection", "CollectionID");
        }
    }
}
