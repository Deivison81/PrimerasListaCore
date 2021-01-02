namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdAlmacen",
                c => new
                    {
                        cod_almacen = c.Int(nullable: false, identity: true),
                        co_alma = c.String(maxLength: 6),
                        des_alamacen = c.String(maxLength: 60),
                        web = c.String(maxLength: 1),
                        co_user_prof = c.String(maxLength: 6),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.cod_almacen);
            
            CreateTable(
                "dbo.AdArticulo",
                c => new
                    {
                        id_art = c.Int(nullable: false, identity: true),
                        co_art = c.String(nullable: false, maxLength: 30),
                        art_des = c.String(nullable: false, maxLength: 120),
                        co_lin = c.String(nullable: false, maxLength: 6),
                        co_subl = c.String(nullable: false, maxLength: 6),
                        co_cat = c.String(nullable: false, maxLength: 6),
                        co_color = c.String(nullable: false, maxLength: 6),
                        co_ubicacion = c.String(nullable: false, maxLength: 6),
                        cod_proc = c.String(maxLength: 6),
                        cod_unidad = c.String(nullable: false, maxLength: 6),
                        referencia = c.String(maxLength: 20),
                        tipo_imp = c.String(maxLength: 1),
                        tipo_imp2 = c.String(maxLength: 1),
                        tipo_imp3 = c.String(maxLength: 1),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_art);
            
            CreateTable(
                "dbo.Adimg_art",
                c => new
                    {
                        id_imgart = c.Int(nullable: false),
                        co_art = c.String(nullable: false, maxLength: 30),
                        tip = c.String(nullable: false, maxLength: 6),
                        imagen_des = c.String(nullable: false, maxLength: 60),
                        picture = c.String(nullable: false, maxLength: 128),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        AdArticulo_id_art = c.Int(),
                        id_art_id_art = c.Int(),
                        AdArticulo_id_art1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.id_imgart, t.co_art, t.tip, t.imagen_des, t.picture })
                .ForeignKey("dbo.AdArticulo", t => t.AdArticulo_id_art)
                .ForeignKey("dbo.AdArticulo", t => t.id_art_id_art)
                .ForeignKey("dbo.AdArticulo", t => t.AdArticulo_id_art1)
                .Index(t => t.AdArticulo_id_art)
                .Index(t => t.id_art_id_art)
                .Index(t => t.AdArticulo_id_art1);
            
            CreateTable(
                "dbo.adpreciosart",
                c => new
                    {
                        id_preciosart = c.Int(nullable: false, identity: true),
                        co_art = c.String(nullable: false, maxLength: 30),
                        co_precios = c.String(nullable: false, maxLength: 6),
                        desde = c.DateTime(),
                        hasta = c.DateTime(),
                        co_alma = c.String(maxLength: 6),
                        monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        montoadi1 = c.Decimal(precision: 18, scale: 2),
                        montoadi2 = c.Decimal(precision: 18, scale: 2),
                        montoadi3 = c.Decimal(precision: 18, scale: 2),
                        montoadi4 = c.Decimal(precision: 18, scale: 2),
                        montoadi5 = c.Decimal(precision: 18, scale: 2),
                        precioOm = c.String(maxLength: 1),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        AdArticulo_id_art = c.Int(),
                        cod_almacen_cod_almacen = c.Int(),
                        id_art_id_art = c.Int(),
                        AdArticulo_id_art1 = c.Int(),
                    })
                .PrimaryKey(t => t.id_preciosart)
                .ForeignKey("dbo.AdArticulo", t => t.AdArticulo_id_art)
                .ForeignKey("dbo.AdAlmacen", t => t.cod_almacen_cod_almacen)
                .ForeignKey("dbo.AdArticulo", t => t.id_art_id_art)
                .ForeignKey("dbo.AdArticulo", t => t.AdArticulo_id_art1)
                .Index(t => t.AdArticulo_id_art)
                .Index(t => t.cod_almacen_cod_almacen)
                .Index(t => t.id_art_id_art)
                .Index(t => t.AdArticulo_id_art1);
            
            CreateTable(
                "dbo.AdSerial",
                c => new
                    {
                        reng_num = c.Int(nullable: false),
                        co_art = c.String(maxLength: 30),
                        co_alma = c.String(maxLength: 6),
                        serial = c.String(maxLength: 40),
                        tip_dispositivo = c.String(maxLength: 40),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        AdArticulo_id_art = c.Int(),
                        cod_almacen_cod_almacen = c.Int(),
                        id_art_id_art = c.Int(),
                        AdArticulo_id_art1 = c.Int(),
                    })
                .PrimaryKey(t => t.reng_num)
                .ForeignKey("dbo.AdArticulo", t => t.AdArticulo_id_art)
                .ForeignKey("dbo.AdAlmacen", t => t.cod_almacen_cod_almacen)
                .ForeignKey("dbo.AdArticulo", t => t.id_art_id_art)
                .ForeignKey("dbo.AdArticulo", t => t.AdArticulo_id_art1)
                .Index(t => t.AdArticulo_id_art)
                .Index(t => t.cod_almacen_cod_almacen)
                .Index(t => t.id_art_id_art)
                .Index(t => t.AdArticulo_id_art1);
            
            CreateTable(
                "dbo.AdBanco",
                c => new
                    {
                        id_banco = c.Int(nullable: false),
                        co_ban = c.String(nullable: false, maxLength: 6),
                        des_ban = c.String(nullable: false, maxLength: 60),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => new { t.id_banco, t.co_ban, t.des_ban });
            
            CreateTable(
                "dbo.Adclientes",
                c => new
                    {
                        id_clientes = c.Int(nullable: false, identity: true),
                        co_cli = c.String(nullable: false, maxLength: 16),
                        tip_cli = c.String(nullable: false, maxLength: 6),
                        cli_des = c.String(nullable: false, maxLength: 100),
                        direc1 = c.String(nullable: false),
                        dir_ent2 = c.String(nullable: false),
                        telefonos = c.String(nullable: false, maxLength: 60),
                        inactivo = c.String(nullable: false, maxLength: 1),
                        respons = c.String(nullable: false, maxLength: 60),
                        co_zon = c.String(nullable: false, maxLength: 6),
                        co_seg = c.String(nullable: false, maxLength: 6),
                        co_ven = c.String(nullable: false, maxLength: 6),
                        co_cta_ingr_egr = c.String(nullable: false, maxLength: 6),
                        rif = c.String(nullable: false, maxLength: 18),
                        email = c.String(nullable: false, maxLength: 60),
                        juridico = c.String(nullable: false, maxLength: 1),
                        ciudad = c.String(nullable: false, maxLength: 50),
                        zip = c.String(nullable: false, maxLength: 10),
                        id_pais = c.Int(nullable: false),
                        co_pais = c.String(nullable: false, maxLength: 6),
                        cod_comercio = c.String(maxLength: 20),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        id_segmento_id_segmento = c.Int(),
                        id_tipocliente_id_tipocliente = c.Int(),
                        id_vendedor_id_vendedor = c.Int(),
                        id_zona_id_zona = c.Int(),
                        idingre_id = c.Int(),
                    })
                .PrimaryKey(t => t.id_clientes)
                .ForeignKey("dbo.AdSegmento", t => t.id_segmento_id_segmento)
                .ForeignKey("dbo.Adtipo_cliente", t => t.id_tipocliente_id_tipocliente)
                .ForeignKey("dbo.Advendedor", t => t.id_vendedor_id_vendedor)
                .ForeignKey("dbo.Adzona", t => t.id_zona_id_zona)
                .ForeignKey("dbo.AdIngreso", t => t.idingre_id)
                .Index(t => t.id_segmento_id_segmento)
                .Index(t => t.id_tipocliente_id_tipocliente)
                .Index(t => t.id_vendedor_id_vendedor)
                .Index(t => t.id_zona_id_zona)
                .Index(t => t.idingre_id);
            
            CreateTable(
                "dbo.AdSegmento",
                c => new
                    {
                        id_segmento = c.Int(nullable: false, identity: true),
                        co_seg = c.String(nullable: false, maxLength: 6),
                        seg_des = c.String(maxLength: 60),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_segmento);
            
            CreateTable(
                "dbo.Adtipo_cliente",
                c => new
                    {
                        id_tipocliente = c.Int(nullable: false, identity: true),
                        tip_cli = c.String(nullable: false, maxLength: 6),
                        des_tipo = c.String(maxLength: 60),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_tipocliente);
            
            CreateTable(
                "dbo.Advendedor",
                c => new
                    {
                        id_vendedor = c.Int(nullable: false, identity: true),
                        co_ven = c.String(maxLength: 6),
                        tipo = c.String(maxLength: 4),
                        ven_des = c.String(maxLength: 60),
                        co_zon = c.String(nullable: false, maxLength: 6),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        id_zona_id_zona = c.Int(),
                    })
                .PrimaryKey(t => t.id_vendedor)
                .ForeignKey("dbo.Adzona", t => t.id_zona_id_zona)
                .Index(t => t.id_zona_id_zona);
            
            CreateTable(
                "dbo.Adzona",
                c => new
                    {
                        id_zona = c.Int(nullable: false, identity: true),
                        co_zon = c.String(nullable: false, maxLength: 6),
                        zon_des = c.String(maxLength: 60),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_zona);
            
            CreateTable(
                "dbo.AdIngreso",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        co_ctaIng_egr = c.String(maxLength: 20),
                        descrip_ingre = c.String(maxLength: 60),
                        co_user_prof = c.String(maxLength: 6),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Adcondiciondepago",
                c => new
                    {
                        id_condicion = c.Int(nullable: false, identity: true),
                        co_cond = c.String(maxLength: 6),
                        cond_des = c.String(maxLength: 60),
                        dias_cred = c.Int(),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_condicion);
            
            CreateTable(
                "dbo.Adcotizacion",
                c => new
                    {
                        id_doc_num = c.Int(nullable: false, identity: true),
                        doc_num = c.Int(),
                        descrip = c.String(maxLength: 60),
                        co_cli = c.String(maxLength: 16),
                        co_tran = c.String(maxLength: 6),
                        co_mone = c.String(maxLength: 6),
                        co_ven = c.String(maxLength: 6),
                        co_cond = c.String(maxLength: 6),
                        fec_emis = c.DateTime(storeType: "smalldatetime"),
                        fec_venc = c.DateTime(storeType: "smalldatetime"),
                        fec_reg = c.DateTime(storeType: "smalldatetime"),
                        anulado = c.String(maxLength: 1),
                        status = c.String(maxLength: 1),
                        total_bruto = c.Decimal(precision: 18, scale: 2),
                        monto_imp = c.Decimal(precision: 18, scale: 2),
                        monto_imp2 = c.Decimal(precision: 18, scale: 2),
                        monto_imp3 = c.Decimal(precision: 18, scale: 2),
                        total_neto = c.Decimal(precision: 18, scale: 2),
                        saldo = c.Decimal(precision: 18, scale: 2),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        Diasvencimiento = c.Int(),
                        nro_pedido = c.Int(),
                        vencida = c.String(maxLength: 1),
                        id_clientes_id_clientes = c.Int(),
                        id_condicion_id_condicion = c.Int(),
                        id_vendedor_id_vendedor = c.Int(),
                        idtransporte_idtransporte = c.Int(),
                    })
                .PrimaryKey(t => t.id_doc_num)
                .ForeignKey("dbo.Adclientes", t => t.id_clientes_id_clientes)
                .ForeignKey("dbo.Adcondiciondepago", t => t.id_condicion_id_condicion)
                .ForeignKey("dbo.Advendedor", t => t.id_vendedor_id_vendedor)
                .ForeignKey("dbo.Adtransporte", t => t.idtransporte_idtransporte)
                .Index(t => t.id_clientes_id_clientes)
                .Index(t => t.id_condicion_id_condicion)
                .Index(t => t.id_vendedor_id_vendedor)
                .Index(t => t.idtransporte_idtransporte);
            
            CreateTable(
                "dbo.Adtransporte",
                c => new
                    {
                        idtransporte = c.Int(nullable: false, identity: true),
                        co_tran = c.String(maxLength: 6),
                        des_tran = c.String(maxLength: 60),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.idtransporte);
            
            CreateTable(
                "dbo.Adpais",
                c => new
                    {
                        id_pais = c.Int(nullable: false, identity: true),
                        co_pais = c.String(maxLength: 6),
                        pais_des = c.String(maxLength: 60),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_pais);
            
            CreateTable(
                "dbo.Adpedidos",
                c => new
                    {
                        id_doc_num = c.Int(nullable: false, identity: true),
                        doc_num = c.String(maxLength: 20),
                        descrip = c.String(maxLength: 60),
                        co_cli = c.String(maxLength: 16),
                        co_tran = c.String(maxLength: 6),
                        co_mone = c.String(maxLength: 6),
                        co_ven = c.String(maxLength: 6),
                        co_cond = c.String(maxLength: 6),
                        fec_emis = c.DateTime(storeType: "smalldatetime"),
                        fec_venc = c.DateTime(storeType: "smalldatetime"),
                        fec_reg = c.DateTime(storeType: "smalldatetime"),
                        anulado = c.String(maxLength: 1),
                        status = c.String(maxLength: 1),
                        total_bruto = c.Decimal(precision: 18, scale: 2),
                        monto_imp = c.Decimal(precision: 18, scale: 2),
                        monto_imp2 = c.Decimal(precision: 18, scale: 2),
                        monto_imp3 = c.Decimal(precision: 18, scale: 2),
                        total_neto = c.Decimal(precision: 18, scale: 2),
                        saldo = c.Decimal(precision: 18, scale: 2),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        Diasvencimiento = c.Int(),
                        nro_pedido = c.String(maxLength: 1),
                        vencida = c.String(maxLength: 1),
                        id_clientes_id_clientes = c.Int(),
                        id_condicion_id_condicion = c.Int(),
                        id_vendedor_id_vendedor = c.Int(),
                        idtransporte_idtransporte = c.Int(),
                    })
                .PrimaryKey(t => t.id_doc_num)
                .ForeignKey("dbo.Adclientes", t => t.id_clientes_id_clientes)
                .ForeignKey("dbo.Adcondiciondepago", t => t.id_condicion_id_condicion)
                .ForeignKey("dbo.Advendedor", t => t.id_vendedor_id_vendedor)
                .ForeignKey("dbo.Adtransporte", t => t.idtransporte_idtransporte)
                .Index(t => t.id_clientes_id_clientes)
                .Index(t => t.id_condicion_id_condicion)
                .Index(t => t.id_vendedor_id_vendedor)
                .Index(t => t.idtransporte_idtransporte);
            
            CreateTable(
                "dbo.AdCotizacionreg",
                c => new
                    {
                        id_doc_num = c.Int(nullable: false, identity: true),
                        doc_num = c.Int(),
                        reng_num = c.Int(nullable: false),
                        co_art = c.String(maxLength: 30),
                        art_des = c.String(maxLength: 120),
                        co_alma = c.String(maxLength: 6),
                        total_art = c.Decimal(precision: 18, scale: 2),
                        stotal_art = c.Decimal(precision: 18, scale: 2),
                        cod_unidad = c.String(maxLength: 6),
                        co_precios = c.String(maxLength: 6),
                        prec_vta = c.Decimal(precision: 18, scale: 2),
                        prec_vta_om = c.Decimal(precision: 18, scale: 2),
                        tipo_imp = c.String(maxLength: 1),
                        tipo_imp2 = c.String(maxLength: 1),
                        tipo_imp3 = c.String(maxLength: 1),
                        porc_imp = c.Decimal(precision: 18, scale: 2),
                        porc_imp2 = c.Decimal(precision: 18, scale: 2),
                        porc_imp3 = c.Decimal(precision: 18, scale: 2),
                        monto_imp = c.Decimal(precision: 18, scale: 2),
                        monto_imp2 = c.Decimal(precision: 18, scale: 2),
                        monto_imp3 = c.Decimal(precision: 18, scale: 2),
                        reng_neto = c.Decimal(precision: 18, scale: 2),
                        tipo_doc = c.String(maxLength: 4),
                        num_doc = c.String(maxLength: 20),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        cod_almacen_cod_almacen = c.Int(),
                        id_art_id_art = c.Int(),
                        id_preciosart_id_preciosart = c.Int(),
                    })
                .PrimaryKey(t => t.id_doc_num)
                .ForeignKey("dbo.AdAlmacen", t => t.cod_almacen_cod_almacen)
                .ForeignKey("dbo.AdArticulo", t => t.id_art_id_art)
                .ForeignKey("dbo.adpreciosart", t => t.id_preciosart_id_preciosart)
                .Index(t => t.cod_almacen_cod_almacen)
                .Index(t => t.id_art_id_art)
                .Index(t => t.id_preciosart_id_preciosart);
            
            CreateTable(
                "dbo.AdPedidosreg",
                c => new
                    {
                        RenglonPedidoID = c.Int(nullable: false, identity: true),
                        id_doc_num = c.Int(),
                        doc_num = c.String(maxLength: 20),
                        co_art = c.String(maxLength: 30),
                        art_des = c.String(maxLength: 120),
                        co_alma = c.String(maxLength: 6),
                        total_art = c.Decimal(precision: 18, scale: 2),
                        stotal_art = c.Decimal(precision: 18, scale: 2),
                        cod_unidad = c.String(maxLength: 6),
                        id_preciosart = c.Int(),
                        co_precios = c.String(maxLength: 6),
                        prec_vta = c.Decimal(precision: 18, scale: 2),
                        prec_vta_om = c.Decimal(precision: 18, scale: 2),
                        tipo_imp = c.String(maxLength: 1),
                        tipo_imp2 = c.String(maxLength: 1),
                        tipo_imp3 = c.String(maxLength: 1),
                        porc_imp = c.Decimal(precision: 18, scale: 2),
                        porc_imp2 = c.Decimal(precision: 18, scale: 2),
                        porc_imp3 = c.Decimal(precision: 18, scale: 2),
                        monto_imp = c.Decimal(precision: 18, scale: 2),
                        monto_imp2 = c.Decimal(precision: 18, scale: 2),
                        monto_imp3 = c.Decimal(precision: 18, scale: 2),
                        reng_neto = c.Decimal(precision: 18, scale: 2),
                        tipo_doc = c.String(maxLength: 4),
                        num_doc = c.String(maxLength: 20),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                        cod_almacen_cod_almacen = c.Int(),
                        id_art_id_art = c.Int(),
                    })
                .PrimaryKey(t => t.RenglonPedidoID)
                .ForeignKey("dbo.AdAlmacen", t => t.cod_almacen_cod_almacen)
                .ForeignKey("dbo.AdArticulo", t => t.id_art_id_art)
                .ForeignKey("dbo.Adpedidos", t => t.id_doc_num)
                .Index(t => t.id_doc_num)
                .Index(t => t.cod_almacen_cod_almacen)
                .Index(t => t.id_art_id_art);
            
            CreateTable(
                "dbo.sazona",
                c => new
                    {
                        co_zon = c.String(nullable: false, maxLength: 128),
                        zon_des = c.String(),
                        numcom = c.Int(nullable: false),
                        feccom = c.DateTime(nullable: false),
                        campo1 = c.String(),
                        campo2 = c.String(),
                        campo3 = c.String(),
                        campo4 = c.String(),
                        campo5 = c.String(),
                        campo6 = c.String(),
                        campo7 = c.String(),
                        campo8 = c.String(),
                        fe_us_in = c.DateTime(nullable: false),
                        fe_us_mo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.co_zon);
            
            CreateTable(
                "dbo.StockAlma",
                c => new
                    {
                        StockAlmacenID = c.Int(nullable: false, identity: true),
                        stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        cod_almacen_cod_almacen = c.Int(),
                        id_art_id_art = c.Int(),
                    })
                .PrimaryKey(t => t.StockAlmacenID)
                .ForeignKey("dbo.AdAlmacen", t => t.cod_almacen_cod_almacen)
                .ForeignKey("dbo.AdArticulo", t => t.id_art_id_art)
                .Index(t => t.cod_almacen_cod_almacen)
                .Index(t => t.id_art_id_art);
            
            CreateTable(
                "dbo.Tasa_IVA",
                c => new
                    {
                        id_impuesto = c.Int(nullable: false),
                        fechapubli = c.DateTime(nullable: false),
                        nro_reng = c.Int(nullable: false, identity: true),
                        tip_impu = c.Int(nullable: false),
                        ventas = c.String(nullable: false, maxLength: 1),
                        consumosuntuario = c.String(maxLength: 1),
                        porcentajetaza = c.Decimal(nullable: false, precision: 18, scale: 2),
                        porcentajesuntuario = c.Decimal(precision: 18, scale: 2),
                        importado_web = c.String(maxLength: 1),
                        importado_pro = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.id_impuesto);
            
            CreateTable(
                "dbo.Adusuarios",
                c => new
                    {
                        id = c.Int(nullable: false),
                        co_user_prof = c.String(nullable: false, maxLength: 6),
                        cod_user = c.String(nullable: false, maxLength: 6),
                        nombre_usuarios = c.String(nullable: false, maxLength: 60),
                        password = c.Binary(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 1),
                        fecha_ingreso = c.DateTime(nullable: false),
                        validacion = c.String(maxLength: 6),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockAlma", "id_art_id_art", "dbo.AdArticulo");
            DropForeignKey("dbo.StockAlma", "cod_almacen_cod_almacen", "dbo.AdAlmacen");
            DropForeignKey("dbo.AdPedidosreg", "id_doc_num", "dbo.Adpedidos");
            DropForeignKey("dbo.AdPedidosreg", "id_art_id_art", "dbo.AdArticulo");
            DropForeignKey("dbo.AdPedidosreg", "cod_almacen_cod_almacen", "dbo.AdAlmacen");
            DropForeignKey("dbo.AdCotizacionreg", "id_preciosart_id_preciosart", "dbo.adpreciosart");
            DropForeignKey("dbo.AdCotizacionreg", "id_art_id_art", "dbo.AdArticulo");
            DropForeignKey("dbo.AdCotizacionreg", "cod_almacen_cod_almacen", "dbo.AdAlmacen");
            DropForeignKey("dbo.Adpedidos", "idtransporte_idtransporte", "dbo.Adtransporte");
            DropForeignKey("dbo.Adpedidos", "id_vendedor_id_vendedor", "dbo.Advendedor");
            DropForeignKey("dbo.Adpedidos", "id_condicion_id_condicion", "dbo.Adcondiciondepago");
            DropForeignKey("dbo.Adpedidos", "id_clientes_id_clientes", "dbo.Adclientes");
            DropForeignKey("dbo.Adcotizacion", "idtransporte_idtransporte", "dbo.Adtransporte");
            DropForeignKey("dbo.Adcotizacion", "id_vendedor_id_vendedor", "dbo.Advendedor");
            DropForeignKey("dbo.Adcotizacion", "id_condicion_id_condicion", "dbo.Adcondiciondepago");
            DropForeignKey("dbo.Adcotizacion", "id_clientes_id_clientes", "dbo.Adclientes");
            DropForeignKey("dbo.Adclientes", "idingre_id", "dbo.AdIngreso");
            DropForeignKey("dbo.Adclientes", "id_zona_id_zona", "dbo.Adzona");
            DropForeignKey("dbo.Adclientes", "id_vendedor_id_vendedor", "dbo.Advendedor");
            DropForeignKey("dbo.Advendedor", "id_zona_id_zona", "dbo.Adzona");
            DropForeignKey("dbo.Adclientes", "id_tipocliente_id_tipocliente", "dbo.Adtipo_cliente");
            DropForeignKey("dbo.Adclientes", "id_segmento_id_segmento", "dbo.AdSegmento");
            DropForeignKey("dbo.AdSerial", "AdArticulo_id_art1", "dbo.AdArticulo");
            DropForeignKey("dbo.AdSerial", "id_art_id_art", "dbo.AdArticulo");
            DropForeignKey("dbo.AdSerial", "cod_almacen_cod_almacen", "dbo.AdAlmacen");
            DropForeignKey("dbo.AdSerial", "AdArticulo_id_art", "dbo.AdArticulo");
            DropForeignKey("dbo.adpreciosart", "AdArticulo_id_art1", "dbo.AdArticulo");
            DropForeignKey("dbo.adpreciosart", "id_art_id_art", "dbo.AdArticulo");
            DropForeignKey("dbo.adpreciosart", "cod_almacen_cod_almacen", "dbo.AdAlmacen");
            DropForeignKey("dbo.adpreciosart", "AdArticulo_id_art", "dbo.AdArticulo");
            DropForeignKey("dbo.Adimg_art", "AdArticulo_id_art1", "dbo.AdArticulo");
            DropForeignKey("dbo.Adimg_art", "id_art_id_art", "dbo.AdArticulo");
            DropForeignKey("dbo.Adimg_art", "AdArticulo_id_art", "dbo.AdArticulo");
            DropIndex("dbo.StockAlma", new[] { "id_art_id_art" });
            DropIndex("dbo.StockAlma", new[] { "cod_almacen_cod_almacen" });
            DropIndex("dbo.AdPedidosreg", new[] { "id_art_id_art" });
            DropIndex("dbo.AdPedidosreg", new[] { "cod_almacen_cod_almacen" });
            DropIndex("dbo.AdPedidosreg", new[] { "id_doc_num" });
            DropIndex("dbo.AdCotizacionreg", new[] { "id_preciosart_id_preciosart" });
            DropIndex("dbo.AdCotizacionreg", new[] { "id_art_id_art" });
            DropIndex("dbo.AdCotizacionreg", new[] { "cod_almacen_cod_almacen" });
            DropIndex("dbo.Adpedidos", new[] { "idtransporte_idtransporte" });
            DropIndex("dbo.Adpedidos", new[] { "id_vendedor_id_vendedor" });
            DropIndex("dbo.Adpedidos", new[] { "id_condicion_id_condicion" });
            DropIndex("dbo.Adpedidos", new[] { "id_clientes_id_clientes" });
            DropIndex("dbo.Adcotizacion", new[] { "idtransporte_idtransporte" });
            DropIndex("dbo.Adcotizacion", new[] { "id_vendedor_id_vendedor" });
            DropIndex("dbo.Adcotizacion", new[] { "id_condicion_id_condicion" });
            DropIndex("dbo.Adcotizacion", new[] { "id_clientes_id_clientes" });
            DropIndex("dbo.Advendedor", new[] { "id_zona_id_zona" });
            DropIndex("dbo.Adclientes", new[] { "idingre_id" });
            DropIndex("dbo.Adclientes", new[] { "id_zona_id_zona" });
            DropIndex("dbo.Adclientes", new[] { "id_vendedor_id_vendedor" });
            DropIndex("dbo.Adclientes", new[] { "id_tipocliente_id_tipocliente" });
            DropIndex("dbo.Adclientes", new[] { "id_segmento_id_segmento" });
            DropIndex("dbo.AdSerial", new[] { "AdArticulo_id_art1" });
            DropIndex("dbo.AdSerial", new[] { "id_art_id_art" });
            DropIndex("dbo.AdSerial", new[] { "cod_almacen_cod_almacen" });
            DropIndex("dbo.AdSerial", new[] { "AdArticulo_id_art" });
            DropIndex("dbo.adpreciosart", new[] { "AdArticulo_id_art1" });
            DropIndex("dbo.adpreciosart", new[] { "id_art_id_art" });
            DropIndex("dbo.adpreciosart", new[] { "cod_almacen_cod_almacen" });
            DropIndex("dbo.adpreciosart", new[] { "AdArticulo_id_art" });
            DropIndex("dbo.Adimg_art", new[] { "AdArticulo_id_art1" });
            DropIndex("dbo.Adimg_art", new[] { "id_art_id_art" });
            DropIndex("dbo.Adimg_art", new[] { "AdArticulo_id_art" });
            DropTable("dbo.Adusuarios");
            DropTable("dbo.Tasa_IVA");
            DropTable("dbo.StockAlma");
            DropTable("dbo.sazona");
            DropTable("dbo.AdPedidosreg");
            DropTable("dbo.AdCotizacionreg");
            DropTable("dbo.Adpedidos");
            DropTable("dbo.Adpais");
            DropTable("dbo.Adtransporte");
            DropTable("dbo.Adcotizacion");
            DropTable("dbo.Adcondiciondepago");
            DropTable("dbo.AdIngreso");
            DropTable("dbo.Adzona");
            DropTable("dbo.Advendedor");
            DropTable("dbo.Adtipo_cliente");
            DropTable("dbo.AdSegmento");
            DropTable("dbo.Adclientes");
            DropTable("dbo.AdBanco");
            DropTable("dbo.AdSerial");
            DropTable("dbo.adpreciosart");
            DropTable("dbo.Adimg_art");
            DropTable("dbo.AdArticulo");
            DropTable("dbo.AdAlmacen");
        }
    }
}
