using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Servises.Services
{
    public class IsAdmin
    {
        public static bool RundAsAdmin()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}
