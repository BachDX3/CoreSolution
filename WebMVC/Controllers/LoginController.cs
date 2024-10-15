using Application.Models;
using Domain.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        private UserInforModel userInforModel { get; set; } = new UserInforModel();
        private bool _isLogin { get; set; } = true;
        #endregion

        #region Default contructor
        public LoginController(UserManager<User> userManager,
           RoleManager<Role> roleManager,
           IConfiguration configuration,
           SignInManager<User> signInManager
           
           )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }
        #endregion

        #region Login 
        // GET: LoginController
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Login with <see cref="LoginModel"/>
        /// </summary>
        /// <param name="userLogin">user login model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel userLogin)
        {
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
               
                var signInResult =
                    await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, lockoutOnFailure: false);
            }
            return View();
        }
        #endregion

        #region Log Out 
        /// <summary>
        /// Log out user sign in 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            userInforModel = null;
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region CRUD User

        /// <summary>
        /// Get view create 
        /// </summary>
        /// <returns></returns>
        // GET: LoginController/Create
        public IActionResult Create()
        {
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
            if (await _roleManager.RoleExistsAsync("User"))
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
        /// <summary>
        /// Get detail user by user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        // GET: LoginController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Get user by <see cref="int"/> id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        // GET: LoginController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }


        /// <summary>
        /// Submit <see cref="IFormCollection"/> user with <see cref="int"/> userId  after edit
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="collection"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get user by <see cref="int"/> userId
        /// </summary>
        /// <param name="id">userid</param>
        /// <returns></returns>
        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

      
        /// <summary>
        /// Delete <see cref="IFormCollection"/> User with <see cref="int"/> userId
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="collection">user infor</param>
        /// <returns></returns>
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
