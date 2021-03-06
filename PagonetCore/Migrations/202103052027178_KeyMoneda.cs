namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyMoneda : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AdMoneda");
            AddColumn("dbo.Adpais", "co_mone", c => c.String(maxLength: 6));
            AlterColumn("dbo.AdMoneda", "id_moneda", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AdMoneda", "id_moneda");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AdMoneda");
            AlterColumn("dbo.AdMoneda", "id_moneda", c => c.Int(nullable: false));
            DropColumn("dbo.Adpais", "co_mone");
            AddPrimaryKey("dbo.AdMoneda", "id_moneda");
        }
    }
}
