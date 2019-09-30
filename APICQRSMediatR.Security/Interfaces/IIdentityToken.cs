using System;
using System.Collections.Generic;
using System.Text;

namespace APICQRSMediatR.Security.Interfaces
{
    public class IIdentityToken
    {
        Guid UserId { get; }
        string Role { get; }
    }
}
