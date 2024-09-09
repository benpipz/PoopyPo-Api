using PoopyPoApi.Models.Domain;

namespace PoopyPoApi.Models.Dto
{
    public class LocationDto
    {
        public Guid? Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? Votes { get; set; }
        public Guid? UserId { get; set; }
        public DateOnly? PoopDate { get; set; }

        public string Uid { get; set; }
    }
}
