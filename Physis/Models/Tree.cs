using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Physis.Models
{
    public class Tree
    {
        [Key]
        public int TreeId { get; set; }
        public string TreeType { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("TreePlanter")]
        public int TreePlanterId { get; set; }
        public TreePlanter TreePlanter { get; set; }

        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
