using FizzWare.NBuilder;
using PagonetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace PagonetCore.DAL
{
	public class PagonetInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PagonetContext>
	{
		protected override void Seed(PagonetContext context)
		{
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
					.With(a => a.id_zona = Pick<Adzona>.RandomItemFrom(zonas))
					.With(a => a.co_zon = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
				.Build();

			vendedores.ToList().ForEach(v => context.Vendedores.Add(v));
			context.SaveChanges();

			// Clientes.
			var clientes = Builder<Adclientes>.CreateListOfSize(5)
				.All()
					.With(a => a.co_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_tipocliente = Pick<Adtipo_cliente>.RandomItemFrom(tiposCliente))
					.With(a => a.tip_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cli_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.direc1 = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.dir_ent2 = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.telefonos = Faker.Phone.Number())
					.With(a => a.inactivo = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.respons = Faker.Name.FullName())
					.With(a => a.id_zona = Pick<Adzona>.RandomItemFrom(zonas))
					.With(a => a.co_zon = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_segmento = Pick<AdSegmento>.RandomItemFrom(segmentos))
					.With(a => a.co_seg = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_vendedor = Pick<Advendedor>.RandomItemFrom(vendedores))
					.With(a => a.co_ven = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.idingre = Pick<AdIngreso>.RandomItemFrom(ingresos))
					.With(a => a.co_cta_ingr_egr = Faker.RandomNumber.Next(9999).ToString("0000"))
					.With(a => a.rif = Faker.RandomNumber.Next(99999).ToString("00000"))
					.With(a => a.email = Faker.Internet.Email())
					.With(a => a.juridico = "1")
					.With(a => a.ciudad = String.Join(" ", Faker.Lorem.Words(1)))
					.With(a => a.zip = Faker.RandomNumber.Next(9999).ToString("0000"))
					.With(a => a.id_pais = Faker.RandomNumber.Next(999))
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
					.With(a => a.id_clientes = Pick<Adclientes>.RandomItemFrom(clientes))
					.With(a => a.co_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.idtransporte = Pick<Adtransporte>.RandomItemFrom(transportes))
					.With(a => a.co_tran = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.co_mone = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_vendedor = Pick<Advendedor>.RandomItemFrom(vendedores))
					.With(a => a.co_ven = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_condicion = Pick<Adcondiciondepago>.RandomItemFrom(condicionesDePago))
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
					.With(a => a.cod_almacen = Pick<AdAlmacen>.RandomItemFrom(almacenes))
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
					.With(a => a.id_art = Pick<AdArticulo>.RandomItemFrom(articulos))
					.With(a => a.art_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.co_alma = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cod_almacen = Pick<AdAlmacen>.RandomItemFrom(almacenes))
					.With(a => a.total_art = Faker.RandomNumber.Next(400))
					.With(a => a.stotal_art = Faker.RandomNumber.Next(400))
					.With(a => a.cod_unidad = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_preciosart = Pick<adpreciosart>.RandomItemFrom(preciosArticulo))
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
					.With(a => a.id_art = Pick<AdArticulo>.RandomItemFrom(articulos))
					.With(a => a.co_art = Faker.RandomNumber.Next(99999).ToString("00000"))
					.With(a => a.tip = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.imagen_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.picture = String.Join(" ", Faker.Lorem.Words(5)))
					.With(a => a.importado_pro = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.importado_web = Faker.RandomNumber.Next(1).ToString())
					.With(a => a.AdArticulo = Pick<AdArticulo>.RandomItemFrom(articulos))
				.Build();

			imagenesArticulo.ToList().ForEach(i => context.ImagenesArticulo.Add(i));
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

			// Pedidos.
			var pedidos = Builder<Adpedidos>.CreateListOfSize(5)
				.All()
					.With(a => a.doc_num = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.descrip = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.id_clientes = Pick<Adclientes>.RandomItemFrom(clientes))
					.With(a => a.co_cli = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.idtransporte = Pick<Adtransporte>.RandomItemFrom(transportes))
					.With(a => a.co_tran = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.co_mone = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_vendedor = Pick<Advendedor>.RandomItemFrom(vendedores))
					.With(a => a.co_ven = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_condicion = Pick<Adcondiciondepago>.RandomItemFrom(condicionesDePago))
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
					.With(a => a.id_doc_num = Faker.RandomNumber.Next(999))
					.With(a => a.doc_num = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.reng_num = Pick<Adpedidos>.RandomItemFrom(pedidos))
					.With(a => a.id_art = Pick<AdArticulo>.RandomItemFrom(articulos))
					.With(a => a.co_art = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.art_des = String.Join(" ", Faker.Lorem.Words(3)))
					.With(a => a.cod_almacen = Pick<AdAlmacen>.RandomItemFrom(almacenes))
					.With(a => a.co_alma = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.total_art = Faker.RandomNumber.Next(400))
					.With(a => a.stotal_art = Faker.RandomNumber.Next(400))
					.With(a => a.cod_unidad = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.id_preciosart = Faker.RandomNumber.Next(999))
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

			// Serial.
			var serial = Builder<AdSerial>.CreateListOfSize(5)
				.All()
					.With(a => a.reng_num = Faker.RandomNumber.Next(9999))
					.With(a => a.id_art = Pick<AdArticulo>.RandomItemFrom(articulos))
					.With(a => a.co_art = Faker.RandomNumber.Next(999).ToString("000"))
					.With(a => a.cod_almacen = Pick<AdAlmacen>.RandomItemFrom(almacenes))
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
					.With(a => a.id = Faker.RandomNumber.Next(99999))
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
					.With(a => a.cod_almacen = Pick<AdAlmacen>.RandomItemFrom(almacenes))
					.With(a => a.co_alma = new char())
					.With(a => a.id_art = Pick<AdArticulo>.RandomItemFrom(articulos))
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