using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyresCalculator.Common
{
    public static class DoubleExtensions
    {
        public static double? InchesToMilimeters(this double? inches) 
        {
            if (!inches.HasValue)
                return null;

            return inches * 25.4;
        }

        public static double? RoundedInchesToMilimeters(this double? inches)
        {
            if (!inches.HasValue)
                return null;

            var value = inches * 25.4;
            return value.Round();
        }

        public static double? MilimetersToInches(this double? mms)
        {
            if (!mms.HasValue)
                return null;

            var value = mms / 25.4;
            return value.Round();
        }

        public static double? Round(this double? value) 
        {
            if (!value.HasValue)
                return null;

            double intValue = (int)value;
            return value - intValue >= 0.5
                ? ++intValue : intValue;
        }
    }
}
