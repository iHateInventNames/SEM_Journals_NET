using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SEM.Core
{
    public static class Roles
    {
        static Roles()
        {
            if (!System.Web.Security.Roles.RoleExists(Publisher))
                System.Web.Security.Roles.CreateRole(Publisher);
        }

        public const string Publisher = "Publisher";
    }
}
