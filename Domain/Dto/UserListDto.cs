using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
   public class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rol { get; set; }
        public bool Status { get; set; }
        public Guid userkey { get; set; }

    }
}
