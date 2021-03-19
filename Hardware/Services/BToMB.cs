using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Services
{
    class BToMB
    {
        /// <summary>
        /// This function convert ram in form of bytes to megBytes. Return an float.
        /// </summary>
        public static string btomb(int bytesInput, int decimalPlaces = 1)
        {
            if (bytesInput < 0) { return "-"; }

            int i = 0;
            decimal dValue = (decimal)bytesInput;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue);
        }
    }
}
