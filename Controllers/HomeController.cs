using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hr_Management_System.Models;

namespace Hr_Management_System.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]

        public ActionResult Login(login lg)
        {
           
            Session["name"] = lg.name;
            if (ModelState.IsValid)
            {
                using (AdminEntities ae = new AdminEntities())
                {
                    var log = ae.logins.Where(a => a.name.Equals(lg.name) && a.password.Equals(lg.password)).FirstOrDefault();

                   
                 
                    if (log != null)
                    {
                        
                        return RedirectToAction("Index", "Employees");
                    }
                    else
                    {
                        Response.Write("<script> alert('Invalid name or password')</script>");
                    }

                }

            }
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult AccountsHome()
        {
            return View();
        }
    }
   
}