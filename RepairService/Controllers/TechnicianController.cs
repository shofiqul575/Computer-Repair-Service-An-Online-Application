using RepairService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairService.Controllers
{
    public class TechnicianController : Controller
    {

        RepairServiceEntities dbrs = new RepairServiceEntities();
        // GET: Technician
        public ActionResult Index()
        {
            int tid = Convert.ToInt32(Session["tid"]);
            if (Session["tid"] == null)
            {
                return RedirectToAction("TechLogin", "Technician");

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult TechSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TechSignUp(Technician technician)
        {
   
                    var existscheck = dbrs.Technicians.Any(x => x.Phone == technician.Phone);
                    if (existscheck)
                    {
                        ModelState.AddModelError("Phone", "Phone Number Already Resgistered");
                        return View(technician);
                    }
                    dbrs.Technicians.Add(technician);
                    dbrs.SaveChanges();
                    ModelState.Clear();
            //}

                return RedirectToAction("TechLogin");
        }
           

        [HttpGet]
        public ActionResult TechLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TechLogin(Technician technician)
        {
            //if (ModelState.IsValid == true)
            //{

                var IsValid = dbrs.Technicians.Where(x => x.Phone.Equals(technician.Phone) && x.Password.Equals(technician.Password)).FirstOrDefault();
                if (IsValid!=null)
                {
                 Session["tid"] = IsValid.Tid;
                
                //TempData["SuccessMsg"] = "<script>alert('Login Sucessfull..!!')</script>";
                return RedirectToAction("Index", "Technician");
                }
            //}

            ModelState.AddModelError("", "Invalid Data Input Please Input Correct Information");
            return View(technician);
        }

        public ActionResult AssignedProblem()
        {
            int tid = Convert.ToInt32(Session["tid"]);
            if (Session["tid"] == null)
            {
                return RedirectToAction("TechLogin", "Technician");

            }
            else
            {
                return View(dbrs.AssignProblems.Where(x => x.techid == tid).ToList());
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}