using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public static class Role
    {
        public const string Admin = "Admin";
        public const string Staff = "Staff";
        public const string User = "User";

        public static List<string> ListRoles = new List<string>() { Admin, Staff, User };
    }
}
