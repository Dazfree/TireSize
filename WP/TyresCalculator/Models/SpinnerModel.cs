using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyresCalculator.Models
{
    public class SpinnerModel : NotifiableModel
    {
        public SpinnerModel()
        {
        }

        private string header;
        public string Header 
        {
            get { return header; }
            set 
            {
                header = value;
                NotifyPropertyChanged("Header");
            }
        }

        private IEnumerable<double?> values;
        public IEnumerable<double?> Values
        {
            set
            {
                values = value;
                CurrentIndex = values == null || !values.Any() ? -1 : DefaultIndex;
            }
        }

        public int DefaultIndex { get; set; }

        private int currentIndex = -1;
        public int CurrentIndex 
        {
            get 
            {
                return currentIndex;
            }
            set 
            {
                if ((values == null || !values.Any()) && value > -1)
                    throw new ArgumentOutOfRangeException("CurrentIndex");

                if (values != null && value >= values.Count())
                    throw new ArgumentOutOfRangeException("CurrentIndex");

                currentIndex = value;
                NotifyPropertyChanged("CurrentItem");
                NotifyPropertyChanged("DecreaseEnabled");
                NotifyPropertyChanged("IncreaseEnabled");
            }
        }

        public double? CurrentItem 
        {
            get 
            {
                if (values == null || !values.Any() || CurrentIndex < 0)
                    return null;

                return values.ElementAt(CurrentIndex);
            }
            set 
            {
                var index = values.ToList().IndexOf(value);
                CurrentIndex = index == -1 ? DefaultIndex : index;
            }
        }

        public bool DecreaseEnabled 
        {
            get { return currentIndex > 0; }
        }

        public bool IncreaseEnabled 
        {
            get { return values != null && currentIndex > -1 && currentIndex < values.Count() - 1; }
        }
    }
}
