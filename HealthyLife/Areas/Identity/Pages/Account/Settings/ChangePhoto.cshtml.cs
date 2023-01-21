// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HealthyLife.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HealthyLife.Areas.Identity.Pages.Account.Settings
{
    public class ChangePhoto : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;
        private readonly IWebHostEnvironment _host;

        public ChangePhoto(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<DeletePersonalDataModel> logger,
            IWebHostEnvironment host)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _host = host;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public ApplicationUser CurrentApplicationUserUser { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            public string CurrentPathToPhoto { get; set; }
  
            public IFormFile NewPathToPhoto { get; set; }
        }

        public async Task<IActionResult> OnGet()
        {
            CurrentApplicationUserUser = await _userManager.GetUserAsync(User);
            if (CurrentApplicationUserUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel { CurrentPathToPhoto = CurrentApplicationUserUser.PathToPhoto };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CurrentApplicationUserUser = await _userManager.GetUserAsync(User);
            if (CurrentApplicationUserUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (Input.NewPathToPhoto != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var fileName = Input.NewPathToPhoto.FileName.ToLower();
                if (!allowedExtensions.Any(fileName.EndsWith))
                {
                    StatusMessage = "Дозволені типи файлів - jpg, jpeg, png!";
                    return Page();
                }

                string folderPath = _host.WebRootPath + "/img/img_users";
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    if (Path.GetFileName(file).Contains(CurrentApplicationUserUser.Email))
                    {
                        try
                        {
                            System.IO.File.Delete(file);
                        }
                        catch { }
                    }
                }

                var name = Path.Combine(_host.WebRootPath + "/img/img_users", CurrentApplicationUserUser.Email + "_" + Path.GetFileName(Input.NewPathToPhoto.FileName));
                using (var stream = new FileStream(name, FileMode.Create))
                {
                    await Input.NewPathToPhoto.CopyToAsync(stream);
                }
                CurrentApplicationUserUser.PathToPhoto = CurrentApplicationUserUser.Email + "_" + Input.NewPathToPhoto.FileName;
            }
            else
            {
                if (Request.Form["photo-gal"].ToString() != null)
                {
                    string photoFromGal = Request.Form["photo-gal"];
                    string modifed = photoFromGal.Substring(15);
                    CurrentApplicationUserUser.PathToPhoto = modifed;
                }
                else
                {
                    CurrentApplicationUserUser.PathToPhoto = "default_image_profile1.png";
                }
            }

            
            

            await _userManager.UpdateAsync(CurrentApplicationUserUser);

            await _signInManager.RefreshSignInAsync(CurrentApplicationUserUser);
            StatusMessage = "Ваш профіль успішно оновлено !";

            return RedirectToPage();
        }

        protected bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
