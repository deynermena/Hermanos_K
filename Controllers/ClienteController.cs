using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HermanosK.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HermanosK.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userEmail = User.Identity.Name;
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == userEmail);

            ViewData["FullName"] = $"{user.FirstName} {user.LastName}";
            return View();
        }
    }
}
