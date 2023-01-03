using Klinika.Intranet.Data;
using Klinika.Intranet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Klinika.Intranet.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserManagmentController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private ApplicationDbContext db;


        public UserManagmentController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = db.Users.Select(s=>new UserModel(s.Id, s.UserName, string.Empty)).ToList();
            foreach (var item in model)
            {
                var ur = db.UserRoles.Where(w => w.UserId == item.UserId).FirstOrDefault();
                if (ur != null)
                {
                    var role = db.Roles.Find(ur.RoleId);
                    item.Role = role.Name;
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddToRole(string userid, string role)
        {
            var user = db.Users.Find(userid);
            //if (await userManager.IsInRoleAsync(user,role)) 
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            if(await userManager.IsInRoleAsync(user,"Administrator"))
            {
                await userManager.RemoveFromRoleAsync(user, "Administrator");
            }

            if (await userManager.IsInRoleAsync(user, "Lekarz"))
            {
                await userManager.RemoveFromRoleAsync(user, "Lekarz");
            }

            if (await userManager.IsInRoleAsync(user, "Pacjent"))
            {
                await userManager.RemoveFromRoleAsync(user, "Pacjent");
            }
            await userManager.AddToRoleAsync(user, role);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string Id)
        {
            var user = db.Users.Find(Id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
