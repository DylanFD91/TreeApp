using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Physis.Models
{
    public class GoogleMapsViewModel
    {
        public List<Tree> Trees { get; set; }
        public List<Vendor> Vendors { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public TreePlanter TreePlanter { get; set; }
    }
}
