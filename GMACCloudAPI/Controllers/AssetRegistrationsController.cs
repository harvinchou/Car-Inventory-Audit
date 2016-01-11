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
    public class AssetRegistrationsController : ApiController
    {
        private GMACServiceContext db = new GMACServiceContext();


        public IEnumerable<AssetRegistration> GetAllAssetRegistrations()
        {
            return db.AssetRegistrations;
        }

        [Route("api/AssetRegistrations/{VIN}")]
        [ResponseType(typeof(AssetRegistration))]
        public IHttpActionResult GetAssetRegistration(string VIN)
        {
            AssetRegistration assetregistration = db.AssetRegistrations.Find(VIN);

            if (assetregistration == null)
            {
                return NotFound();
            }
            return Ok(assetregistration);
        }

        /*
        [Route("api/AssetRegistrations/{rfid}")]
        [ResponseType(typeof(AssetRegistration))]
        public IHttpActionResult GetAssetRegistration(string rfid)
        {
            AssetRegistration assetregistration = db.AssetRegistrations.Single(a => a.RFIDCode == rfid);
          
            if (assetregistration == null)
            {
                return NotFound();
            }
            return Ok(assetregistration);
        }
        */

        /// <summary>
        /// API05
        /// </summary>
        /// <param name="assetregistrations"></param>
        /// <returns>
        /// Status code: 200 (OK).
        /// </returns>
        public IHttpActionResult PostAssetRegistrations(AssetRegistration[] assetregistrations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (AssetRegistration assetregistration in assetregistrations)
            {
                db.AssetRegistrations.Add(assetregistration);
            }
            db.SaveChanges();
            
            return Ok();
        }

        [Route("api/AssetRegistrations/{VIN}")]
        public IHttpActionResult DeleteAssetRegistration(string VIN)
        {
            AssetRegistration assetregistration = db.AssetRegistrations.Find(VIN);

            if (assetregistration == null)
            {
                return NotFound();
            }

            db.AssetRegistrations.Remove(assetregistration);
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
