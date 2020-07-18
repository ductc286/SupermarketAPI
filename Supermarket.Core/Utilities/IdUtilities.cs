using System;

namespace Supermarket.Core.Utilities
{
    public class IdUtilities
    {
        private static DateTime _startDateTime = new DateTime(2020, 01, 01);

        //public static string GenerateByTimeSpan()
        //{
        //    var endDateTime = DateTime.Now;
        //    TimeSpan difference = endDateTime - _startDateTime;
        //    string result = Math.Round(difference.TotalMilliseconds).ToString();
        //    return result;
        //}
        public static string GenerateByTimeSpan()
        {
            var endDateTime = DateTime.Now;
            TimeSpan difference = endDateTime - _startDateTime;
            string timeSpanString = Math.Round(difference.TotalMinutes).ToString();
            Random random = new Random();
            var randomString = random.Next(100, 999);
            var result = timeSpanString + randomString;
            return result;
        }
    }
}
