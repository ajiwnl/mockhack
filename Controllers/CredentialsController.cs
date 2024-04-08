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
		[ActionName("Name")]
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
			if(existingUser != null)
			{
                TempData["EmailExists"] = "Email Already Exists";
                return RedirectToAction("Register");
            }

			try
			{
				RegisterUser(addCredentials);
                TempData["SuccessMessage"] = "Registration Successful! You may know Login to your account.";
            }catch(Exception ex)
			{
                TempData["ErrorMessage"] = "Failed to send verification email. Please try again later.";
                return RedirectToAction("Register");
            }

            return RedirectToAction("Login");
        }

		public void RegisterUser(Credentials addCredentials)
		{
			_context.Credentials.Add(addCredentials);
			_context.SaveChanges();
		}
	}
}
