using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PR01.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetHello()
        {
            Majo.WebService1 majo = new Majo.WebService1();

            ViewBag.Res = majo.HelloWorld();

            return View();



        }

        public ActionResult GetEmployee()
        {
            return View();
        }

        [HttpPost]
        public string GetDepartment(string nombre)
        {
            Majo.WebService1 majo = new Majo.WebService1();
            var dep =  majo.Deparments(nombre);
            return dep;
        }



    }
}