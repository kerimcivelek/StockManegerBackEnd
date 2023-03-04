using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public Guid userkey { get; set; }
      
    }
}
