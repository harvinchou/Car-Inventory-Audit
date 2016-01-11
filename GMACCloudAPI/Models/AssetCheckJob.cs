using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMACCloudAPI.Models
{
    public class AssetCheckJob
    {
        [Key]
        [MaxLength(30)]
        public string TaskCode { get; set; }
        public string Dealer { get; set; }
        public string OperatorLoginAccount { get; set; }
        public string TaskStatus { get; set; }
        public string CreatedOn { get; set; }
        public string CompletedOn { get; set; }
        public string ResultStatus { get; set; }
        public string ResultComment { get; set; }                   
    }
}