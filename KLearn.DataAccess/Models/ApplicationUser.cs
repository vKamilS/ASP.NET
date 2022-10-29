using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLearn.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? AvatarLink { get; set; }
        public DateTime Created { get; set; }
    }
}
