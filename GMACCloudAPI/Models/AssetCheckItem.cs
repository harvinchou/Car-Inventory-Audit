using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GMACCloudAPI.Models
{
    public class AssetCheckItem
    {        
        [Key]
        [Column(Order = 1)]
        [MaxLength(30)]
        public string TaskCode { get; set; }
        [Key]
        [Column(Order = 2)]
        [MaxLength(30)]
        public string VIN { get; set; }
        public string RFIDCode { get; set; }
        public string GPS { get; set; }
        public string ScannedOn { get; set; }
        public string ResultStatus { get; set; }
        public string ResultComment { get; set; }
    }
}