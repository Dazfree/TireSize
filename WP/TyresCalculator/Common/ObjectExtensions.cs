using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyresCalculator.Common
{
    public static class ObjectExtensions
    {
        public static double? ToDouble(this object obj)
        {
            if (obj == null)
                return null;

            return double.Parse(obj.ToString());
        }
    }
}
