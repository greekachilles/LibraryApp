using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ManageUsersController : Controller
    {

        private readonly UserManager<IdentityUser>
            _userManager;

        


        public ManageUsersController(
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

       
        public async Task<IActionResult> Index()
        {

            var admins = (await _userManager
                .GetUsersInRoleAsync(Constants.AdminRole))
                .ToArray();


         

            var everyone = await _userManager.Users
                
                .ToArrayAsync();

           

            

            var model = new ManageUsersViewModel
            {
                Admins = admins,
                Everyone = everyone
            };

            
            return View(model);
        }
    }
}