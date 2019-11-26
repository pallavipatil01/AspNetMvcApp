using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpDetail.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;



namespace EmpDetail.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        public ActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objemployee.GetAllEmployees().ToList();
            return View(lstEmployee);
        }

        [HttpGet]
        public ActionResult Add() { return View(); }

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Add([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                objemployee.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            
            Employee employee = objemployee.GetEmployeeData(id);
            if (employee == null)
                return HttpNotFound();
            return View(employee);
        }
        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]Employee employee)
        {
            if (id != employee.ID)
              return HttpNotFound();
            if (ModelState.IsValid)
            {
                objemployee.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Employee employee = objemployee.GetEmployeeData(id);
            if (employee == null)
                return HttpNotFound();
            return View(employee);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Employee employee = objemployee.GetEmployeeData(id);
            if (employee == null)
                return HttpNotFound();
             return View(employee);
        }
        [HttpPost, ActionName("Delete")] [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            objemployee.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}