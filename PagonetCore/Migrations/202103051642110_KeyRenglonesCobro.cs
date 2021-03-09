namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyRenglonesCobro : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AdRenglonesCobro");
            AlterColumn("dbo.AdRenglonesCobro", "idrencob", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AdRenglonesCobro", "id_cob", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AdRenglonesCobro", "idrencob");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AdRenglonesCobro");
            AlterColumn("dbo.AdRenglonesCobro", "id_cob", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AdRenglonesCobro", "idrencob", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AdRenglonesCobro", "idrencob");
        }
    }
}
