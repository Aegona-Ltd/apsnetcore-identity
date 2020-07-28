using AuthSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class UserRoleViewModel
    {
        public ApplicationUser user { get; set; }
        public List<string> roles { get; set; }
    }
}
