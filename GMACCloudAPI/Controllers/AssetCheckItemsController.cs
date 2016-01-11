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
    public class AssetCheckItemsController : ApiController
    {
        private GMACServiceContext db = new GMACServiceContext();

        [Route("api/AssetCheckItems/{taskcode}")]
        [ResponseType(typeof(AssetCheckItem[]))]
        public IHttpActionResult GetAssetCheckItems(string taskcode)
        {
            var assetcheckitems = db.AssetCheckItems.Where(a => a.TaskCode == taskcode);
            if (assetcheckitems.Count() < 1)
            {
                return NotFound();
            }

            return Ok(assetcheckitems);            
        }

        public IHttpActionResult PutAssetCheckItems(AssetCheckItem[] assetcheckitems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (AssetCheckItem assetcheckitem in assetcheckitems)
            {
                db.Entry(assetcheckitem).State = EntityState.Modified;
            }
            db.SaveChanges();
            
            return Ok();
        }

        public IHttpActionResult PostAssetCheckItem(AssetCheckItem[] assetcheckitems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (AssetCheckItem assetcheckitem in assetcheckitems)
            {
                db.AssetCheckItems.Add(assetcheckitem);
            }
            db.SaveChanges();

            return Ok();
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
