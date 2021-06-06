using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Semester_Project.AdoNet;
using Semester_Project.Models;

namespace Semester_Project.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        [BindProperty]
        public SiteUser user { get; set; }
        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ValidateUser(user, _configuration))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));
                return RedirectToPage("/Index");
            }
            return Page();
        }
        private static bool ValidateUser(SiteUser User, IConfiguration configuration)
        {
            string hash = CRUD.GetPasswordHash(User.Username, configuration);
            if (hash == null)
                return false;
            bool verified = BCrypt.Net.BCrypt.Verify(User.Password, hash);
            if (verified)
                return true;
            else
                return false;
        }
    }
}
