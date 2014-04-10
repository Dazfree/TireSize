using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresCalculator.Common;

namespace TyresCalculator.Models
{
    public class AnalyzeModel : NotifiableModel
    {
        private double? clearanceChange;
        public double? ClearanceChange 
        {
            get { return clearanceChange; }
            set 
            {
                if (clearanceChange != value) 
                {
                    clearanceChange = value;
                    NotifyPropertyChanged("ClearanceChange");
                }
            }
        }

        private double? recommendedDiscWidth;
        public double? RecommendedDiscWidth 
        {
            get { return recommendedDiscWidth; }
            set 
            {
                if (recommendedDiscWidth != value) 
                {
                    recommendedDiscWidth = value;
                    NotifyPropertyChanged("RecommendedDiscWidth");
                }
            }
        }

        private double? recommendedDiscHeight;
        public double? RecommendedDiscHeight
        {
            get { return recommendedDiscHeight; }
            set
            {
                if (recommendedDiscHeight != value)
                {
                    recommendedDiscHeight = value;
                    NotifyPropertyChanged("RecommendedDiscHeight");
                }
            }
        }

        private AnalyzeFaultModel speedModel = new AnalyzeFaultModel() { Statement = 100 };
        public AnalyzeFaultModel SpeedModel 
        {
            get 
            {
                return speedModel;
            }
            set 
            {
                if (speedModel != value) 
                {
                    speedModel = value;
                    NotifyPropertyChanged("SpeedModel");
                }
            }
        }

        private AnalyzeFaultModel distanceModel = new AnalyzeFaultModel() { Statement = 500 };
        public AnalyzeFaultModel DistanceModel
        {
            get
            {
                return distanceModel;
            }
            set
            {
                if (distanceModel != value)
                {
                    distanceModel = value;
                    NotifyPropertyChanged("DistanceModel");
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
                    distanceModel.TyreDiameter = value;
                    speedModel.TyreDiameter = value;
                    NotifyPropertyChanged("DistanceModel");
                    NotifyPropertyChanged("SpeedModel");
                }
            }
        }
    }
}
