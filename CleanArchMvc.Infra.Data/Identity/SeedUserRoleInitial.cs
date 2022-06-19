using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Identity
{
    public partial class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private void CreateUserOnRoles(string name, string password, String role)
        {
            if (_userManager.FindByEmailAsync($"{name}@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = $"{name}@localhost";
                user.Email = $"{name}@localhost";
                user.NormalizedUserName = $"{name}@localhost".ToUpper();
                user.NormalizedEmail = $"{name}@localhost".ToUpper();
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, role).Wait();
                }

            }
        }
        private void CreateRole(Roles roles)
        {
            if (!_roleManager.RoleExistsAsync(roles.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roles.ToString();
                role.NormalizedName = roles.ToString().ToUpper();
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
        public void SeedUsers()
        {
            CreateUserOnRoles("guilherme", "1234567@Abc", Roles.Admin.ToString());
            CreateUserOnRoles("Fernando", "654321@Cba", Roles.User.ToString());
        }
        public void SeedRoles()
        {
            CreateRole(Roles.Admin);
            CreateRole(Roles.User);
        }

    }
}
