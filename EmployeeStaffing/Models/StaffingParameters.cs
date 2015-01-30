using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeStaffing.Models
{
    public class StaffingParameters
    {
        public DateTime StardDate { get; set; }
        public int Duration { get; set; }

        //just an hack for not having to do client side dynamic add
        public IEnumerable<EmployeeVacations> Vacations
        {
            get
            {
                if (Vacations1.StartDate != null && Vacations1.EndDate != null)
                    yield return Vacations1;
                if (Vacations2.StartDate != null && Vacations2.EndDate != null)
                    yield return Vacations2;
                if (Vacations3.StartDate != null && Vacations3.EndDate != null)
                    yield return Vacations3;
            }
        }

        public EmployeeVacations Vacations1 { get; set; }
        public EmployeeVacations Vacations2 { get; set; }
        public EmployeeVacations Vacations3 { get; set; }
        public string Locale { get; set; }
    }

    public class EmployeeVacations
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}