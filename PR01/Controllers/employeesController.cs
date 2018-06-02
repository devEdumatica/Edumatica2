using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PR01.Models;
using Rotativa;
using Newtonsoft.Json;


namespace PR01.Controllers
{
    public class employeesController : Controller
    {
        private edumaticaEntities db = new edumaticaEntities();

        // GET: employees
        public ActionResult Index()
        {
            var employee = db.employee.Include(e => e.department);
            ViewBag.listEmp = db.employee.ToList();
            return View(employee.ToList());
            

        }

        // GET: employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);

        }

        // GET: employees/Create
        public ActionResult Create()
        {
            ViewBag.department_id = new SelectList(db.department, "id", "descripcion");
            return View();
        }

        // POST: employees/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,direccion,telefono,department_id")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.department_id = new SelectList(db.department, "id", "descripcion", employee.department_id);
            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.department_id = new SelectList(db.department, "id", "descripcion", employee.department_id);
            return View(employee);
        }

        // POST: employees/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,direccion,telefono,department_id")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.department_id = new SelectList(db.department, "id", "descripcion", employee.department_id);
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employee.Find(id);
            db.employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult printEmployee()
        {
            var obj = new ActionAsPdf("index");
            return obj;

        }







        public ActionResult employeePdf(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var res = db.employee.Where(x => x.id == id);
            return PartialView("_DetailsEmp", (IEnumerable<PR01.Models.employee>)res);

        }



        public ActionResult printEmployeeDetails(int id)
        {
            var obj = new ActionAsPdf("employeePdf/" + id);
            return obj;

        }




        public ActionResult chart1()
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings()
            { NullValueHandling = NullValueHandling.Ignore };

            var char01 = (from Employee in db.employee
                          select new
                          {
                              Employee.id,
                              Employee.nombre,
                              Employee.direccion,
                              Employee.telefono
                          });

            ViewBag.DataPoints = JsonConvert.SerializeObject(char01.ToList(), jsonSetting);

            return View("view_char1");
        }

        public ActionResult chart2()
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings()
            { NullValueHandling = NullValueHandling.Ignore };

            var char01 = (from Employee in db.employee
                          select new
                          {
                              Employee.id,
                              Employee.nombre,
                              Employee.direccion,
                              Employee.telefono
                          });

            ViewBag.DataPoints = JsonConvert.SerializeObject(char01.ToList(), jsonSetting);

            return View("view_chart2");
        }


        public ActionResult chart3()
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings()
            { NullValueHandling = NullValueHandling.Ignore };

            var char01 = (from Employee in db.employee
                          select new
                          {
                              Employee.id,
                              Employee.nombre,
                              Employee.direccion,
                              Employee.telefono
                          });

            ViewBag.DataPoints = JsonConvert.SerializeObject(char01.ToList(), jsonSetting);

            return View("view_chart3");
        }


    }
}
