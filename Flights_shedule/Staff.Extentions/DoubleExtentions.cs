

namespace Staff.Extentions
{
    public static class DoubleExtentions
    {
        public static bool IsNegative(this double value) => double.IsNegative(value);
        public static double? WeightCheck(this double value) => value > 90000 || value < 5000 ? null : (double?) value;
        public static double? FlightRangeCheck(this double value) => value < 1000 || value > 20000 ? null : (double?)value; 
        public static double? NullOrNegative(this double value)
        {
            return value.IsNegative() || (double?)value is null ? null : (double?)value;
        }
    }
}
