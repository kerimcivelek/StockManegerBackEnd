
namespace Domain.Entities
{
   public class User  :BaseEntity
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

   
        public Guid userkey { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string? Role { get; set; }
        public bool status { get; set; }
    }
}
