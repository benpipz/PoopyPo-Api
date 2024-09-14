﻿namespace PoopyPoApi.Models.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public uint? PoopyScore { get; set; }
        public DateOnly? SignupDate { get; set; }
    }
}
