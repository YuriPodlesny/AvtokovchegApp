namespace AvtokovchegApp.Domain
{
    public class ParkingSpace
    {
        public int Id { get; set; }
        public int Namber { get; set; }
        public bool IsFree { get; set; } = false;
    }
}