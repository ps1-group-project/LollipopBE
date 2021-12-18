using Lollipop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lollipop.Application.Services
{
    public interface IUserService
    {
        string GetUserId();

        Task DeleteUserAsync();

        Task SingOutAsync();

        Task ChangeEmailAsync(string newEmail);

        Task ChangePhoneNumberAsync(string newPhoneNumber);

        Task ChangePasswordAsync(string oldPassword, string newPassword);

        Task PasswordSignInAsync(string userName, string password, bool rememberMe, bool lockoutOnFailure = false);

        Task RegisterUserAsync(string userName, string email, string phoneNumber, string password);

        Task<List<string>> GetUserRoles(string userId);

        Task<List<AppUser>> GetAllUsers();

        Task<AppUser> GetUserAsync();
    }
}
