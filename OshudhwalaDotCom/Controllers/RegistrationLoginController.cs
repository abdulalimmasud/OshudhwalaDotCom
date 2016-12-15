using OshudhwalaDotCom.Core.BLL;
using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OshudhwalaDotCom.Controllers
{

    public class RegistrationLoginController : Controller
    {
        UserManager userManager = new UserManager();
        // GET: RegistrationLogin
        public ActionResult RegistrationLogin()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                
                int rowsAffected = userManager.AddUser(registration);
                if (rowsAffected > 0)
                {

                    Session["Registration"] = registration;
                    FormsAuthentication.SetAuthCookie(registration.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                return View("RegistrationLogin");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong.Make sure all the fields have been entered and that the password entered is atleast 8 characters long. Also make sure that the passwords match in both the fields and that no other account has been previously made with the email address you entered.");

                return View("RegistrationLogin");
            }
        }
        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            Login login = new Login();
            login.Email = Email;
            login.Password = Password;
            if (ModelState.IsValid)
            {
                Registration registration = userManager.LoginValidation(login);

                if (registration.Id != 0)
                {
                    Session["Registration"] = registration;
                    FormsAuthentication.SetAuthCookie(registration.Email, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            else
            {
                ModelState.AddModelError("", "Email and Password does not match.");

            }
            return View("RegistrationLogin");
        }
    }
}
