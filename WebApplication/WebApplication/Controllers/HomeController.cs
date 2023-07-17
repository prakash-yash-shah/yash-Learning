using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        ContextClass db = new ContextClass();
        public ActionResult Index()
        {
            var data = db.employee.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(EmployeeModel obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeModel emp = new EmployeeModel();
                    emp.EmpName = obj.EmpName;
                    emp.EmpEmail = obj.EmpEmail;
                    emp.EmpCity = obj.EmpCity;
                    emp.EmpGender = obj.EmpGender;
                    db.employee.Add(emp);
                    db.SaveChanges();
                    string jsonmsg = "Success";
                    return Json(jsonmsg, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Json("Failed", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(EmployeeModel obj)
        {
            try
            {

                var data = db.employee.Find(obj.EmpId);
                if (data != null)
                {
                    db.employee.Remove(data);
                    //db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    string jsonmsg = "Success";

                    return Json(jsonmsg, JsonRequestBehavior.AllowGet);

                }
                return Json(null, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Edit(int Id)
        {
            var data = db.employee.Where(x => x.EmpId == Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel obj)
        {
            EmployeeModel emp = db.employee.Where(x => x.EmpId == obj.EmpId).FirstOrDefault();
            if (emp != null)
            {
                emp.EmpName = obj.EmpName;
                emp.EmpEmail = obj.EmpEmail;
                emp.EmpCity = obj.EmpCity;
                emp.EmpGender = obj.EmpGender;
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
            string msg = "Changes Are Saved Successfully";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}