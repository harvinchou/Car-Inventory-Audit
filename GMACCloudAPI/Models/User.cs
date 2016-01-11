using GMACCloudAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMACCloudAPI.Models
{
    public class User
    {
        [Key]
        [MaxLength(30)]
        public string LoginAccount { get; set; }

        public string Password { get; set; }
    }
}