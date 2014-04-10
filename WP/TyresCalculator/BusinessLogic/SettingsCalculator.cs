using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresCalculator.Common;

namespace TyresCalculator.BusinessLogic
{
    public class SettingsCalculator
    {
        public double? GetMmBoreDiameter(double? inchesBoreDiameter) 
        {
            return inchesBoreDiameter.HasValue
                ? inchesBoreDiameter.RoundedInchesToMilimeters()
                : null;
        }

        public double? GetBoreInchDiameter(double? mmBoreDiameter) 
        {
            return mmBoreDiameter.HasValue
                ? mmBoreDiameter.MilimetersToInches()
                : null;
        }

        public double? GetRoundedProfileHeight(double? protectorWidth, double? percents) 
        {
            return protectorWidth.HasValue && percents.HasValue
                ? (protectorWidth * percents / 100.0).Round()
                : null;
        }

        public double? GetProfileHeight(double? protectorWidth, double? percents)
        {
            return protectorWidth.HasValue && percents.HasValue
                ? (protectorWidth * percents / 100.0)
                : null;
        }

        public double? GetProfileHeightPercents(double? protectorWidth, double? profileHeight)
        {
            return protectorWidth.HasValue && profileHeight.HasValue
                ? (100.0 * profileHeight / protectorWidth).Round()
                : null;
        }

        public double? GetTyreDiameter(double? protectorWidth, double? percents, double? inchesBoreDiameter) 
        {
            return protectorWidth.HasValue && percents.HasValue && inchesBoreDiameter.HasValue
                ? (inchesBoreDiameter.InchesToMilimeters() + GetProfileHeight(protectorWidth * 2.0, percents)).Round()
                : null;
        }
    }
}
