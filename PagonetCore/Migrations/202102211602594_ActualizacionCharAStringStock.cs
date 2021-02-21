namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionCharAStringStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockAlma", "co_alma", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockAlma", "co_alma");
        }
    }
}
