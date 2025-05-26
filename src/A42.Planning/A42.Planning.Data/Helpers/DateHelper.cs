namespace A42.Planning.Domain.Helpers
{
    public static class DateHelper
    {
        public static DateTimeOffset ToDateTimeOffset(this TimeOnly time, DateOnly date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, TimeSpan.Zero);
        }

        public static TimeOnly ToTimeOnly(this DateTimeOffset dateTimeOffset)
        {
            return new TimeOnly(dateTimeOffset.Hour, dateTimeOffset.Minute, dateTimeOffset.Second);
        }
    }
}
