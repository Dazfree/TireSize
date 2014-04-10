using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresCalculator.Models;

namespace TyresCalculator.Metadata
{
    public class SettingsItem : NotifiableModel
    {
        public Guid Key { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        private double? old;
        public double? Old 
        {
            get { return old; }
            set
            {
                if (old != value) 
                {
                    old = value;
                    NotifyPropertyChanged("Old");
                    NotifyPropertyChanged("Difference");
                }
            }
        }

        private double? newVal;
        public double? New 
        {
            get { return newVal; }
            set
            {
                if (newVal != value)
                {
                    newVal = value;
                    NotifyPropertyChanged("New");
                    NotifyPropertyChanged("Difference");
                }
            }
        }

        public object Difference 
        {
            get 
            {
                return Old.HasValue && New.HasValue
                    ? New - Old
                    : null;
            }
        }
    }
}
