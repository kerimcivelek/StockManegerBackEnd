

using Domain.Entities;

namespace Domain.Dto
{
    public class RegisterDto  :BaseEntity
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Guid userkey { get; set; }
        public bool status { get; set; }
        public string? Role { get; set; }
    }
}
