using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PumpsProjectWebsite.Helpers
{
    public static class Role
    {

        public const string Admin = "Admin";
        public const string SecurityGuard = "SecurityGuard";
        public const string Programmer = "Programmer";
        public const string Advisor = "Advisor";
        public const string Researcher = "Researcher";

        public static List<string> Heirarchy = new List<string>
        {
            Role.Admin,
            Role.SecurityGuard,
            Role.Programmer,
            Role.Advisor,
            Role.Researcher
            
        };
    }
}
