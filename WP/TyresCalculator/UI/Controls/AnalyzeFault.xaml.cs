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
using System.Globalization;

namespace TyresCalculator.UI.Controls
{
    public partial class AnalyzeFault : UserControl
    {
        public AnalyzeFault()
        {
            InitializeComponent();

            txtStatement.TextChanged += txtSpeed_TextChanged;
        }

        void txtSpeed_TextChanged(object sender, TextChangedEventArgs e)
        {
            var points = txtStatement.Text.Select((c, i) => new { ch = c, index = i }).Where(c => c.ch == '.');
            var value = txtStatement.Text;
            if (points.Count() > 1) 
            {
                value = value.Substring(0, points.ElementAt(1).index);
            }

            Model.Statement = String.IsNullOrWhiteSpace(txtStatement.Text) ? null : (double?)double.Parse(value, CultureInfo.InvariantCulture);
        }

        public string Header 
        {
            get { return txtHeader.Text; }
            set { txtHeader.Text = value; }
        }

        public AnalyzeFaultModel Model 
        {
            get { return DataContext as AnalyzeFaultModel; }
            set { DataContext = value; }
        }
    }
}
