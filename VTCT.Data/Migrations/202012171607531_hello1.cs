namespace VTCT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VHSTape", "VHSTitle", c => c.String(nullable: false));
            AlterColumn("dbo.VHSTape", "VHSDescription", c => c.String(nullable: false));
            AlterColumn("dbo.VHSTape", "VHSGenre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VHSTape", "VHSGenre", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.VHSTape", "VHSDescription", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.VHSTape", "VHSTitle", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
