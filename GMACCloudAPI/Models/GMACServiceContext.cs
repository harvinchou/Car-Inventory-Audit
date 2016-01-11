using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace GMACCloudAPI.Models
{
    public class GMACServiceContext : DbContext
    {
        public GMACServiceContext() : base("name=GMACServiceContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<GMACCloudAPI.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<GMACCloudAPI.Models.AssetRegistration> AssetRegistrations { get; set; }       
        public System.Data.Entity.DbSet<GMACCloudAPI.Models.AssetCheckJob> AssetCheckJobs { get; set; }
        public System.Data.Entity.DbSet<GMACCloudAPI.Models.AssetCheckItem> AssetCheckItems { get; set; }
    }
}