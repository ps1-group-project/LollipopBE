
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Lollipop.Application.Service;
using Lollipop.Core.Models;
using Lollipop.Persistence.DbContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Lollipop.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly LollipopDbContext _dbContext;

        public UserService(UserManager<AppUser> userManager, IHttpContextAccessor accessor, SignInManager<AppUser> signInManager, LollipopDbContext dbContext)
        {
            _userManager = userManager;
            _accessor = accessor;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public string GetUserId()
        {
            string userId = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
                         ?? throw new Exception("User not found.");

            return userId;
        }

        public async Task DeleteUserAsync()
        {
            AppUser user = await GetUserAsync();
            IdentityResult result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).ToString());
        }

        public async Task SingOutAsync()
        {
            await _signInManager.SignOutAsync();
            await _accessor.HttpContext.SignOutAsync();
        }

        public async Task ChangeEmailAsync(string newEmail)
        {
            AppUser user = await GetUserAsync();
            IdentityResult result = await _userManager.SetEmailAsync(user, newEmail);

            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).ToString());
        }

        public async Task ChangePhoneNumberAsync(string newPhoneNumber)
        {
            AppUser user = await GetUserAsync();
            user.PhoneNumber = newPhoneNumber;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).ToString());
        }

        public async Task ChangePasswordAsync(string oldPassword, string newPassword)
        {
            AppUser user = await GetUserAsync();
            IdentityResult result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).ToString());
        }

        public async Task PasswordSignInAsync(string userName, string password, bool rememberMe, bool lockoutOnFailure = false)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            SignInResult result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure);
            
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(
                        "UserId: " + user.Id,
                        "RequireTwoFactor: " + result.RequiresTwoFactor,
                        "IsNotAllowed: " + result.IsNotAllowed,
                        "IsLockedOut: " + result.IsLockedOut));
            }
            var claims = await _userManager.GetClaimsAsync(user);
            
            var claimsIdentity = new ClaimsIdentity(  
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            await _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }

        public async Task RegisterUserAsync(string userName, string email, string phoneNumber, string password)
        {
            AppUser user = new()
            {
                UserName = userName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            IdentityResult result = await _userManager.CreateAsync(user, password);
            IdentityResult roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).ToString());
            if (!roleResult.Succeeded)
                throw new Exception(roleResult.Errors.Select(x => x.Description).ToString());
        }

        public async Task<AppUser> GetUserAsync()
        {
            return await _userManager.FindByIdAsync(GetUserId()) ??
                       throw new IdentityNotMappedException();
        }

        public async Task<List<string>> GetUserRoles(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId) ??
                throw new Exception("user not found");
            var roles = await _userManager.GetRolesAsync(user);

            return roles.ToList();
        }


        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            var users = await Task.Run(() => _dbContext.Users);

            return users.ToList();
        }
    }
}
