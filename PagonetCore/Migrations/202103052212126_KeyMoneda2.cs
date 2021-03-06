namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyMoneda2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adtipo_cliente", "co_precio", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adtipo_cliente", "co_precio");
        }
    }
}
