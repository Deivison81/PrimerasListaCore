using PagonetCore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

// https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
// https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
// https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
// https://www.jerriepelser.com/blog/creating-test-data-with-nbuilder-and-faker/
// https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting
// https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings

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
		// TODO: Refactorizar Sazonas para coincidir con convenciones de 
		// nombres de C#.
		public DbSet<PagonetCore.Models.sazona> Sazonas { get; set; }
		public DbSet<PagonetCore.Models.StockAlma> StockAlmacenes { get; set; }
		public DbSet<PagonetCore.Models.Tasa_IVA> TasasIVA { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}