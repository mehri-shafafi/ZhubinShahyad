using System.Globalization;

namespace Products.Domain.Common.Extensions
{

    public static class DateTimeExtensions
    {
        public static string ToShamsiString(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime):00}/{pc.GetDayOfMonth(dateTime):00} " +
                   $"{pc.GetHour(dateTime):00}:{pc.GetMinute(dateTime):00}:{pc.GetSecond(dateTime):00}";
        }
    }
}
