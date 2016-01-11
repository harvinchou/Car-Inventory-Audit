using GMACCloudAPI.Models;
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

namespace GMACCloudAPI.Controllers
{
    public class AssetCheckJobsController : ApiController
    {
        private GMACServiceContext db = new GMACServiceContext();

        public IEnumerable<AssetCheckJob> GetAllAssetCheckJobs()
        {
            return db.AssetCheckJobs;
        }

        [Route("api/AssetCheckJobs/{operatorloginaccount}")]
        [ResponseType(typeof(AssetCheckJob[]))]
        public IHttpActionResult GetAssetCheckJobs(string operatorloginaccount)
        {
            var assetcheckjobs = db.AssetCheckJobs.Where(a => a.OperatorLoginAccount == operatorloginaccount);
            if (assetcheckjobs.Count() < 1)
            {
                return NotFound();
            }

            return Ok(assetcheckjobs);
        }

        [Route("api/AssetCheckJobs/{taskcode}")]
        public IHttpActionResult PutAssetCheckJob(string taskcode, AssetCheckJob assetcheckjob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (taskcode != assetcheckjob.TaskCode)
            {
                return BadRequest();
            }

            db.Entry(assetcheckjob).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetCheckJobExists(taskcode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();           
        }

        public IHttpActionResult PostAssetCheckJob(AssetCheckJob assetcheckjob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.AssetCheckJobs.Add(assetcheckjob);
            db.SaveChanges();

            return Ok();
        }

        private bool AssetCheckJobExists(string taskcode)
        {
            return db.AssetCheckJobs.Count(e => e.TaskCode == taskcode) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
