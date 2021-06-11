namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropiedadRenglonesFormasCobros : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AdFormasCobro", "id_cob");
            CreateIndex("dbo.AdRenglonesCobro", "id_cob");
            AddForeignKey("dbo.AdFormasCobro", "id_cob", "dbo.AdCobros", "id_cob", cascadeDelete: true);
            AddForeignKey("dbo.AdRenglonesCobro", "id_cob", "dbo.AdCobros", "id_cob", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdRenglonesCobro", "id_cob", "dbo.AdCobros");
            DropForeignKey("dbo.AdFormasCobro", "id_cob", "dbo.AdCobros");
            DropIndex("dbo.AdRenglonesCobro", new[] { "id_cob" });
            DropIndex("dbo.AdFormasCobro", new[] { "id_cob" });
        }
    }
}
