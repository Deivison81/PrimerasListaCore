namespace PagonetCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FizzWare.NBuilder;
    using PagonetCore.Models;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<PagonetCore.DAL.PagonetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PagonetCore.DAL.PagonetContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			// Almacenes.
			var almacenes = Builder<AdAlmacen>.CreateListOfSize(5)
				.All()
					.With(a => a.co_alma = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.des_alamacen = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.web = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.co_user_prof = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			almacenes.ToList().ForEach(a => context.Almacenes.Add(a));
			context.SaveChanges();

			// Artículos.
			var articulos = Builder<AdArticulo>.CreateListOfSize(5)
				.All()
					.With(a => a.co_art = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.art_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.co_lin = Faker.RandomNumber.Next(99).ToString("00"))
					.With(a => a.co_subl = Faker.RandomNumber.Next(99).ToString("00"))
					.With(a => a.co_cat = Faker.RandomNumber.Next(99).ToString("00"))
					.With(a => a.co_color = Faker.RandomNumber.Next(99).ToString("00"))
					.With(a => a.co_ubicacion = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cod_proc = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cod_unidad = "UNI")
					.With(a => a.referencia = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.tipo_imp = "1")
					.With(a => a.tipo_imp2 = null)
					.With(a => a.tipo_imp3 = null)
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			articulos.ToList().ForEach(a => context.Articulos.Add(a));
			context.SaveChanges();

			// Bancos.
			var bancos = Builder<AdBanco>.CreateListOfSize(5)
				.All()
					.With(a => a.co_ban = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.des_ban = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			bancos.ToList().ForEach(b => context.Bancos.Add(b));
			context.SaveChanges();

			// Tipo de Cliente.
			var tiposCliente = Builder<Adtipo_cliente>.CreateListOfSize(5)
				.All()
					.With(a => a.tip_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.des_tipo = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			tiposCliente.ToList().ForEach(t => context.TiposCliente.Add(t));
			context.SaveChanges();

			// Segmentos.
			var segmentos = Builder<AdSegmento>.CreateListOfSize(5)
				.All()
					.With(a => a.co_seg = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.seg_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			segmentos.ToList().ForEach(s => context.Segmentos.Add(s));
			context.SaveChanges();

			// Zonas.
			var zonas = Builder<Adzona>.CreateListOfSize(5)
				.All()
					.With(a => a.co_zon = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.zon_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			zonas.ToList().ForEach(z => context.Zonas.Add(z));
			context.SaveChanges();

			// Ingresos.
			var ingresos = Builder<AdIngreso>.CreateListOfSize(5)
				.All()
					.With(a => a.co_ctaIng_egr = Faker.RandomNumber.Next(9999).ToString("0000"))
					.With(a => a.descrip_ingre = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.co_user_prof = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			ingresos.ToList().ForEach(i => context.Ingresos.Add(i));
			context.SaveChanges();

			// Vendedores.
			var vendedores = Builder<Advendedor>.CreateListOfSize(5)
				.All()
					.With(a => a.co_ven = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.tipo = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.ven_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.id_zona = zonas.Single(s => s.id_zona == 1).id_zona)
					.With(a => a.co_zon = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			vendedores.ToList().ForEach(v => context.Vendedores.Add(v));
			context.SaveChanges();

			// Países.
			var paises = Builder<Adpais>.CreateListOfSize(5)
				.All()
					.With(a => a.co_pais = Faker.RandomNumber.Next(9999).ToString("0000"))
					.With(a => a.pais_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			paises.ToList().ForEach(p => context.Paises.Add(p));
			context.SaveChanges();

			// Clientes.
			var clientes = Builder<Adclientes>.CreateListOfSize(5)
				.All()
					.With(a => a.co_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_tipocliente = tiposCliente.Single(s => s.id_tipocliente == 1).id_tipocliente)
					.With(a => a.tip_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cli_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.direc1 = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.dir_ent2 = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.telefonos = "0416-4561230")
					.With(a => a.inactivo = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.respons = Faker.Name.FullName())
					.With(a => a.id_zona = zonas.Single(s => s.id_zona == 1).id_zona)
					.With(a => a.co_zon = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_segmento = segmentos.Single(s => s.id_segmento == 1).id_segmento)
					.With(a => a.co_seg = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_vendedor = vendedores.Single(s => s.id_vendedor == 1).id_vendedor)
					.With(a => a.co_ven = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.idingre = ingresos.Single(s => s.id == 1).id)
					.With(a => a.co_cta_ingr_egr = Faker.RandomNumber.Next(9999).ToString("0000"))
					.With(a => a.rif = "J-123456789-0")
					.With(a => a.email = Faker.Internet.Email())
					.With(a => a.juridico = "1")
					.With(a => a.ciudad = String.Join(" ", Faker.Lorem.Words(1)))
					.With(a => a.zip = Faker.RandomNumber.Next(9999).ToString("0000"))
					.With(a => a.id_pais = paises.Single(s => s.id_pais == 1).id_pais)
					.With(a => a.co_pais = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cod_comercio = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			clientes.ToList().ForEach(c => context.Clientes.Add(c));
			context.SaveChanges();

			// Condiciones de Pago.
			var condicionesDePago = Builder<Adcondiciondepago>.CreateListOfSize(5)
				.All()
					.With(a => a.co_cond = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cond_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.dias_cred = Faker.RandomNumber.Next(999))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			condicionesDePago.ToList().ForEach(c => context.CondicionesDePago.Add(c));
			context.SaveChanges();

			// Transporte.
			var transportes = Builder<Adtransporte>.CreateListOfSize(5)
				.All()
					.With(a => a.co_tran = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.des_tran = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			transportes.ToList().ForEach(t => context.Transportes.Add(t));
			context.SaveChanges();

			// Cotizaciones.
			var cotizaciones = Builder<Adcotizacion>.CreateListOfSize(5)
				.All()
					.With(a => a.doc_num = Faker.RandomNumber.Next(999))
					.With(a => a.descrip = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.id_clientes = clientes.Single(s => s.id_clientes == 1).id_clientes)
					.With(a => a.co_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.idtransporte = transportes.Single(s => s.idtransporte == 1).idtransporte)
					.With(a => a.co_tran = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.co_mone = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_vendedor = vendedores.Single(s => s.id_vendedor == 1).id_vendedor)
					.With(a => a.co_ven = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_condicion = condicionesDePago.Single(s => s.id_condicion == 1).id_condicion)
					.With(a => a.co_cond = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.fec_emis = DateTime.Now)
					.With(a => a.fec_venc = DateTime.Now)
					.With(a => a.fec_reg = DateTime.Now)
					.With(a => a.anulado = "0")
					.With(a => a.status = "1")
					.With(a => a.total_bruto = Faker.RandomNumber.Next(400))
					.With(a => a.monto_imp = Faker.RandomNumber.Next(40))
					.With(a => a.monto_imp2 = null)
					.With(a => a.monto_imp3 = null)
					.With(a => a.total_neto = Faker.RandomNumber.Next(400))
					.With(a => a.saldo = Faker.RandomNumber.Next(400))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.Diasvencimiento = Faker.RandomNumber.Next(7))
					.With(a => a.nro_pedido = Faker.RandomNumber.Next(999))
					.With(a => a.vencida = "0")
				.Build();

			cotizaciones.ToList().ForEach(c => context.Cotizaciones.Add(c));
			context.SaveChanges();

			// Precios Artículo.
			var preciosArticulo = Builder<adpreciosart>.CreateListOfSize(5)
				.All()
					.With(a => a.co_art = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.co_precios = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.desde = DateTime.Now)
					.With(a => a.hasta = DateTime.Now)
					.With(a => a.cod_almacen = almacenes.Single(s => s.cod_almacen == 1).cod_almacen)
					.With(a => a.co_alma = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.monto = Faker.RandomNumber.Next(400))
					.With(a => a.montoadi1 = Faker.RandomNumber.Next(400))
					.With(a => a.montoadi2 = Faker.RandomNumber.Next(300))
					.With(a => a.montoadi3 = Faker.RandomNumber.Next(400))
					.With(a => a.montoadi4 = Faker.RandomNumber.Next(100))
					.With(a => a.montoadi5 = Faker.RandomNumber.Next(40))
					.With(a => a.precioOm = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			preciosArticulo.ToList().ForEach(p => context.PreciosArticulo.Add(p));
			context.SaveChanges();

			// Renglones de Cotización.
			var renglonesCotizacion = Builder<AdCotizacionreg>.CreateListOfSize(5)
				.All()
					.With(a => a.doc_num = Faker.RandomNumber.Next(999))
					.With(a => a.reng_num = Faker.RandomNumber.Next(999))
					.With(a => a.id_art = articulos.Single(s => s.id_art == 1).id_art)
					.With(a => a.art_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.co_alma = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cod_almacen = almacenes.Single(s => s.cod_almacen == 1).cod_almacen)
					.With(a => a.total_art = Faker.RandomNumber.Next(400))
					.With(a => a.stotal_art = Faker.RandomNumber.Next(400))
					.With(a => a.cod_unidad = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_preciosart = preciosArticulo.Single(s => s.id_preciosart == 1).id_preciosart)
					.With(a => a.co_precios = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.prec_vta = Faker.RandomNumber.Next(400))
					.With(a => a.prec_vta_om = Faker.RandomNumber.Next(400))
					.With(a => a.tipo_imp = "1")
					.With(a => a.tipo_imp2 = null)
					.With(a => a.tipo_imp3 = null)
					.With(a => a.porc_imp = Faker.RandomNumber.Next(20))
					.With(a => a.porc_imp2 = null)
					.With(a => a.porc_imp3 = null)
					.With(a => a.monto_imp = Faker.RandomNumber.Next(100))
					.With(a => a.monto_imp2 = null)
					.With(a => a.monto_imp3 = null)
					.With(a => a.reng_neto = Faker.RandomNumber.Next(400))
					.With(a => a.tipo_doc = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.num_doc = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			renglonesCotizacion.ToList().ForEach(r => context.RenglonesCotizacion.Add(r));
			context.SaveChanges();

			// Imágenes Artículo.
			var imagenesArticulo = Builder<Adimg_art>.CreateListOfSize(5)
				.All()
					.With(a => a.id_art = articulos.Single(s => s.id_art == 1).id_art)
					.With(a => a.co_art = Faker.RandomNumber.Next(99999).ToString("00000"))
					.With(a => a.tip = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.imagen_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.picture = String.Join(" ", Faker.Lorem.Words(5)))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.Articulo = Pick<AdArticulo>.RandomItemFrom(articulos))
				.Build();

			imagenesArticulo.ToList().ForEach(i => context.ImagenesArticulo.Add(i));
			context.SaveChanges();

			// Pedidos.
			var pedidos = Builder<Adpedidos>.CreateListOfSize(5)
				.All()
					.With(a => a.doc_num = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.descrip = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.id_clientes = clientes.Single(s => s.id_clientes == 1).id_clientes)
					.With(a => a.co_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.idtransporte = transportes.Single(s => s.idtransporte == 1).idtransporte)
					.With(a => a.co_tran = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.co_mone = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_vendedor = vendedores.Single(s => s.id_vendedor == 1).id_vendedor)
					.With(a => a.co_ven = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_condicion = condicionesDePago.Single(s => s.id_condicion == 1).id_condicion)
					.With(a => a.co_cond = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.fec_emis = DateTime.Now)
					.With(a => a.fec_venc = DateTime.Now)
					.With(a => a.fec_reg = DateTime.Now)
					.With(a => a.anulado = "0")
					.With(a => a.status = "1")
					.With(a => a.monto_imp = Faker.RandomNumber.Next(100))
					.With(a => a.monto_imp2 = null)
					.With(a => a.monto_imp3 = null)
					.With(a => a.total_neto = Faker.RandomNumber.Next(400))
					.With(a => a.saldo = Faker.RandomNumber.Next(400))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.Diasvencimiento = Faker.RandomNumber.Next(7))
					.With(a => a.nro_pedido = "1")
					.With(a => a.vencida = "0")
				.Build();

			pedidos.ToList().ForEach(p => context.Pedidos.Add(p));
			context.SaveChanges();

			// Renglones de Pedidos.
			var renglonesPedidos = Builder<AdPedidosreg>.CreateListOfSize(5)
				.All()
					.With(a => a.id_doc_num = pedidos.Single(s => s.id_doc_num == 1).id_doc_num)
					.With(a => a.doc_num = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.reng_num = pedidos.Single(s => s.id_doc_num == 1).id_doc_num)
					.With(a => a.id_art = articulos.Single(s => s.id_art == 1).id_art)
					.With(a => a.co_art = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.art_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.cod_almacen = almacenes.Single(s => s.cod_almacen == 1).cod_almacen)
					.With(a => a.co_alma = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.total_art = Faker.RandomNumber.Next(400))
					.With(a => a.stotal_art = Faker.RandomNumber.Next(400))
					.With(a => a.cod_unidad = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_preciosart = preciosArticulo.Single(s => s.id_preciosart == 1).id_preciosart)
					.With(a => a.co_precios = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.prec_vta = Faker.RandomNumber.Next(400))
					.With(a => a.prec_vta_om = Faker.RandomNumber.Next(400))
					.With(a => a.tipo_imp = "1")
					.With(a => a.tipo_imp2 = null)
					.With(a => a.tipo_imp3 = null)
					.With(a => a.porc_imp = Faker.RandomNumber.Next(20))
					.With(a => a.porc_imp2 = null)
					.With(a => a.porc_imp3 = null)
					.With(a => a.monto_imp = Faker.RandomNumber.Next(100))
					.With(a => a.monto_imp2 = null)
					.With(a => a.monto_imp3 = null)
					.With(a => a.reng_neto = Faker.RandomNumber.Next(400))
					.With(a => a.tipo_doc = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.num_doc = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			renglonesPedidos.ToList().ForEach(r => context.RenglonesPedidos.Add(r));
			context.SaveChanges();

			// Seriales.
			var serial = Builder<AdSerial>.CreateListOfSize(5)
				.All()
					.With(a => a.id_art = articulos.Single(s => s.id_art == 1).id_art)
					.With(a => a.co_art = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cod_almacen = almacenes.Single(s => s.cod_almacen == 1).cod_almacen)
					.With(a => a.co_alma = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.serial = Faker.RandomNumber.Next(99999).ToString("00000"))
					.With(a => a.tip_dispositivo = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			serial.ToList().ForEach(s => context.Seriales.Add(s));
			context.SaveChanges();

			// Usuarios.
			var usuarios = Builder<Adusuarios>.CreateListOfSize(5)
				.All()
					.With(a => a.co_user_prof = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cod_user = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.nombre_usuarios = Faker.Internet.UserName())
					.With(a => a.password = Encoding.ASCII.GetBytes(Faker.RandomNumber.Next(999).ToString("000")))
					.With(a => a.Estado = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.fecha_ingreso = DateTime.Now)
					.With(a => a.validacion = Faker.RandomNumber.Next(999).ToString("000"))
				.Build();

			usuarios.ToList().ForEach(u => context.Usuarios.Add(u));
			context.SaveChanges();

			// Stock Almacenes.
			var stockAlmacenes = Builder<StockAlma>.CreateListOfSize(5)
				.All()
					.With(a => a.cod_almacen = almacenes.Single(s => s.cod_almacen == 1).cod_almacen)
					.With(a => a.co_alma = new char())
					.With(a => a.id_art = articulos.Single(s => s.id_art == 1).id_art)
					.With(a => a.co_art = new char())
					.With(a => a.tipo = new char())
					.With(a => a.stock = Faker.RandomNumber.Next(999))
					.With(a => a.importado_pro = new char())
					.With(a => a.importado_web = new char())
				.Build();

			stockAlmacenes.ToList().ForEach(s => context.StockAlmacenes.Add(s));
			context.SaveChanges();

			// Tasas IVA.
			var tasasIVA = Builder<Tasa_IVA>.CreateListOfSize(5)
				.All()
					.With(a => a.id_impuesto = Faker.RandomNumber.Next(999))
					.With(a => a.fechapubli = DateTime.Now)
					.With(a => a.nro_reng = Faker.RandomNumber.Next(999))
					.With(a => a.tip_impu = Faker.RandomNumber.Next(999))
					.With(a => a.ventas = "1")
					.With(a => a.consumosuntuario = "1")
					.With(a => a.porcentajetaza = Faker.RandomNumber.Next(999))
					.With(a => a.porcentajesuntuario = Faker.RandomNumber.Next(999))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			tasasIVA.ToList().ForEach(t => context.TasasIVA.Add(t));
			context.SaveChanges();
		}
    }
}
