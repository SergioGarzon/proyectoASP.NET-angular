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
    public class TipoClientesController : ApiController
    {
        private GestionClientesEntities db = new GestionClientesEntities();

        // GET: api/TipoClientes
        public List<TipoClienteVM> GetTipoCliente()
        {
            return db.TipoCliente.Select(t => new TipoClienteVM
            {
                idTipoCliente = t.idTipoCliente,
                descripcion = t.descripcion
            }).ToList();
        }

        // GET: api/TipoClientes/5
        [ResponseType(typeof(TipoCliente))]
        public IHttpActionResult GetTipoCliente(int id)
        {
            TipoCliente tipoCliente = db.TipoCliente.Find(id);
            if (tipoCliente == null)
            {
                return NotFound();
            }

            return Ok(tipoCliente);
        }

        // PUT: api/TipoClientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoCliente(int id, TipoCliente tipoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCliente.idTipoCliente)
            {
                return BadRequest();
            }

            db.Entry(tipoCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoClienteExists(id))
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

        // POST: api/TipoClientes
        [ResponseType(typeof(TipoCliente))]
        public IHttpActionResult PostTipoCliente(TipoCliente tipoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoCliente.Add(tipoCliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoCliente.idTipoCliente }, tipoCliente);
        }

        // DELETE: api/TipoClientes/5
        [ResponseType(typeof(TipoCliente))]
        public IHttpActionResult DeleteTipoCliente(int id)
        {
            TipoCliente tipoCliente = db.TipoCliente.Find(id);
            if (tipoCliente == null)
            {
                return NotFound();
            }

            db.TipoCliente.Remove(tipoCliente);
            db.SaveChanges();

            return Ok(tipoCliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoClienteExists(int id)
        {
            return db.TipoCliente.Count(e => e.idTipoCliente == id) > 0;
        }
    }
}