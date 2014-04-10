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
    public partial class Spinner : UserControl
    {
        public static readonly DependencyProperty ModelProperty;

        public Spinner()
        {
            InitializeComponent();
        }

        public SpinnerModel Model
        {
            get { return DataContext as SpinnerModel; }
        }

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            Model.CurrentIndex++;
        }

        private void btnDecrease_Click(object sender, RoutedEventArgs e)
        {
            Model.CurrentIndex--;
        }
    }
}
