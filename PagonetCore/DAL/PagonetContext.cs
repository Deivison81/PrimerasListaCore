using PagonetCore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

// Para regenerar la BD (BORRA TODOS LOS DATOS ACTUALES DE LA BD):
// Herramientas - Administrador de Paquetes NuGet - Consola.
// enable-migrations -Force
// add-migration InitialCreate -Force
// update-database

namespace PagonetCore.DAL
{
	public class PagonetContext : DbContext
	{
        internal object Cajas;

        public PagonetContext() : base("PagonetContext")
		{
		}

		public DbSet<PagonetCore.Models.AdAlmacen> Almacenes { get; set; }
		public DbSet<PagonetCore.Models.AdArticulo> Articulos { get; set; }
		public DbSet<PagonetCore.Models.AdBanco> Bancos { get; set; }
		public DbSet<PagonetCore.Models.Adclientes> Clientes { get; set; }
		public DbSet<PagonetCore.Models.Adcondiciondepago> CondicionesDePago { get; set; }
		public DbSet<PagonetCore.Models.Adcotizacion> Cotizaciones { get; set; }
		public DbSet<PagonetCore.Models.AdCotizacionreg> RenglonesCotizacion { get; set; }
		public DbSet<PagonetCore.Models.Adimg_art> ImagenesArticulo { get; set; }
		public DbSet<PagonetCore.Models.AdIngreso> Ingresos { get; set; }
		public DbSet<PagonetCore.Models.Adpais> Paises { get; set; }
		public DbSet<PagonetCore.Models.Adpedidos> Pedidos { get; set; }
		public DbSet<PagonetCore.Models.AdPedidosreg> RenglonesPedidos { get; set; }
		public DbSet<PagonetCore.Models.adpreciosart> PreciosArticulo { get; set; }
		public DbSet<PagonetCore.Models.AdSegmento> Segmentos { get; set; }
		public DbSet<PagonetCore.Models.AdSerial> Seriales { get; set; }
		public DbSet<PagonetCore.Models.Adtipo_cliente> TiposCliente { get; set; }
		public DbSet<PagonetCore.Models.Adtransporte> Transportes { get; set; }
		public DbSet<PagonetCore.Models.Adusuarios> Usuarios { get; set; }
		public DbSet<PagonetCore.Models.Advendedor> Vendedores { get; set; }
		public DbSet<PagonetCore.Models.Adzona> Zonas { get; set; }
		public DbSet<PagonetCore.Models.StockAlma> StockAlmacenes { get; set; }
		public DbSet<PagonetCore.Models.Tasa_IVA> TasasIVA { get; set; }
		public virtual DbSet<AdCobros> Cobros { get; set; }
		public virtual DbSet<AdRenglonesCobro> RenglonesCobro { get; set; }
		public virtual DbSet<AdMoneda> Monedas { get; set; }
		public virtual DbSet<AdFormasCobro> FormasCobro { get; set; }
		public virtual DbSet<AdTasa> Tasas { get; set; }
		public virtual DbSet<AdMovimientoBanco> MovimientosBancos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			// Claves Foráneas para Clientes.
			modelBuilder.Entity<Adclientes>().HasRequired(c => c.TipoCliente).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adclientes>().HasRequired(c => c.Vendedor).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adclientes>().HasRequired(c => c.Ingreso).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adclientes>().HasRequired(c => c.Zona).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adclientes>().HasRequired(c => c.Segmento).WithMany().WillCascadeOnDelete(false);

			// Claves Foráneas para Cotizaciones.
			modelBuilder.Entity<Adcotizacion>().HasRequired(c => c.Cliente).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adcotizacion>().HasRequired(c => c.Transporte).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adcotizacion>().HasRequired(c => c.Vendedor).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Adcotizacion>().HasRequired(c => c.CondicionDePago);
            modelBuilder.Entity<Adcotizacion>().HasMany(c => c.RenglonesCotizacion);

            // Claves Foráneas para Renglones de Cotización.
            modelBuilder.Entity<AdCotizacionreg>().HasRequired(c => c.Articulo).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<AdCotizacionreg>().HasRequired(c => c.Almacen).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<AdCotizacionreg>().HasRequired(c => c.PrecioArticulo).WithMany().WillCascadeOnDelete(false);

			// Claves Foráneas para Pedidos.
			modelBuilder.Entity<Adpedidos>().HasRequired(c => c.Cliente).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adpedidos>().HasRequired(c => c.Transporte).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adpedidos>().HasRequired(c => c.Vendedor).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<Adpedidos>().HasRequired(c => c.CondicionDePago).WithMany().WillCascadeOnDelete(false);

			// Claves Foráneas para Renglones de Pedido.
			modelBuilder.Entity<AdPedidosreg>().HasRequired(c => c.Pedido).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<AdPedidosreg>().HasRequired(c => c.Articulo).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<AdPedidosreg>().HasRequired(c => c.Almacen).WithMany().WillCascadeOnDelete(false);

			// Claves Foráneas para Precios de Artículo.
			modelBuilder.Entity<adpreciosart>().HasRequired(c => c.Articulo).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<adpreciosart>().HasRequired(c => c.Almacen).WithMany().WillCascadeOnDelete(false);

			// Claves Foráneas para Seriales.
			modelBuilder.Entity<AdSerial>().HasRequired(c => c.Articulo).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<AdSerial>().HasRequired(c => c.Almacen).WithMany().WillCascadeOnDelete(false);

			// Claves Foráneas para Vendedores.
			modelBuilder.Entity<Advendedor>().HasRequired(c => c.Zona).WithMany().WillCascadeOnDelete(false);

			// Claves Foráneas para Stock Almacenes.
			modelBuilder.Entity<StockAlma>().HasRequired(c => c.Almacen).WithMany().WillCascadeOnDelete(false);
			modelBuilder.Entity<StockAlma>().HasRequired(c => c.Articulo).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<AdCobros>()
                .Property(e => e.cob_num_pro)
                .IsFixedLength();

            modelBuilder.Entity<AdCobros>()
                .Property(e => e.co_cli)
                .IsFixedLength();

            modelBuilder.Entity<AdCobros>()
                .Property(e => e.co_mone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdCobros>()
                .Property(e => e.co_ven)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdCobros>()
                .Property(e => e.tasa)
                .HasPrecision(21, 8);

            modelBuilder.Entity<AdCobros>()
                .Property(e => e.anulado)
                .IsFixedLength();

            modelBuilder.Entity<AdCobros>()
                .Property(e => e.importado_web)
                .IsFixedLength();

            modelBuilder.Entity<AdCobros>()
                .Property(e => e.importado_pro)
                .IsFixedLength();

            modelBuilder.Entity<AdCobros>()
                .HasMany(e => e.RenglonesCobro);

            modelBuilder.Entity<AdCobros>()
                .HasMany(e => e.FormasCobro);

            modelBuilder.Entity<AdRenglonesCobro>()
                .Property(e => e.cob_num_pro)
                .IsFixedLength();

            modelBuilder.Entity<AdRenglonesCobro>()
                .Property(e => e.co_tipo_doc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdRenglonesCobro>()
                .Property(e => e.nro_doc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdRenglonesCobro>()
                .Property(e => e.tipo_doc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdRenglonesCobro>()
                .Property(e => e.num_doc)
                .IsUnicode(false);

            modelBuilder.Entity<AdRenglonesCobro>()
                .Property(e => e.importado_web)
                .IsFixedLength();

            modelBuilder.Entity<AdRenglonesCobro>()
                .Property(e => e.importado_pro)
                .IsFixedLength();

            modelBuilder.Entity<AdMoneda>()
                .Property(e => e.co_mone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMoneda>()
                .Property(e => e.mone_des)
                .IsUnicode(false);

            modelBuilder.Entity<AdMoneda>()
                .Property(e => e.importado_web)
                .IsFixedLength();

            modelBuilder.Entity<AdMoneda>()
                .Property(e => e.importado_pro)
                .IsFixedLength();

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.cob_num_pro)
                .IsFixedLength();

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.co_ban)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.forma_pag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.cod_cta)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.cod_caja)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.mov_num_c)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.mov_num_b)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.dolar)
                .IsFixedLength();

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.importado_web)
                .IsFixedLength();

            modelBuilder.Entity<AdFormasCobro>()
                .Property(e => e.importado_pro)
                .IsFixedLength();

            modelBuilder.Entity<AdTasa>()
                .Property(e => e.co_mone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdTasa>()
                .Property(e => e.tasa_c)
                .HasPrecision(21, 8);

            modelBuilder.Entity<AdTasa>()
                .Property(e => e.tasa_v)
                .HasPrecision(21, 8);

            modelBuilder.Entity<AdTasa>()
                .Property(e => e.importado_web)
                .IsFixedLength();

            modelBuilder.Entity<AdTasa>()
                .Property(e => e.importado_pro)
                .IsFixedLength();

            modelBuilder.Entity<AdMovimientoBanco>()
                    .Property(e => e.mov_num)
                    .IsFixedLength()
                    .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.descrip)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.cod_cta)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.co_cta_ingr_egr)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.tasa)
                .HasPrecision(18, 5);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.tipo_op)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.doc_num)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.origen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.cob_pag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.dep_num)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.cod_ingben)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.campo1)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.campo2)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.campo3)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.campo4)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.campo5)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.campo6)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.campo7)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.campo8)
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.co_us_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.co_sucu_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.co_us_mo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.co_sucu_mo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.trasnfe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.revisado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.importado_web)
                .IsFixedLength();

            modelBuilder.Entity<AdMovimientoBanco>()
                .Property(e => e.importado_pro)
                .IsFixedLength();
        }

        public System.Data.Entity.DbSet<PagonetCore.Models.AdCajas> AdCajas { get; set; }
    }
}