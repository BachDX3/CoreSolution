using Application.Models;
using Domain.Entity;
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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private UserInforModel userInforModel { get; set; } = new UserInforModel();
        private bool _isLogin { get; set; } = true;

        public LoginController(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        // GET: LoginController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

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

                var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    var user = await _userManager.GetUserAsync(User);
                    userInforModel.FirstName = user.FirstName;
                    userInforModel.LastName = user.LastName;
                    userInforModel.Email = user.Email;
                    userInforModel.PhoneNumber = user.PhoneNumber;
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            userInforModel = null;
            return RedirectToAction("Index","Home");
        }
        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterModel register)
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
