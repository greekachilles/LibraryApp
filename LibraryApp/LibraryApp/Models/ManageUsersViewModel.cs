using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class ManageUsersViewModel
    {

        public IdentityUser[] Admins { get; set; }

        public IdentityUser[] Everyone { get; set; }
    }
}
