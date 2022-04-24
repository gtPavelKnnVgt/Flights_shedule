
namespace Staff.Extentions
{
    public enum AirCraftRoomChecker
    {
        MaxSeats = 1000,
        MinSeats = 100,
        MinIdentificationNumber = 0,
        MinTicketPrice = 2000,
        MaxTicketPrice = 100000
    }
    public static class IntExtentions
    {
        public static bool IsPassedSeatRange(this int value) 
            => value >= (int)AirCraftRoomChecker.MinSeats && value <= (int)AirCraftRoomChecker.MaxSeats;

        public static bool IsPassedIdentificationCheck(this int value)
            => value >= (int)AirCraftRoomChecker.MinIdentificationNumber;

        public static bool IsPassedTicketPriceCheck(this int value)
            => value >= (int)AirCraftRoomChecker.MinTicketPrice && value <= (int)AirCraftRoomChecker.MaxTicketPrice;
        
    }
}
