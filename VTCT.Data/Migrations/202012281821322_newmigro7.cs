namespace VTCT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigro7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectionTape",
                c => new
                    {
                        CollectionTapeID = c.Int(nullable: false, identity: true),
                        CollectionID = c.Int(nullable: false),
                        VHSTapeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionTapeID)
                .ForeignKey("dbo.Collection", t => t.CollectionID, cascadeDelete: true)
                .ForeignKey("dbo.VHSTape", t => t.VHSTapeID, cascadeDelete: true)
                .Index(t => t.CollectionID)
                .Index(t => t.VHSTapeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionTape", "VHSTapeID", "dbo.VHSTape");
            DropForeignKey("dbo.CollectionTape", "CollectionID", "dbo.Collection");
            DropIndex("dbo.CollectionTape", new[] { "VHSTapeID" });
            DropIndex("dbo.CollectionTape", new[] { "CollectionID" });
            DropTable("dbo.CollectionTape");
        }
    }
}
