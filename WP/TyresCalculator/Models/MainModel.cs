using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TyresCalculator.Models
{
    public class MainModel : NotifiableModel
    {
        public SpinnerModel ProtectorWidthModel
        {
            get
            {
                return new SpinnerModel()
                {
                    Values = new List<double?> { 135, 145, 155, 165, 175, 185, 195, 205, 215, 225, 235, 245, 255, 265, 275, 285 },
                    CurrentIndex = 4,
                    DefaultIndex = 4,
                    Header = string.Format("Protector{0}width", Environment.NewLine)
                };
            }
        }

        public SpinnerModel BoreDiameterModel
        {
            get
            {
                return new SpinnerModel()
                {
                    Values = new List<double?> { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 },
                    CurrentIndex = 1,
                    DefaultIndex = 1,
                    Header = string.Format("Bore{0}diameter", Environment.NewLine)
                };
            }
        }

        public SpinnerModel ProfileHeightModel
        {
            get
            {
                return new SpinnerModel()
                {
                    Header = string.Format("Profile{0}height, %", Environment.NewLine),
                    Values = new List<double?> { 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 },
                    CurrentIndex = 7,
                    DefaultIndex = 7
                };
            }
        }

        private int step;
        public int Step 
        {
            get { return step; }
            set 
            {
                step = value;
                NotifyPropertyChanged("BackEnabled");
                NotifyPropertyChanged("ForwardEnabled");
                NotifyPropertyChanged("PageTitle");
                NotifyPropertyChanged("AnalyzeVisibility");
                NotifyPropertyChanged("SpinnersVisibility");
            }
        }

        public bool BackEnabled
        {
            get
            { 
                return Step > 0; 
            }
        }

        public bool ForwardEnabled
        { 
            get 
            { 
                return Step < 2; 
            }
        }

        public Visibility AnalyzeVisibility 
        {
            get { return Step == 2 ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility SpinnersVisibility
        {
            get { return Step != 2 ? Visibility.Visible : Visibility.Collapsed; }
        }

        public string PageTitle 
        {
            get 
            {
                switch (Step) 
                {
                    case 0: return "factory values";
                    case 1: return "new values";
                    case 2: return "analyzing";
                }

                throw new ApplicationException("Unknown step");
            }
        }
    }
}
