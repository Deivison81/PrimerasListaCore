namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyFormasCobro : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AdFormasCobro");
            AlterColumn("dbo.AdFormasCobro", "forma_cob_id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AdFormasCobro", "id_cob", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AdFormasCobro", "forma_cob_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AdFormasCobro");
            AlterColumn("dbo.AdFormasCobro", "id_cob", c => c.Int());
            AlterColumn("dbo.AdFormasCobro", "forma_cob_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AdFormasCobro", new[] { "forma_cob_id", "nro_reng" });
        }
    }
}
