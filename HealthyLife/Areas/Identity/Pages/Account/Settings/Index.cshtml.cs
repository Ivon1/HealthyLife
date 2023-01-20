#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HealthyLife.Data;
using HealthyLife.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyLife.Areas.Identity.Pages.Account.Settings
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext applicationDb)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = applicationDb;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }

            [EmailAddress]
            public string EmailAddress { get; set; }


        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var firstName =  user.FirstName;
            var lastName = user.LastName;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Неочікувана помилка під час спроби встановлення номера телефону.";
                    return RedirectToPage();
                }
            }

            var firstName = user.FirstName;
            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                var setFirstNameResult = await _userManager.UpdateAsync(user);
                if(!setFirstNameResult.Succeeded)
                {
                    StatusMessage = "Неочікувана помилка під час спроби зміни ім'я.";
                    return RedirectToPage();
                }
            }

            var lastName = user.LastName;
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                var setLastNameResult = await _userManager.UpdateAsync(user);
                if (!setLastNameResult.Succeeded)
                {
                    StatusMessage = "Неочікувана помилка під час спроби зміни призвіща.";
                    return RedirectToPage();
                }
            }

            var email = user.Email;
            if (Input.EmailAddress != email)
            {
                user.Email = Input.EmailAddress;
                var setEmailResult = await _userManager.UpdateAsync(user);
                if (!setEmailResult.Succeeded)
                {
                    StatusMessage = "Неочікувана помилка під час спроби зміни пошти.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Ваш профіль успішно оновлено !";
            return RedirectToPage();
        }
    }
}
