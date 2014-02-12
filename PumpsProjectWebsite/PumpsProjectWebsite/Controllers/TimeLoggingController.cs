using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PumpsProjectWebsite.Repository;

namespace PumpsProjectWebsite.Controllers
{
    public class TimeLoggingController : Controller
    {

        public ActionResult Index()
        {
            var model = new TimeLogRepository(User).LoadTimeLog();
            return View("Index", "_emptyLayout",model);
        }

        public JsonResult ClockIn()
        {
            Boolean Success = false;
            String Error = "";

            if (new TimeLogRepository(User).ClockIn())
            {
                Success = true;
            }
            else
            {
                Error="System was unable to clock-in user.";
            }
            return Json(new { Success = Success, Error = Error });
        }

        public JsonResult ClockOut()
        {
            Boolean Success = false;
            String Error = "";

            if (new TimeLogRepository(User).ClockOut())
            {
                Success = true;
            }
            else
            {
                Error = "System was unable to clock-out user.";
            }
            return Json(new { Success = Success, Error = Error });
        }
    }
}
