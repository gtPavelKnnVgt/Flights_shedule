
namespace Staff.Extentions
{
    public static class IntExtentions
    {
        public static bool IsNegative(this int value) => value < 0 ;
        public static int? SeatRange(this int value) => value > 700 || value < 100 ? null : (int?)value;
        public static int? NullOrNegative(this int value)
        {
            return value.IsNegative() || (int?)value is null ? null : (int?)value;
        }
    }
}
