namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionCobros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdCobros",
                c => new
                    {
                        id_cob = c.Int(nullable: false, identity: true),
                        cob_num_pro = c.String(nullable: false, maxLength: 15, fixedLength: true),
                        id_clientes = c.Int(nullable: false),
                        co_cli = c.String(maxLength: 16, fixedLength: true),
                        co_mone = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        id_vendedor = c.Int(nullable: false),
                        co_ven = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        tasa = c.Decimal(precision: 21, scale: 8),
                        fecha = c.DateTime(storeType: "smalldatetime"),
                        anulado = c.String(maxLength: 1, fixedLength: true),
                        monto = c.Decimal(precision: 18, scale: 2),
                        importado_web = c.String(maxLength: 1, fixedLength: true),
                        importado_pro = c.String(maxLength: 1, fixedLength: true),
                    })
                .PrimaryKey(t => t.id_cob);
            
            CreateTable(
                "dbo.AdFormasCobro",
                c => new
                    {
                        forma_cob_id = c.Int(nullable: false),
                        nro_reng = c.Int(nullable: false),
                        id_cob = c.Int(),
                        cob_num_pro = c.String(maxLength: 15, fixedLength: true),
                        co_ban = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        forma_pag = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        cod_cta = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        cod_caja = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        mov_num_c = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        mov_num_b = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        mont_doc = c.Decimal(precision: 18, scale: 2),
                        dolar = c.String(maxLength: 1, fixedLength: true),
                        importado_web = c.String(maxLength: 1, fixedLength: true),
                        importado_pro = c.String(maxLength: 1, fixedLength: true),
                    })
                .PrimaryKey(t => new { t.forma_cob_id, t.nro_reng });
            
            CreateTable(
                "dbo.AdMoneda",
                c => new
                    {
                        id_moneda = c.Int(nullable: false),
                        co_mone = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        mone_des = c.String(maxLength: 60, unicode: false),
                        importado_web = c.String(maxLength: 1, fixedLength: true),
                        importado_pro = c.String(maxLength: 1, fixedLength: true),
                    })
                .PrimaryKey(t => t.id_moneda);
            
            CreateTable(
                "dbo.AdMovimientoBanco",
                c => new
                    {
                        mov_num = c.String(nullable: false, maxLength: 20, fixedLength: true, unicode: false),
                        descrip = c.String(maxLength: 160, unicode: false),
                        cod_cta = c.String(nullable: false, maxLength: 6, fixedLength: true, unicode: false),
                        co_cta_ingr_egr = c.String(nullable: false, maxLength: 20, fixedLength: true, unicode: false),
                        fecha = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        tasa = c.Decimal(nullable: false, precision: 18, scale: 5),
                        tipo_op = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        doc_num = c.String(nullable: false, maxLength: 20, unicode: false),
                        monto_d = c.Decimal(nullable: false, precision: 18, scale: 2),
                        monto_h = c.Decimal(nullable: false, precision: 18, scale: 2),
                        idb = c.Decimal(nullable: false, precision: 18, scale: 2),
                        saldo_ini = c.Boolean(nullable: false),
                        origen = c.String(nullable: false, maxLength: 3, fixedLength: true, unicode: false),
                        cob_pag = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        dep_num = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        conciliado = c.Boolean(nullable: false),
                        ori_dep = c.Boolean(nullable: false),
                        anulado = c.Boolean(nullable: false),
                        dep_con = c.Int(nullable: false),
                        fec_con = c.DateTime(storeType: "smalldatetime"),
                        cod_ingben = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        fecha_che = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        feccom = c.DateTime(storeType: "smalldatetime"),
                        numcom = c.Int(),
                        dis_cen = c.String(storeType: "xml"),
                        campo1 = c.String(maxLength: 60, unicode: false),
                        campo2 = c.String(maxLength: 60, unicode: false),
                        campo3 = c.String(maxLength: 60, unicode: false),
                        campo4 = c.String(maxLength: 60, unicode: false),
                        campo5 = c.String(maxLength: 60, unicode: false),
                        campo6 = c.String(maxLength: 60, unicode: false),
                        campo7 = c.String(maxLength: 60, unicode: false),
                        campo8 = c.String(maxLength: 60, unicode: false),
                        co_us_in = c.String(nullable: false, maxLength: 6, fixedLength: true, unicode: false),
                        co_sucu_in = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        fe_us_in = c.DateTime(nullable: false),
                        co_us_mo = c.String(nullable: false, maxLength: 6, fixedLength: true, unicode: false),
                        co_sucu_mo = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        fe_us_mo = c.DateTime(nullable: false),
                        trasnfe = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        revisado = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        nro_transf_nomi = c.Int(),
                        importado_web = c.String(maxLength: 1, fixedLength: true),
                        importado_pro = c.String(maxLength: 1, fixedLength: true),
                    })
                .PrimaryKey(t => t.mov_num);
            
            CreateTable(
                "dbo.AdRenglonesCobro",
                c => new
                    {
                        idrencob = c.Int(nullable: false),
                        reng_num = c.Int(nullable: false),
                        id_cob = c.Int(nullable: false, identity: true),
                        cob_num_pro = c.String(nullable: false, maxLength: 15, fixedLength: true),
                        co_tipo_doc = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        nro_doc = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        mont_cob = c.Decimal(precision: 18, scale: 2),
                        dpcobro_monto = c.Decimal(precision: 18, scale: 2),
                        tipo_doc = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        num_doc = c.String(maxLength: 20, unicode: false),
                        saldo = c.Decimal(precision: 18, scale: 2),
                        importado_web = c.String(maxLength: 1, fixedLength: true),
                        importado_pro = c.String(maxLength: 1, fixedLength: true),
                    })
                .PrimaryKey(t => t.idrencob);
            
            CreateTable(
                "dbo.AdTasa",
                c => new
                    {
                        idmone = c.Int(nullable: false, identity: true),
                        co_mone = c.String(maxLength: 6, fixedLength: true, unicode: false),
                        fecha = c.DateTime(storeType: "smalldatetime"),
                        tasa_c = c.Decimal(precision: 21, scale: 8),
                        tasa_v = c.Decimal(precision: 21, scale: 8),
                        importado_web = c.String(maxLength: 1, fixedLength: true),
                        importado_pro = c.String(maxLength: 1, fixedLength: true),
                    })
                .PrimaryKey(t => t.idmone);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdTasa");
            DropTable("dbo.AdRenglonesCobro");
            DropTable("dbo.AdMovimientoBanco");
            DropTable("dbo.AdMoneda");
            DropTable("dbo.AdFormasCobro");
            DropTable("dbo.AdCobros");
        }
    }
}
