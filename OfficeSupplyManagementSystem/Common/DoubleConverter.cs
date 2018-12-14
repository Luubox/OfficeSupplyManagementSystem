using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Common
{
    class DoubleConverter
    {
        /// <summary>
        /// Converts the input string to a double
        /// </summary>
        /// <param name="value">String to be converted to double</param>
        /// <returns>String value converted to a double</returns>
        public static double ConvertStringToDouble(string value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                double.TryParse(value, out var result);

                if (double.IsNaN(result) || double.IsInfinity(result))
                {
                    return 0;
                }
                return result;
            }
        }
    }
}
