using Microsoft.AspNetCore.Mvc;
using TestCRUD.Data;
using TestCRUD.Models;

namespace TestCRUD.Controllers
{
    public class CredentialsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CredentialsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            var credentials = _context.Credentials.ToList();
            return View(credentials);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login(string userlog, string passwordlog)
        {
            var existingUser = _context.Credentials.FirstOrDefault(x => x.Username == userlog);
            if (existingUser == null)
            {
                TempData["UserNull"] = "Username Not Found";
                return View("Login");
            }
            if (existingUser.Password != passwordlog)
            {
                TempData["PasswordIncorrect"] = "Incorrect Password";
                return View("Login");
            }
            string loggedUser = existingUser.Username.ToString();
            string userType = existingUser.Usertype.ToString();

            HttpContext.Session.SetString("Username", loggedUser);
            HttpContext.Session.SetString("Usertype", userType);

            TempData["SuccessMessage"] = "Welcome To Root! " + loggedUser;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(Credentials addCredentials)
        {
            var existingUser = _context.Credentials.FirstOrDefault(x => x.Username == addCredentials.Username);
            if (existingUser != null)
            {
                TempData["UsernameExists"] = "Username Already Exists";
                return RedirectToAction("Register");
            }


            RegisterUser(addCredentials);
            TempData["SuccessMessage"] = "Registration Successful! You may know Login to your account.";

            return RedirectToAction("Login");
        }

        public void RegisterUser(Credentials addCredentials)
        {
            var credentials = new Credentials()
            {
                Username = addCredentials.Username,
                Usertype = addCredentials.Usertype,
                Password = addCredentials.Password,
            };
            _context.Credentials.Add(addCredentials);
            _context.SaveChanges();
        }
    }
}
