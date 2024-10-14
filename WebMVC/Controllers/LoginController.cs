using Application.Models;
using Application.Utility.Identity;
using Domain.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {
        #region Private member
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationSignInManager _applicationSignInManager;

        private readonly Microsoft.AspNetCore.Identity.SignInResult signInResult;
        private UserInforModel userInforModel { get; set; } = new UserInforModel();
        private bool _isLogin { get; set; } = true;
        #endregion

        #region Default contructor
        public LoginController(UserManager<User> userManager,
           RoleManager<Role> roleManager,
           IConfiguration configuration,
           SignInManager<User> signInManager,
           ApplicationSignInManager applicationSignInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _applicationSignInManager = applicationSignInManager;
        }
        #endregion

        #region Login 
        // GET: LoginController
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                // check user by name
                //User userObject= await _userManager.FindByNameAsync(userLogin.UserName);

                //if (userObject != null)
                //{
                //    // check user lock
                //    bool checkUserIsLock = await _userManager.IsLockedOutAsync(userObject);
                //    if (!checkUserIsLock)
                //    {

                //        // check user password 
                //        bool checkPasswordSignIn = await _userManager.CheckPasswordAsync(userObject, userLogin.Password);
                //        if (!checkPasswordSignIn)
                //        {
                //            // sign in by password and user name
                //            signInResult =  await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, lockoutOnFailure: false);
                //        }
                //    }
                //}
                var signInResult =
                    await _applicationSignInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        #endregion

        #region Log Out 

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            userInforModel = null;
            return RedirectToAction("Index", "Home");
        }
        #endregion


        #region CRUD User

       
        // GET: LoginController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterModel register)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            // check user exist
            var userExist = await _userManager.FindByEmailAsync(register.Email);
            if (userExist != null)
            {
                return RedirectToAction("Index");
            }
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
            if(await _roleManager.RoleExistsAsync("User"))
            {
                // add user the database
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    // assign role
                  var checkAddRole = await _userManager.AddToRoleAsync(user, "User");
                    if (checkAddRole.Succeeded)
                    {
                        return RedirectToAction("Home");
                    }
                }
            }
            return View();
        }

        // GET: LoginController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Access denied view
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion
    }
}
