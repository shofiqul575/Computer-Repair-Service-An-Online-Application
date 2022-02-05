using Microsoft.AspNet.Identity;
using RepairService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RepairService.Controllers
{
    
    public class UserController : Controller
    {
        RepairServiceEntities dbrs = new RepairServiceEntities();
        // GET: User
       
        public ActionResult Index()
        {
            int uid =Convert.ToInt32( Session["uid"]);
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "User");

            }
            else
            {

                return View(dbrs.Problems.Where(x => x.userid == uid).ToList());
            }
         
        }
        
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if(ModelState.IsValid== true)
            {
                var echeck = dbrs.Users.Any(x => x.Email == user.Email);
                if (echeck)
                {
                    ModelState.AddModelError("Email", "Email Already Resgistered");
                    return View(user);
                }
                dbrs.Users.Add(user);
                int a= dbrs.SaveChanges();
                if (a > 0)
                {
                    
                    ViewBag.InsertMessage = "<script> alert('Registration Sucessfull..!!') </script>";
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Somethings is wrong..!!')</script>";
                }
            }
            
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UId,Name,Email,Phone,Password")] User user)
        {
            //if (ModelState.IsValid == true)
            //{
                var IsValid = dbrs.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (IsValid!=null)
                {           
                Session["uid"] = IsValid.UId;

                int latestid = IsValid.UId;
       
                //TempData["SuccessMsg"] = "<script>alert('Login Sucessfull..!!')</script>";
                    return RedirectToAction("Index", "User"/*, new { id =latestid }*/);
                }
            //}
    
            ModelState.AddModelError("", "Please Enter Correct Information..!");
            
            return View();
        }
        
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Problems1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pid,Problem_type,Device,BrandName,ProblemDescription,userid")] Problem problem, int id)
        {
            if (ModelState.IsValid)
            {
                problem.userid = id;
                dbrs.Problems.Add(problem);
                dbrs.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            return View(problem);
        }     
       
    }
}