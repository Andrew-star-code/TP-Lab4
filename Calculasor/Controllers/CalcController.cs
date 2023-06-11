using Calculasor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculasor.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            ViewBag.Compare = 10;
            return View();
        }
        public ActionResult ActionView()
        {
            ViewBag.Transfer = HttpContext.Request.Cookies["ResultCookieTransfer"].Value;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Calc c, string actionButton)
        {
            ViewBag.Compare = 10;
            byte Operand1 = c.Operand1;
            byte Operand2 = c.Operand2;
            float Result = 0;
            string Operation = c.Operation;
            switch (Operation)
            {
                case "+":
                    Result = Operand1 + Operand2;
                    break;
                case "-":
                    Result = Operand1 - Operand2;
                    break;
                case "*":
                    Result = Operand1 * Operand2;
                    break;
                case "/":
                    Result = Convert.ToSingle(Operand1) / Convert.ToSingle(Operand2);
                    break;
            }
            ViewBag.Result = Result;
            string ResultCoke = Operand1.ToString() + " " + Operation + " " + Operand2.ToString() + " = " + Result.ToString();
            ResultCoke = ResultCoke.Replace("=", "equals");
            ResultCoke = ResultCoke.PadRight(1);
            HttpContext.Response.Cookies["ResultCookieTransfer"].Value = Convert.ToString(ResultCoke);

            if (actionButton == "Cleanup")
            {
                ModelState.Clear();

                c.Operand1 = 0;
                c.Operand2 = 0;
                c.Operation = null;
                ViewBag.Result = 0;
            }

            return View();

        }

        
    }
}