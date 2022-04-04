namespace SocialNetwork.App.Model.Users
{
    public class ViewModel
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string? TelephoneNumber { get; set; }
        public DateOnly JoinDate { get; set; }
        public DateOnly BirthdayDate { get; set; }
        public sbyte? AllowInvites { get; set; }
        public string? WorkingPlace { get; set; }
        public string? LearningPlace { get; set; }
    }
}
