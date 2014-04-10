using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TyresCalculator.Models;

namespace TyresCalculator.UI.Controls
{
    public partial class Analyze : UserControl
    {
        public Analyze()
        {
            InitializeComponent();
        }

        public AnalyzeModel Model 
        {
            get { return DataContext as AnalyzeModel; }
            set 
            {
                DataContext = value;
            }
        }
    }
}
