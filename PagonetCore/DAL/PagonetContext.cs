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
		// Se deja comentado para que no cree la Tabla en la BD. Esto solo se utilizará como 
		// modelo intermedio para crear Cotizaciones con Renglones en una misma llamada a la API.
		//public DbSet<PagonetCore.Models.CotizacionRenglon> CotizacionRenglon { get; set; }

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
		}
    }
}