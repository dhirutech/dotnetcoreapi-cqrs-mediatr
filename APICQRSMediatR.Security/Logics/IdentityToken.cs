using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace APICQRSMediatR.Security.Logics
{
    public class IdentityToken
    {
        private readonly string _idToken;
        public IdentityToken(AuthenticationHeaderValue authorizationHeader)
        {
            if (authorizationHeader == null)
                throw new Exception("Error: Please provide valid authorization header.");

            _idToken = authorizationHeader.Parameter;
            AuthorizationHeader = authorizationHeader.Parameter;
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(_idToken) as JwtSecurityToken;
                var accessId = tokenS.Claims.First(claim => claim.Type == "userid").Value;
                UserId = new Guid(accessId);
                var accessRole = tokenS.Claims.First(claim => claim.Type == "role").Value;
                Role = accessRole;
            }
            catch (Exception e)
            {
                throw new Exception("Error processing person id from Authorization header.", e);
            }
        }

        public string AuthorizationHeader { get; }
        public Guid UserId { get; }
        public string Role { get; }
    }
}
