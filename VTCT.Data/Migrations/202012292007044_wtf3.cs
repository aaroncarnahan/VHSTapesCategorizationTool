namespace VTCT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VHSTape", "CollectionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VHSTape", "CollectionName", c => c.String());
        }
    }
}
