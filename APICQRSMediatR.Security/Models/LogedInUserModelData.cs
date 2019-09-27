using System;
using System.Collections.Generic;
using System.Text;

namespace APICQRSMediatR.Security.Models
{
    public class LogedInUserModelData
    {
        public readonly IEnumerable<User> _userList = new List<User>
        {
            new User { UserId = Guid.NewGuid(), UserName = "Admin", Password = "Admin", FirstName = "Dhiraj", LastName = "Bairagi", Role = "Administrator"},
            new User { UserId = Guid.NewGuid(), UserName = "L1User", Password = "L1User", FirstName = "Subham", LastName = "Kumar", Role = "Analyst"},
            new User { UserId = Guid.NewGuid(), UserName = "L2User", Password = "L2User", FirstName = "Rajesh", LastName = "Pandit", Role = "Analyst"},
            new User { UserId = Guid.NewGuid(), UserName = "User", Password = "User", FirstName = "Sujeet", LastName = "Kumar", Role = "User"}
        };
    }
}
