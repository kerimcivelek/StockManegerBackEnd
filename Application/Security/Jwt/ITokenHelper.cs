using Domain.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
 
    }
}
