// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HealthyLife.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using HealthyLife.Services;
using SendInBlue;
using MimeKit;

namespace HealthyLife.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _sender;

        public RegisterConfirmationModel(UserManager<ApplicationUser> userManager, IEmailSender sender)
        {
            _userManager = userManager;
            _sender = sender;
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }
            returnUrl = returnUrl ?? Url.Content("~/");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;
            // Once you add a real email sender, you should remove this code that lets you confirm the account
            DisplayConfirmAccountLink = true;
            if (DisplayConfirmAccountLink)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                EmailConfirmationUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    protocol: Request.Scheme);
            }
            //else
            //{
            //    var userId = await _userManager.GetUserIdAsync(user);
            //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            //    EmailConfirmationUrl = Url.Page(
            //        "/Account/ConfirmEmail",
            //        pageHandler: null,
            //        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
            //        protocol: Request.Scheme);

            //    var message = new MimeMessage();
            //    message.From.Add(new MailboxAddress("HealthyLife", "healthylife@autorambler.ru"));
            //    message.To.Add(new MailboxAddress("User", Email));
            //    message.Subject = "Підтвердження пошти";
            //    message.Body = new TextPart("plain")
            //    {
            //        Text = $"{EmailConfirmationUrl}"
            //    };

            //    using (var client = new MailKit.Net.Smtp.SmtpClient())
            //    {
            //        // настройки соединения с сервером
            //        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //        client.Connect("smtp.rambler.ru", 465, true);
            //        client.Authenticate("healthylife@autorambler.ru", "Healthylife123");

            //        // отправка сообщения
            //        client.Send(message);
            //        client.Disconnect(true);
            //    }
            //}

            return Page();
        }
    }
}
