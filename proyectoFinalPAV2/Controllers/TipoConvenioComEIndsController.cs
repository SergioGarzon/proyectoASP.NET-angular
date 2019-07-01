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
    public class TipoConvenioComEIndsController : ApiController
    {
        private GestionClientesEntities db = new GestionClientesEntities();

        // GET: api/TipoConvenioComEInds
        public List<TipoConvenioComEIndVM> GetTipoConvenioComEInd()
        {
            return db.TipoConvenioComEInd.Select(t => new TipoConvenioComEIndVM
            {
                idTipoConvenioComEInd = t.idTipoConvenioComEInd,
                descripcion = t.descripcion
            }).ToList();
        }

        // GET: api/TipoConvenioComEInds/5
        [ResponseType(typeof(TipoConvenioComEInd))]
        public IHttpActionResult GetTipoConvenioComEInd(int id)
        {
            TipoConvenioComEInd tipoConvenioComEInd = db.TipoConvenioComEInd.Find(id);
            if (tipoConvenioComEInd == null)
            {
                return NotFound();
            }

            return Ok(tipoConvenioComEInd);
        }

        // PUT: api/TipoConvenioComEInds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoConvenioComEInd(int id, TipoConvenioComEInd tipoConvenioComEInd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoConvenioComEInd.idTipoConvenioComEInd)
            {
                return BadRequest();
            }

            db.Entry(tipoConvenioComEInd).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoConvenioComEIndExists(id))
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

        // POST: api/TipoConvenioComEInds
        [ResponseType(typeof(TipoConvenioComEInd))]
        public IHttpActionResult PostTipoConvenioComEInd(TipoConvenioComEInd tipoConvenioComEInd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoConvenioComEInd.Add(tipoConvenioComEInd);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoConvenioComEInd.idTipoConvenioComEInd }, tipoConvenioComEInd);
        }

        // DELETE: api/TipoConvenioComEInds/5
        [ResponseType(typeof(TipoConvenioComEInd))]
        public IHttpActionResult DeleteTipoConvenioComEInd(int id)
        {
            TipoConvenioComEInd tipoConvenioComEInd = db.TipoConvenioComEInd.Find(id);
            if (tipoConvenioComEInd == null)
            {
                return NotFound();
            }

            db.TipoConvenioComEInd.Remove(tipoConvenioComEInd);
            db.SaveChanges();

            return Ok(tipoConvenioComEInd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoConvenioComEIndExists(int id)
        {
            return db.TipoConvenioComEInd.Count(e => e.idTipoConvenioComEInd == id) > 0;
        }
    }
}