namespace PoopyPoApi.Models.Domain
{
    public class User
    {
        public string Id { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string? Email { get; set; }
        public uint PoopyScore { get; set; }
        public DateOnly SignupDate { get; set; }
    }
}
