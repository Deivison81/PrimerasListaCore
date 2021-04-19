namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ACTUALIZARCOTI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adcotizacion", "Direcionop", c => c.String(maxLength: 60));
            AddColumn("dbo.Adtransporte", "transporte_local", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adtransporte", "transporte_local");
            DropColumn("dbo.Adcotizacion", "Direcionop");
        }
    }
}
