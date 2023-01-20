// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HealthyLife.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HealthyLife.Areas.Identity.Pages.Account.Settings
{
    public class EditionalData : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;

        public EditionalData(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<DeletePersonalDataModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public string SelectedRadio { get; set; }

        public class InputModel
        {
            public string Gender { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel { Gender = user.Genger, BirthDate = user.BirthDate };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            user.BirthDate = Input.BirthDate;

            string genderFromForm = Request.Form["gender"];
            if (genderFromForm == "Жіноча")
            {
                user.Genger = "Жіноча";
            } 
            else if (genderFromForm == "Чоловіча") 
            {
                user.Genger = "Чоловіча";
            }
            else if (genderFromForm == "Бажаю не вказувати")
            {
                user.Genger = "Бажаю не вказувати";
            } 
            else
            {
                user.Genger = "Бажаю не вказувати";
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Ваш профіль успішно оновлено !";
            return RedirectToPage();
        }
    }
}
