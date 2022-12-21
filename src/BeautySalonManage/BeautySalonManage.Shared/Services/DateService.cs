using BeautySalonManage.Application.Interfaces;
using NodaTime;

namespace BeautySalonManage.Shared.Services
{
    public class DateService : IDateService
    {
        public DateTime LocalTimeNow()
        {
            Instant now = SystemClock.Instance.GetCurrentInstant();

            DateTimeZone tzt = DateTimeZoneProviders.Tzdb.GetZoneOrNull("America/Bogota");

            ZonedDateTime zdt = now.InZone(tzt);

            return new DateTime(zdt.LocalDateTime.Year, zdt.LocalDateTime.Month, zdt.LocalDateTime.Day, zdt.LocalDateTime.Hour, zdt.LocalDateTime.Minute, zdt.LocalDateTime.Second, zdt.LocalDateTime.Millisecond);
        }
    }
}
