namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionCharAString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockAlma", "co_art", c => c.String(maxLength: 30));
            AddColumn("dbo.StockAlma", "tipo", c => c.String(maxLength: 30));
            AddColumn("dbo.StockAlma", "importado_web", c => c.String(maxLength: 1));
            AddColumn("dbo.StockAlma", "importado_pro", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockAlma", "importado_pro");
            DropColumn("dbo.StockAlma", "importado_web");
            DropColumn("dbo.StockAlma", "tipo");
            DropColumn("dbo.StockAlma", "co_art");
        }
    }
}
