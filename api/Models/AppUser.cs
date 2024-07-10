using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        // Many-to-many relationship
        public List<Portfolio> PortFolios { get; set; } = new List<Portfolio>();

    }
}