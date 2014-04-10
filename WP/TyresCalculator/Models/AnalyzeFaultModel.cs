using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresCalculator.Common;

namespace TyresCalculator.Models
{
    public class AnalyzeFaultModel : NotifiableModel
    {
        private double? statement;
        public double? Statement 
        {
            get { return statement; }
            set 
            {
                if (this.statement != value) 
                {
                    this.statement = value;
                    NotifyPropertyChanged("Statement");
                    NotifyPropertyChanged("Real");
                    NotifyPropertyChanged("Difference");
                }
            }
        }

        private DoublePair tyreDiameter;
        public DoublePair TyreDiameter 
        {
            get { return tyreDiameter; }
            set 
            {
                if (tyreDiameter != value) 
                {
                    tyreDiameter = value;
                    NotifyPropertyChanged("Real");
                    NotifyPropertyChanged("Difference");
                }
            }
        }

        public double? Real 
        {
            get 
            {
                if (!Statement.HasValue)
                    return null;

                if (TyreDiameter == null || !TyreDiameter.Item1.HasValue || !TyreDiameter.Item2.HasValue)
                    return null;

                var result = (((TyreDiameter.Item2 * 0.01) / (TyreDiameter.Item1 * 0.01)) * Statement * 100.0).Round() / 100.0;
                return Math.Round(result.Value, 2);
            }
        }

        public double? Difference 
        {
            get 
            {
                var real = Real;
                return Statement.HasValue && real.HasValue
                    ? (double?)Math.Round(real.Value - Statement.Value, 2)
                    : null;
            }
        }
    }
}
