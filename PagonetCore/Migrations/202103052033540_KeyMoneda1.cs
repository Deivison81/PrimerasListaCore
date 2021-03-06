namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyMoneda1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adpais", "co_mone", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adpais", "co_mone", c => c.String(maxLength: 6));
        }
    }
}
