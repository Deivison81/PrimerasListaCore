using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PagonetCore.DAL;
using PagonetCore.Models;

namespace PagonetCore.Controllers
{
    public class APIClienteController : ApiController
    {
        private PagonetContext db = new PagonetContext();

        // GET: api/APICliente
        [Route("Cliente/listaCliente")]
        public IQueryable<Adclientes> GetClientes()
        {
            return db.Clientes;
        }

        
        [HttpGet]
        [Route("cotizacion/listarCliente")]
        public object GetClientesListarCliente()
        {
            return db.Clientes.Select(p => new
            {
                IID = p.id_clientes,
                CODIGO = p.co_cli,
                NOMBRE = p.cli_des
            }).ToList();
        }

        [HttpGet]
        [Route("Cliente/listaClientesb1/{id}")]
        public object GetClientesB1(int id)
        {
            return db.Clientes.Where(p => p.id_clientes.Equals(id))
                .Select(p => new {
                    p.id_clientes,
                    p.co_cli,
                    p.cli_des
                }).ToList();
        }

        [HttpGet]
        [Route("Cliente/listaClientesxrif/{rif}")]
        public object GetClientesRIF(string rif)
        {
            return db.Clientes.Where(p => p.rif.Equals(rif))
                .Select(p => new {
                    p.id_clientes,
                    p.co_cli,
                    p.cli_des,
                    p.cod_comercio
                }).ToList();
        }

        [HttpGet]
        [Route("Cliente/listaClientesxcodigo/{codigo}")]
        public object GetClientesCodigo(string codigo)
        {
            return db.Clientes.Where(p => p.co_cli.Equals(codigo))
                .Select(p => new {
                    p.id_clientes,
                    p.co_cli,
                    p.cli_des,
                    p.cod_comercio
                }).ToList();
        }

        // GET: Cliente/Validacodigo
        [Route("Cliente/Validacodigo")]
        public IHttpActionResult GetClientesOrdenadosPorCodigo()
        {
            return Json(db.Clientes
                .OrderBy(x => x.co_cli)
                .Select(x => new
                {
                    x.id_clientes,
                    x.co_cli
                })
            );
        }

        // GET: Cotizacion/listarCliente
        // NOTA:
        // Esto se colocó para compatibilidad con rutas anteriores, pero no es apropiado, puesto
        // que la ruta incluye 'Cotización' en su URL, y esto es completamente 
        // y únicamente relacionado a Cliente.
        [Route("Cotizacion/listarCliente")]
        public IHttpActionResult GetClientesCotizacion()
        {
            return Json(db.Clientes.Select(x => new
            {
                IID = x.id_clientes,
                CODIGO = x.co_cli,
                NOMBRE = x.cli_des
            }));
        }

        // GET: api/APICliente/5
        [Route("Cliente/listaClientes/{id:int:min(1)}")]
        [ResponseType(typeof(Adclientes))]
        public IHttpActionResult GetAdclientes(int id)
        {
            Adclientes adclientes = db.Clientes.Find(id);
            if (adclientes == null)
            {
                return NotFound();
            }

            return Ok(adclientes);
        }

        // PUT: api/APICliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdclientes(int id, Adclientes adclientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adclientes.id_clientes)
            {
                return BadRequest();
            }

            db.Entry(adclientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdclientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // TODO: Falta definir la ruta apropiada.
        // Nota: Este método retorna el número de registros afectados por la petición.
        // POST: 
        [HttpPost]
        [ResponseType(typeof(int))]
        public int CrearCliente(Adclientes adclientes)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.Clientes.Add(adclientes);
            db.SaveChanges();

            return 1;
        }

        // POST: api/APICliente
        [Route("Cliente/guardarDatos")]
        [ResponseType(typeof(int))]
        public int PostAdclientes(Adclientes adclientes)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.Clientes.Add(adclientes);
            db.SaveChanges();

            return adclientes.id_clientes;
        }

        // DELETE: api/APICliente/5
        [ResponseType(typeof(Adclientes))]
        public IHttpActionResult DeleteAdclientes(int id)
        {
            Adclientes adclientes = db.Clientes.Find(id);
            if (adclientes == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(adclientes);
            db.SaveChanges();

            return Ok(adclientes);
        }

        /*[HttpGet]
        [Route("clientes/actualizar")]
        public IHttpActionResult ActualizarClientesProfit()
        {
            ProfitEntities profitContext = new ProfitEntities();
            IQueryable<Adclientes> clientes = db.Clientes;

            foreach (Adclientes cliente in clientes)
            {
                // Tablas de las que depende Cliente.
                pSeleccionarCliente_Result clienteProfit = profitContext.pSeleccionarCliente(cliente.co_cli).FirstOrDefault();
                pSeleccionarTipoCliente_Result tipoClienteProfit = profitContext.pSeleccionarTipoCliente(cliente.tip_cli).FirstOrDefault();
                pSeleccionarZona_Result zonaProfit = profitContext.pSeleccionarZona(cliente.co_zon).FirstOrDefault();
                pSeleccionarSegmento_Result segmentoProfit = profitContext.pSeleccionarSegmento(cliente.co_seg).FirstOrDefault();
                pSeleccionarVendedor_Result vendedorProfit = profitContext.pSeleccionarVendedor(cliente.co_ven).FirstOrDefault();
                pSeleccionarCuentaIngreso_Result cuentaIngresoProfit = profitContext.pSeleccionarCuentaIngreso(cliente.co_cta_ingr_egr).FirstOrDefault();
                pSeleccionarPais_Result paisProfit = profitContext.pSeleccionarPais(cliente.co_pais).FirstOrDefault();

                Adtipo_cliente tipoCliente = cliente.TipoCliente;
                Adzona zona = cliente.Zona;
                AdSegmento segmento = cliente.Segmento;
                Advendedor vendedor = cliente.Vendedor;
                AdIngreso ingreso = cliente.Ingreso;
                Adpais pais = cliente.Pais;

                // TODO: Colocar cada uno en su controlador correspondiente.
                // TODO: Agregar fechas de modificación donde corresponda.
                // TODO: TipoCliente requiere co_precio para insertar/actualizar, ¿dónde tenemos este campo en nuestro proyecto?
                // TODO: Falta co_mone para insertar/actualizar país.
                if (tipoClienteProfit != null)
                {
                    byte[] validador = tipoClienteProfit.validador;
                    profitContext.pActualizarTipoCliente(
                        tipoCliente.tip_cli, tipoCliente.tip_cli, tipoCliente.des_tipo, null, null, null, null, null, null, null, null, null, null, null,
                        null, null, null, null, validador, null
                    );
                } else
                {
                    profitContext.pInsertarTipoCliente(
                        tipoCliente.tip_cli, tipoCliente.des_tipo, null, null, null, null, null, null, null, null, null, "", null ,null, null, null
                    );
                }

                if (zonaProfit != null)
                {
                    byte[] validador = zonaProfit.validador;
                    profitContext.pActualizarZona(
                        zona.co_zon, zona.co_zon, zona.zon_des, null, null, null, null, null, null, null, null, null, null, null,
                        null, null, null, null, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarZona(
                        zona.co_zon, zona.zon_des, null, null, null, null, null, null, null, null, null, "", null, null, null, null
                    );
                }

                if (segmentoProfit != null)
                {
                    byte[] validador = segmentoProfit.validador;
                    profitContext.pActualizarSegmento(
                        segmento.co_seg, segmento.co_seg, segmento.seg_des, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                        null, null, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarSegmento(
                        segmento.co_seg, segmento.seg_des, null, null, null, null, null, null, null, null, null, null, null, "", null, null, null, null
                    );
                }

                if (vendedorProfit != null)
                {
                    byte[] validador = vendedorProfit.validador;
                    profitContext.pActualizarVendedor(
                        vendedor.co_ven, vendedor.co_ven, vendedor.tipo, vendedor.ven_des, null, null, null, null, null, DateTime.Now, false, 0, null, false, false, 0, null, null, null, null,
                        null, null, null, null, null, null, null, null, null, null, null, null, null, null, validador, null, vendedor.co_zon
                    );
                }
                else
                {
                    profitContext.pInsertarVendedor(
                        vendedor.co_ven, vendedor.tipo, vendedor.ven_des, null, null, null, null, null, DateTime.Now, false, 0, null, false, false, 0, null, null, null, null,
                        null, null, null, null, null, null, null, null, "", null, null, null, null, vendedor.co_zon
                    );
                }

                if (cuentaIngresoProfit != null)
                {
                    byte[] validador = cuentaIngresoProfit.validador;
                    profitContext.pActualizarCuentaIngreso(
                        ingreso.co_ctaIng_egr, ingreso.co_ctaIng_egr, ingreso.descrip_ingre, null, null, null, null, null, null, null, null, null, null,
                        null, null, null, null, null, null, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarCuentaIngreso(
                        ingreso.co_ctaIng_egr, ingreso.descrip_ingre, null, null, null, null, null, null, null, null, null, null,
                        "", null, null, null, null
                    );
                }

                if (paisProfit != null)
                {
                    byte[] validador = paisProfit.validador;
                    profitContext.pActualizarPais(
                        pais.co_pais, pais.co_pais, null, pais.pais_des, null, null, null, null, null, null, null, null,
                        null, null, null, null, null, null, validador, null
                    );
                }
                else
                {
                    profitContext.pInsertarPais(
                        pais.co_pais, pais.pais_des, null, null, null, null, null, null, null, null,
                        null, "", null, null, null, null
                    );
                }

                if (clienteProfit != null)
                {
                    byte[] validador = clienteProfit.validador;
                    profitContext.pActualizarCliente(
                        cliente.co_cli, cliente.co_cli, null, null, null, cliente.cli_des, cliente.co_seg, cliente.co_zon, cliente.co_ven, null, false, false, false, false, false, false, false, 
                        false, false, false, cliente.direc1, null, cliente.dir_ent2, null, null, cliente.telefonos, null, cliente.respons, DateTime.Now, cliente.tip_cli, null, null, null, null, 
                        null, null, null, null, null, cliente.rif, false, null, null, cliente.email, cliente.co_cta_ingr_egr, null, null, null, null, null, null, null, null, null, null, null, null,
                        null, null, null, cliente.juridico == "1", null, null, null, null, cliente.co_pais, cliente.ciudad, cliente.zip, null, null, null, null, validador, null, null, 
                        null, null, null
                    );
                } else
                {
                    profitContext.pInsertarCliente(
                        cliente.co_cli, null, null, null, cliente.cli_des, cliente.co_seg, cliente.co_zon, cliente.co_ven, null, false, false, false, false, false, false, false, false, 
                        false, false, cliente.direc1, null, cliente.dir_ent2, null, null, cliente.telefonos, null, cliente.respons, DateTime.Now, cliente.tip_cli, null, 0, 0, 0, null, null, 0,
                        0, 0, null, 0, cliente.rif, false, null, null, cliente.email, cliente.co_cta_ingr_egr, null, null, null, null, null, null, null, null, null, "", null, null,
                        null, null, cliente.juridico == "1", 1, null, null, null, cliente.co_pais, cliente.ciudad, cliente.zip, null, false, false, 0, null, null, null, null
                    );
                }
            }

            return Ok(true);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdclientesExists(int id)
        {
            return db.Clientes.Count(e => e.id_clientes == id) > 0;
        }
    }
}