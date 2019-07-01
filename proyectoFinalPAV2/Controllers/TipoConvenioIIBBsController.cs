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
    public class TipoConvenioIIBBsController : ApiController
    {
        private GestionClientesEntities db = new GestionClientesEntities();

        // GET: api/TipoConvenioIIBBs
        public List<TipoConvenioIIBBVM> GetTipoConvenioIIBB()
        {
            return db.TipoConvenioIIBB.Select(t => new TipoConvenioIIBBVM
            {
                idTipoConvenioIIBB = t.idTipoConvenioIIBB,
                descripcion = t.descripcion
            }).ToList();
        }


        // GET: api/TipoConvenioIIBBs/5
        [ResponseType(typeof(TipoConvenioIIBB))]
        public IHttpActionResult GetTipoConvenioIIBB(int id)
        {
            TipoConvenioIIBB tipoConvenioIIBB = db.TipoConvenioIIBB.Find(id);
            if (tipoConvenioIIBB == null)
            {
                return NotFound();
            }

            return Ok(tipoConvenioIIBB);
        }

        // PUT: api/TipoConvenioIIBBs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoConvenioIIBB(int id, TipoConvenioIIBB tipoConvenioIIBB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoConvenioIIBB.idTipoConvenioIIBB)
            {
                return BadRequest();
            }

            db.Entry(tipoConvenioIIBB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoConvenioIIBBExists(id))
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

        // POST: api/TipoConvenioIIBBs
        [ResponseType(typeof(TipoConvenioIIBB))]
        public IHttpActionResult PostTipoConvenioIIBB(TipoConvenioIIBB tipoConvenioIIBB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoConvenioIIBB.Add(tipoConvenioIIBB);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoConvenioIIBB.idTipoConvenioIIBB }, tipoConvenioIIBB);
        }

        // DELETE: api/TipoConvenioIIBBs/5
        [ResponseType(typeof(TipoConvenioIIBB))]
        public IHttpActionResult DeleteTipoConvenioIIBB(int id)
        {
            TipoConvenioIIBB tipoConvenioIIBB = db.TipoConvenioIIBB.Find(id);
            if (tipoConvenioIIBB == null)
            {
                return NotFound();
            }

            db.TipoConvenioIIBB.Remove(tipoConvenioIIBB);
            db.SaveChanges();

            return Ok(tipoConvenioIIBB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoConvenioIIBBExists(int id)
        {
            return db.TipoConvenioIIBB.Count(e => e.idTipoConvenioIIBB == id) > 0;
        }
    }
}