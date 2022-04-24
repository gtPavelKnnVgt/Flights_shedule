

namespace Staff.Extentions
{
    public enum AirplaneChecker
    {
        MaxWeight = 9000,
        MinWeight = 50,
        MaxFlightRange = 20000,
        MinFlightRange = 1000,
        MaxSize = 2000,
        MinSize = 100
    }

    public static class DoubleExtentions
    {
        public static bool IsPassedWeightCheck(this double value)
            => value >= (double)AirplaneChecker.MinWeight && value <= (double)AirplaneChecker.MaxWeight;
        public static bool IsPassedFlightRangeCheck(this double value)
            => value >= (double)AirplaneChecker.MinFlightRange && value <= (double)AirplaneChecker.MaxFlightRange;
        public static bool IsPassedSizeCheck(this double value)
            => value >= (double)AirplaneChecker.MinSize && value <= (double)AirplaneChecker.MaxSize;
    }
}
