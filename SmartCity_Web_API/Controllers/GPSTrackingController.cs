using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SmartCity_Web_API.Models;

namespace SmartCity_Web_API.Controllers
{
    public class GPSTrackingController : ApiController
    {
        private dbBusTrackingContext db = new dbBusTrackingContext();

        // GET: api/GPSTracking
        [Route("api/GPSTracking/getData")]
        public IQueryable<tbGPS> GettbGPS()
        {
            return db.tbGPS;
        }

        // GET: api/GPSTracking/5
        [Route("api/GPSTracking/getData")]
        [ResponseType(typeof(tbGPS))]
        public async Task<IHttpActionResult> GettbGPS(DateTime id)
        {
            tbGPS tbGPS = await db.tbGPS.FindAsync(id);
            if (tbGPS == null)
            {
                return NotFound();
            }

            return Ok(tbGPS);
        }

        // PUT: api/GPSTracking/5
        [Route("api/GPSTracking/updateData")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttbGPS(DateTime id, tbGPS tbGPS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbGPS.Date)
            {
                return BadRequest();
            }

            db.Entry(tbGPS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbGPSExists(id))
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

        // POST: api/GPSTracking
        [Route("api/GPSTracking/addData")]
        [ResponseType(typeof(tbGPS))]
        public async Task<IHttpActionResult> PosttbGPS(tbGPS tbGPS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbGPS.Add(tbGPS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tbGPSExists(tbGPS.Date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbGPS.Date }, tbGPS);
        }

        // DELETE: api/GPSTracking/5
        [Route("api/GPSTracking/deleteData")]
        [ResponseType(typeof(tbGPS))]
        public async Task<IHttpActionResult> DeletetbGPS(DateTime id)
        {
            tbGPS tbGPS = await db.tbGPS.FindAsync(id);
            if (tbGPS == null)
            {
                return NotFound();
            }

            db.tbGPS.Remove(tbGPS);
            await db.SaveChangesAsync();

            return Ok(tbGPS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbGPSExists(DateTime id)
        {
            return db.tbGPS.Count(e => e.Date == id) > 0;
        }
    }
}