using System;

namespace Supermarket.Core.Utilities
{
    public class DateTimeUtilities
    {

        public static void GetIntervalToDay(ref DateTime fromDate, ref DateTime toDate)
        {
            var currentDate = DateTime.Now;
            fromDate = currentDate;
            toDate = currentDate;
        }

        public static void GetIntervalThisMonth(ref DateTime fromDate, ref DateTime toDate)
        {
            var currentDate = DateTime.Now;
            fromDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            toDate = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));
        }

        public static void GetIntervalThisYear(ref DateTime fromDate, ref DateTime toDate)
        {
            var currentDate = DateTime.Now;
            fromDate = new DateTime(currentDate.Year, 1, 1);
            toDate = new DateTime(currentDate.Year, 12, 31);
        }
    }
}
