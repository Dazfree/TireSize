using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresCalculator.Common;

namespace TyresCalculator.BusinessLogic
{
    public class InfluenceCalculator
    {
        public double? GetClearanceChange(double? oldTyreDiameter, double? newTyreDiameter) 
        {
            return oldTyreDiameter.HasValue && newTyreDiameter.HasValue
                ? newTyreDiameter / 2.0 - oldTyreDiameter / 2.0
                : null;
        }

        public double? GetRecommendedDiscHeight(double? height)
        {
            return height.HasValue ? (double?)Math.Round(height.Value / 25.4, 2) : null;
        }

        public double? GetRecommendedDiscWidth(double? protectorWidth)
        {
            return protectorWidth.HasValue 
                ? ((protectorWidth - 0.2 * protectorWidth)/ 25.4 * 2).Round() / 2
                : null;
        }
    }
}
