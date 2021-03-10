using System;
using System.Collections.Generic;
using System.Text;

namespace Servises.Modells
{
    public class GetOsInfo
    {
        public static OSInfoModell GetOS()
        {
            OSInfoModell r = new OSInfoModell();

            OperatingSystem os_info = System.Environment.OSVersion;

            Version ver = os_info.Version;

            r.OsVersion = os_info.VersionString;
            r.OsName = GetOsName(os_info);
            r.OsMajorVersion = ver.Major.ToString();

            return r;
        }

        // Return the OS name.
        private static string GetOsName(OperatingSystem os_info)
        {
            string version =
                os_info.Version.Major.ToString() + "." +
                os_info.Version.Minor.ToString();
            switch (version)
            {
                case "10.0": return "10 / Server 2016";
                case "6.3": return "8.1 / Server 2012 R2";
                case "6.2": return "8 / Server 2012";
                case "6.1": return "7 / Server 2008 R2";
                case "6.0": return "Server 2008 / Vista";
                case "5.2": return "Server 2003 R2 / Server 2003 / XP 64-Bit Edition";
                case "5.1": return "XP";
                case "5.0": return "2000";
            }
            return "Unknown";
        }
    }
}
