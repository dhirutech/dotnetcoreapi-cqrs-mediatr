using APICQRSMediatR.Security.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APICQRSMediatR.Security.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetAccessToken(string userName, string password);
    }
}
