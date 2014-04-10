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
using TyresCalculator.Metadata;
using System.Collections.ObjectModel;
using TyresCalculator.Common;

namespace TyresCalculator.UI.Controls
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();

            this.itemsList.Items.Clear();
        }

        private SettingsModel model;
        public SettingsModel Model 
        {
            get { return model; }
            set 
            {
                model = value;
                this.itemsList.ItemsSource = model.Items;
            }
        }
    }
}
