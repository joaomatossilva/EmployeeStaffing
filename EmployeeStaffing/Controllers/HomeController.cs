using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateTimeExtensions;
using EmployeeStaffing.Models;

namespace EmployeeStaffing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new StaffingResultViewModel
                        {
                            Parameters = new StaffingParameters
                                         {
                                             StardDate = DateTime.Today,
                                             Duration = 10
                                         }
                        });
        }

        [HttpPost]
        public ActionResult Index(StaffingParameters parameters)
        {
            var employeeCultureInfo = new EmployeeStaffingWorkingDayCultureInfo(parameters);
            var endDate = parameters.StardDate.AddWorkingDays(parameters.Duration, employeeCultureInfo);

            var model = new StaffingResultViewModel
                        {
                            EndDate = endDate,
                            Parameters = parameters
                        };
            return View(model);
        }

    }
}