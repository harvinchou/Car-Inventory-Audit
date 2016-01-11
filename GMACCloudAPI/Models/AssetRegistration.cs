using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMACCloudAPI.Models
{
    /// <summary>
    /// Vehicle Asset Registration
    /// </summary>
    public class AssetRegistration
    {
        /// <summary>
        /// Vehicle Identification Number
        /// e.g. 1G2NW12E25M108434
        /// </summary>
        [Key]
        [MaxLength(30)]
        public string VIN { get; set; }

        /// <summary>
        /// RFID Electronic Product Code
        /// e.g. 1234567890128
        /// </summary>
        public string RFIDCode { get; set; }

        /// <summary>
        /// Car Dealer ID
        /// e.g. 1111
        /// </summary>
        public string Dealer { get; set; }

        /// <summary>
        /// Car Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Operator Login Account ID
        /// e.g. 0001
        /// </summary>
        public string OperatorLoginAccount { get; set; }

        /// <summary>
        /// Asset Registration Time
        /// e.g. 2015-12-09T13:45:30.05 
        /// </summary>
        public string CreatedOn { get; set; }
    }
}