using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Servises.Services
{
    public class IsAdmin
    {
        /// <summary>
        /// Returning an bool if the program is running as admin / sudo.
        /// </summary>
        /// <returns></returns>
        public static bool RundAsAdmin()
        {
            try
            {
                using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                {
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
