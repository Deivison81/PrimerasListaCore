namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Caja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdCajas",
                c => new
                    {
                        id_cajas = c.Int(nullable: false, identity: true),
                        co_cajas = c.String(),
                        des_cajas = c.String(maxLength: 60),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_cajas);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdCajas");
        }
    }
}
