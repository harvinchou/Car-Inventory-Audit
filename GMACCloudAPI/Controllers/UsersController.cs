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
    public class UsersController : ApiController
    {
        private GMACServiceContext db = new GMACServiceContext();

        [ResponseType(typeof(void))]
        public IHttpActionResult Login(User user)
        {
            User _user = db.Users.Find(user.LoginAccount);

            if (_user == null)
            {
                return NotFound();
            }

            if (_user.Password != user.Password)
            {
                return NotFound();
            }

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
