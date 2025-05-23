namespace A42.Planning.Domain.Helpers
{
    public static class DateHelper
    {
        public static DateOnly AsDate(this DateTimeOffset dateTimeOffset)
        {
            return new DateOnly(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day);
        }
    }
}
