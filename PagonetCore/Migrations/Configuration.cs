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

			ProfitEntities profitContext = new ProfitEntities();

			// Almacenes.
			var almacenes = profitContext.saAlmacen.Select(a => new
			{
				a.co_alma,
				a.des_alma
			}).ToList();

			almacenes.ForEach(a => context.Almacenes.Add(new AdAlmacen
			{
				co_alma = a.co_alma,
				des_alamacen = a.des_alma,
				web = null,
				co_user_prof = null,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Artículos.
			var articulos = profitContext.saArticulo.Select(a => new
			{
				a.co_art,
				a.art_des,
				a.co_lin,
				a.co_subl,
				a.co_cat,
				a.co_color,
				a.co_ubicacion,
				a.cod_proc,
				a.@ref,
				a.tipo_imp,
				a.tipo_imp2,
				a.tipo_imp3
			}).ToList();

			articulos.ForEach(a => context.Articulos.Add(new AdArticulo
			{
				co_art = a.co_art,
				art_des = a.art_des,
				co_lin = a.co_lin,
				co_subl = a.co_subl,
				co_cat = a.co_cat,
				co_color = a.co_color,
				co_ubicacion = a.co_ubicacion,
				cod_proc = a.cod_proc,
				cod_unidad = "1",
				referencia = a.@ref,
				tipo_imp = a.tipo_imp,
				tipo_imp2 = a.tipo_imp2,
				tipo_imp3 = a.tipo_imp3,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Bancos.
			var bancos = profitContext.saBanco.Select(b => new
			{
				b.co_ban,
				b.des_ban
			}).ToList();

			bancos.ForEach(b => context.Bancos.Add(new AdBanco
			{
				co_ban = b.co_ban,
				des_ban = b.des_ban,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Tipo de Cliente.
			var tiposCliente = profitContext.saTipoCliente.Select(t => new
			{
				t.tip_cli,
				t.des_tipo
			}).ToList();

			tiposCliente.ForEach(t => context.TiposCliente.Add(new Adtipo_cliente
			{
				tip_cli = t.tip_cli,
				des_tipo = t.des_tipo,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Segmentos.
			var segmentos = profitContext.saSegmento.Select(s => new
			{
				s.co_seg,
				s.seg_des
			}).ToList();

			segmentos.ForEach(s => context.Segmentos.Add(new AdSegmento
			{
				co_seg = s.co_seg,
				seg_des = s.seg_des,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Zonas.
			var zonas = profitContext.saZona.Select(z => new
			{
				z.co_zon,
				z.zon_des
			}).ToList();

			zonas.ForEach(z => context.Zonas.Add(new Adzona
			{
				co_zon = z.co_zon,
				zon_des = z.zon_des,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Ingresos.
			var ingresos = profitContext.saCuentaIngEgr.Select(i => new
			{
				i.co_cta_ingr_egr,
				i.descrip
			}).ToList();

			ingresos.ForEach(i => context.Ingresos.Add(new AdIngreso
			{
				co_ctaIng_egr = i.co_cta_ingr_egr,
				descrip_ingre = i.descrip,
				co_user_prof = null,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Vendedores.
			var vendedores = profitContext.saVendedor.Select(v => new
			{
				v.co_ven,
				v.tipo,
				v.ven_des,
				v.co_zon,
				v.saZona
			}).ToList();

			vendedores.ForEach(v => context.Vendedores.Add(new Advendedor
			{
				co_ven = v.co_ven,
				tipo = v.tipo,
				ven_des = v.ven_des,
				id_zona = context.Zonas.Where(z => z.co_zon.Equals(v.co_zon)).Select(z => z.id_zona).First(),
				co_zon = v.co_zon,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Países.
			var paises = profitContext.saPais.Select(p => new
			{
				p.co_pais,
				p.pais_des
			}).ToList();

			paises.ForEach(p => context.Paises.Add(new Adpais
			{
				co_pais = p.co_pais,
				pais_des = p.pais_des,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Condiciones de Pago.
			var condicionesDePago = profitContext.saCondicionPago.Select(c => new
			{
				c.co_cond,
				c.cond_des,
				c.dias_cred
			}).ToList();

			condicionesDePago.ForEach(c => context.CondicionesDePago.Add(new Adcondiciondepago
			{
				co_cond = c.co_cond,
				cond_des = c.cond_des,
				dias_cred = c.dias_cred,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Transporte.
			var transportes = profitContext.saTransporte.Select(t => new
			{
				t.co_tran,
				t.des_tran
			}).ToList();

			transportes.ForEach(t => context.Transportes.Add(new Adtransporte
			{
				co_tran = t.co_tran,
				des_tran = t.des_tran,
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Precios Artículo.
			var preciosArticulo = profitContext.saArtPrecio.Select(p => new
			{
				p.co_art,
				p.co_precio,
				p.desde,
				p.hasta,
				p.saAlmacen,
				p.co_alma,
				p.monto,
				p.montoadi1,
				p.montoadi2,
				p.montoadi3,
				p.montoadi4,
				p.montoadi5,
				p.precioOm
			}).ToList();

			preciosArticulo.ForEach(p => context.PreciosArticulo.Add(new adpreciosart
			{
				co_art = p.co_art,
				co_precios = p.co_precio,
				desde = p.desde,
				hasta = p.hasta,
				cod_almacen = context.Almacenes.Where(a => a.co_alma.Equals(p.co_alma)).Select(a => a.cod_almacen).First(),
				co_alma = p.co_alma,
				monto = p.monto,
				montoadi1 = p.montoadi1,
				montoadi2 = p.montoadi2,
				montoadi3 = p.montoadi3,
				montoadi4 = p.montoadi4,
				montoadi5 = p.montoadi5,
				precioOm = profitContext.saArtPrecio.Where(pa => pa.co_art.Equals(p.co_art)).Select(pa => pa.precioOm).First() == true ? "1" : "0",
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();

			// Imágenes Artículo.
			var imagenesArticulo = profitContext.saArtImagen.Select(i => new
			{
				i.co_art,
				i.tip,
				i.imagen_des,
				i.picture,
				i.saArticulo
			}).ToList();

			imagenesArticulo.ForEach(i => context.ImagenesArticulo.Add(new Adimg_art
			{
				id_art = context.Articulos.Where(a => a.co_art.Equals(i.co_art)).Select(a => a.id_art).First(),
				co_art = i.co_art,
				tip = i.tip,
				imagen_des = i.imagen_des,
				picture = Encoding.UTF8.GetString(i.picture),
				importado_pro = "1",
				importado_web = "1"
			}));

			context.SaveChanges();
		}
    }
}
