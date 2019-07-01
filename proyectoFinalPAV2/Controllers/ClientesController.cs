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
using ClientesDatos;
using proyectoFinalPAV2.Models;

namespace proyectoFinalPAV2.Controllers
{
    public class ClientesController : ApiController
    {
        private GestionClientesEntities db = new GestionClientesEntities();

        // GET: api/Clientes
        public List<ListadoClienteVM> GetCliente(string nombre, string apellido, string razonSocial, string cuit)
        {
            string nombreAux, apellidoAux, razonSocialAux;
            nombreAux = "%" + nombre + "%";
            apellidoAux = "%" + apellido + "%";
            razonSocialAux = "%" + razonSocial + "%";

            IQueryable<Cliente> data = db.Cliente;

            if(!string.IsNullOrEmpty(nombre)) {
                data = data.Where(c => c.nombre == nombreAux);
            }
            if(!string.IsNullOrEmpty(apellido)) {
                data = data.Where(c => c.apellido == apellidoAux);
            }
            if(!string.IsNullOrEmpty(razonSocial)) {
                data = data.Where(c => c.razonSocial == razonSocialAux);
            }
            if(!string.IsNullOrEmpty(cuit)) {
                var dni = Convert.ToInt32(cuit);
                data = data.Where(c => c.cuit == dni);
            }
                
            return data.Select(cli => new ListadoClienteVM {
                idCliente = cli.idCliente,
                tipoCliente = cli.TipoCliente.descripcion,
                percepcionIIBB = cli.percepcionIIBB == 0 ? "SI": "NO",
                percepcionComEInd = cli.percepcionComEInd == 0 ? "SI" : "NO",
                apellido = cli.apellido,
                nombre = cli.nombre,
                razonSocial = cli.razonSocial,
                cuit = cli.cuit,
                ingBrutos = cli.ingBrutos,
                domicilio = cli.domicilio,
                localidad = cli.localidad,
                telefono = cli.telefono,
                habilitado = cli.habilitado
            })
            .ToList();
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.idCliente)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cliente.Add(cliente);
            db.SaveChanges();

             * 
             */


            string erroresValidacion = "";

            if (cliente.idTipoCliente == 0 || cliente.idTipoCliente == null)
            {

            }

            if (cliente.percepcionIIBB == null || cliente.percepcionIIBB == 0)
            {

            }

            if (cliente.idTipoConvenioIIBB == null || cliente.idTipoConvenioIIBB == 0)
            {
                
            }

            if (cliente.TipoConvenioComEInd == null || cliente.idTipoConvenioComEInd == 0)
            {

            }

            if (cliente.cuit == null)
            {

            }

            if (cliente.ingBrutos == null)
            {

            }

            if (cliente.domicilio == null)
            {

            }

            if (cliente.email == null)
            {

            }

            if (cliente.localidad == null)
            {

            }

            if (cliente.telefono == null)
            {

            }

            if (cliente.habilitado == null)
            {

            }

            if (cliente.pagoCtaCte == null)
            {

            }

            if (!string.IsNullOrEmpty(erroresValidacion))
                throw new Exception(erroresValidacion);
 
              
            return CreatedAtRoute("DefaultApi", new { id = cliente.idCliente }, cliente);



        }

        /*
         * public static void Grabar(Articulos DtoSel)
        {
            // validar campos
            string erroresValidacion = "";
            if (string.IsNullOrEmpty(DtoSel.Nombre))
                erroresValidacion += "Nombre es un dato requerido; ";
            if (DtoSel.Precio == null || DtoSel.Precio == 0)
                erroresValidacion += "Precio es un dato requerido; ";
            if (!string.IsNullOrEmpty(erroresValidacion))
                throw new Exception(erroresValidacion);

            // grabar registro
            using (PymesEntities db = new PymesEntities())
            {
                try
                {
                    if (DtoSel.IdArticulo != 0)
                    {
                        db.Entry(DtoSel).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Articulos.Add(DtoSel);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("UK_Articulos_Nombre"))
                        throw new ApplicationException("Ya existe otro Artículo con ese Nombre");
                    else
                        throw;
                }
            }
        }
         */


        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Cliente.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Cliente.Count(e => e.idCliente == id) > 0;
        }
    }
}