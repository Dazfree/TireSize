using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresCalculator.Metadata;

namespace TyresCalculator.Common.SettingsTable
{
    public class SettingItemsCollection : ObservableCollection<SettingsItem>
    {
        protected override void InsertItem(int index, SettingsItem item)
        {
            base.InsertItem(index, item);

            item.PropertyChanged += item_PropertyChanged;
        }

        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e);
        }
    }
}
