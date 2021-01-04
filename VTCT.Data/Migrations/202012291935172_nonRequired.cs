namespace VTCT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nonRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Collection", "CollectionDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Collection", "CollectionDescription", c => c.String(nullable: false));
        }
    }
}
