namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTasas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.adpreciosart", "tasa_v", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.AdCotizacionreg", "tasa_v", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdCotizacionreg", "tasa_v");
            DropColumn("dbo.adpreciosart", "tasa_v");
        }
    }
}
