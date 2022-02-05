using RepairService.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepairService.Controllers
{
    public class AdminController : Controller
    {

        RepairServiceEntities db = new RepairServiceEntities();
        // GET: Admin
        public ActionResult DashBoard()
        {
            if (Session["aid"] == null)
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            else
            {
                return View(db.Problems.ToList());
            }
                     
        }

        public ActionResult TechList()
        {
            if (Session["aid"] == null)
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            else
            {

                return View(db.Technicians.ToList());
            }

        }
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin( Admin admin)
        {
            var IsValid = db.Admins.Where(x => x.Email.Equals(admin.Email) && x.Password.Equals(admin.Password)).FirstOrDefault();
            if (IsValid!=null)
            {
                Session["aid"] = IsValid.Aid;
                //TempData["SuccessMsg"] = "<script>alert('Login Sucessfull..!!')</script>";
                return RedirectToAction("DashBoard", "Admin");
            }
            ModelState.AddModelError("", "Please Enter Correct Information..!");

            return View();
        }

        public ActionResult AdminSignUp()
        {
            if (Session["aid"] == null)
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminSignUp(Admin admin)
        {
            if (ModelState.IsValid == true)
            {
               var echeck = db.Admins.Any(x => x.Email == admin.Email);
                if (echeck)
                {
                    ModelState.AddModelError("Email","Email Already Resgistered");
                    return View(admin);
                }

                
                db.Admins.Add(admin);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["SuccessMsg"] = "<script>alert('Registration Sucessfull..!!')</script>";
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Somethings is wrong..!!')</script>";
                }
            }
            ModelState.Clear();
            return RedirectToAction("DashBoard", "Admin", null);
        }

        public ActionResult AddNewTech()
        {
            if (Session["aid"] == null)
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewTech(Technician technician)
        {
            if (ModelState.IsValid == true)
            {
                var echeck = db.Technicians.Any(x => x.Phone == technician.Phone);
                if (echeck)
                {
                    ModelState.AddModelError("Email", "Email Already Resgistered");
                    return View(technician);
                }
                db.Technicians.Add(technician);
                int a= db.SaveChanges();
                if (a > 0)
                {
                    TempData["SuccessMsg"] = "<script>alert('Registration Sucessfull..!!')</script>";
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Somethings is wrong..!!')</script>";
                }
                ModelState.Clear();
            }
            return RedirectToAction("DashBoard","Admin",null);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Session["pid"] = id;
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            var url = Url.RequestContext.RouteData.Values["id"];
            Session["pid"] = url;
            return View(problem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problem problem = db.Problems.Find(id);
            db.Problems.Remove(problem);
            db.SaveChanges();
            return RedirectToAction("DashBoard");
        }

        public ActionResult Assign(int id)
        {
            
            //int probid = Convert.ToInt32(Session["pid"]);
            var probid =Convert.ToInt32( Session["pid"]);

            Problem problem = db.Problems.Find(probid);

            dynamic prob = new AssignProblem();
            prob.ProblemName = problem.Problem_type;
            prob.DeviceName = problem.Device;
            prob.BrandName = problem.BrandName;
            prob.ProblemDescription = problem.ProblemDescription;
            prob.probid = problem.Pid;
            prob.techid = id;
            if (prob != null)
            {
                db.AssignProblems.Add(prob);
                db.SaveChanges();
                return RedirectToAction("TechList", "Admin");
            }
            return View();
            
            
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("AdminLogin","Admin");
        }
    }
}