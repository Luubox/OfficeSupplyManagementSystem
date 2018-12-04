using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Common
{
    class StringToDoubleConverter
    {
        public static double ConvertToDouble(string value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                double result;
                double.TryParse(value, out result);

                if (double.IsNaN(result) || double.IsInfinity(result))
                {
                    return 0;
                }
                return result;
            }
        }
    }
}
