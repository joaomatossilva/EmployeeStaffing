using System;
using System.Collections.Generic;
using System.Linq;
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays;

namespace EmployeeStaffing.Models
{
    //TODO: I should have been able to add this costumization on the WorkingDayCultureInfo I couldn't
    public class EmployeeStaffingWorkingDayCultureInfo : WorkingDayCultureInfo
    {
        public EmployeeStaffingWorkingDayCultureInfo(StaffingParameters parameters)
        {
            LocateHolidayStrategy = (name) => new EmployeeStaffingHolidayStrategy(parameters);
        }
    }

    //This is a simple decorator on top of an already existing Holiday Strategy
    //simply extending the IsHoliDay with a test on also the employee vacations
    public class EmployeeStaffingHolidayStrategy : IHolidayStrategy
    {
        private readonly StaffingParameters _parameters;
        private readonly IHolidayStrategy _innerHolidayStrategy;

        public EmployeeStaffingHolidayStrategy(StaffingParameters parameters)
        {
            _parameters = parameters;
            //TODO: There should be a better way to extend without needed to use the LocaleImplemetationLocator manually
            _innerHolidayStrategy = LocaleImplementationLocator.FindImplementationOf<IHolidayStrategy>(_parameters.Locale);
        }

        public IEnumerable<Holiday> GetHolidaysOfYear(int year)
        {
            return _innerHolidayStrategy.GetHolidaysOfYear(year);
        }

        public bool IsHoliDay(DateTime day)
        {
            return _innerHolidayStrategy.IsHoliDay(day) ||
                   (_parameters.Vacations != null && _parameters.Vacations.Any(x => day >= x.StartDate && day <= x.EndDate));
        }

        public IEnumerable<Holiday> Holidays
        {
            get
            {
                return _innerHolidayStrategy.Holidays;
            }
        }
    }
}