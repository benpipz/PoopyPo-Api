namespace PoopyPoApi.Models.Domain
{
    public class PoopLocations
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Votes { get; set; }
        public DateOnly PoopDate { get; set; }
        public string UserId { get; set; }

        //Navigation property
        public User User { get; set; }
    }
}
