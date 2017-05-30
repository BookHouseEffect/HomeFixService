using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Security
{
    public class HashedAndSaltedPassword
    {
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}