namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreccionDocNumCotizacion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adcotizacion", "doc_num", c => c.String(maxLength: 20));
            AlterColumn("dbo.AdCotizacionreg", "doc_num", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdCotizacionreg", "doc_num", c => c.Int());
            AlterColumn("dbo.Adcotizacion", "doc_num", c => c.Int());
        }
    }
}
