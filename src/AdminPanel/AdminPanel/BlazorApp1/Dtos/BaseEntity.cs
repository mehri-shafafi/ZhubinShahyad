using System.Globalization;

namespace BlazorApp.Dtos
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModificationDateTime { get; set; } = DateTime.UtcNow;
        public string CreationDateTimeShamsi { get; set; } = DateTime.UtcNow.ToShamsiString();
        public string ModificationDateTimeShamsi { get; set; } = DateTime.UtcNow.ToShamsiString();

    }

    public abstract class BaseEntity : BaseEntity<int>
    {

    }
    public static string ToShamsiString(this DateTime dateTime)
    {
        PersianCalendar pc = new PersianCalendar();
        return $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime):00}/{pc.GetDayOfMonth(dateTime):00} " +
               $"{pc.GetHour(dateTime):00}:{pc.GetMinute(dateTime):00}:{pc.GetSecond(dateTime):00}";
    }
}
