using Application.Models;
using Application.Services.Implements;
using Domain.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        #region Private member

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserStore<User> _userStore;
        private readonly IConfiguration _configuration;
        private ILogger<AccountController> _logger { get; }

        #endregion
        #region Public member
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        #endregion


        #region Default contructor
        public AccountController(UserManager<User> userManager,
           RoleManager<Role> roleManager,
           IConfiguration configuration,
           SignInManager<User> signInManager,
           IUserStore<User> userStore,
           ILogger<AccountController> logger
           )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _userStore = userStore;
            _logger = logger;
        }
        #endregion

        #region Login 
        // GET: LoginController
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return  View();
        }


        /// <summary>
        /// Login using <see cref="LoginModel"/>  with parameter userLogin
        /// </summary>
        /// <param name="userLogin">user login model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel userLogin)
        {
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, userLogin.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return RedirectToAction("Error");
                }
            }
            else 
            {
                return View();
            }
            return View();
        }
        #endregion

        #region Log out
        /// <summary>
        /// Log out user sign in 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index","Home");
        }
        #endregion

        #region Register
        /// <summary>
        /// Get view create 
        /// </summary>
        /// <returns></returns>
        // GET: LoginController/Create
        public async Task<IActionResult> Register()
        {
            string returnUrl = "~Home/Index";
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewBag.ExternalLoginsList = ExternalLogins;
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// Post create  new user by <see cref="RegisterModel"/> 
        /// </summary>
        /// <param name="register">model create new user</param>
        /// <returns></returns>
        // POST: LoginController/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            string returnUrl = "~Home/Index";
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewBag.ExternalLoginsList = ExternalLogins;
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    UserName = register.UserName,
                    Email = register.Email,
                    Password = register.Password,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    PhoneNumber = register.PhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                await _userManager.SetUserNameAsync(user, user.Email);
                await _userManager.SetEmailAsync(user, user.Email);
                var result = await _userManager.CreateAsync(user, user.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    if (result.Succeeded)
                    {
                        // assign role
                        var checkAddRole = await _userManager.AddToRoleAsync(user, "User");

                        if (checkAddRole.Succeeded)
                        {

                            var userId = await _userManager.GetUserIdAsync(user);
                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                            //var callbackUrl = Url.Page(
                            //    "/Account/ConfirmEmail",
                            //pageHandler: null,
                            //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                            //    protocol: Request.Scheme);

                            //await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                            //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                            _logger.LogInformation("User created a new account with role.");
                            if (_userManager.Options.SignIn.RequireConfirmedAccount)
                            {
                                return RedirectToPage("RegisterConfirmation", new { email = user.Email, returnUrl = returnUrl });
                            }
                            else
                            {
                                await _signInManager.SignInAsync(user, isPersistent: false);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            _logger.LogInformation("Can't add role for user register");
                            return RedirectToAction("Error", "Account");
                        }
                    }

                }
                else
                {
                    _logger.LogInformation("Can't add role for user register");
                    return RedirectToAction("Error", "Account");
                }
            }
            return View();
        }

        #endregion
    }
}
