using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresCalculator.BusinessLogic;
using TyresCalculator.Common;
using TyresCalculator.Common.SettingsTable;
using TyresCalculator.Metadata;

namespace TyresCalculator.Models
{
    public class SettingsModel : NotifiableModel
    {
        private class PropertyMetadata
        {
            public PropertyMetadata(Guid key, string name, string displayName)
            {
                Key = key;
                Name = name;
                DisplayName = displayName;
            }

            public Guid Key { get; set; }

            public string Name { get; set; }

            public string DisplayName { get; set; }
        }

        public readonly Guid ProtectorWidthKey = new Guid("1ec96ad2-6541-4816-a0bd-45948d1c201d");
        public readonly Guid ProfileHeightKey = new Guid("f60804fd-488e-4ce8-b857-d7524046a7d5");
        public readonly Guid BoreDiameterKey = new Guid("71c6ac1c-2edb-451e-b5a8-aacd961fe415");
        public readonly Guid TyreDiameterKey = new Guid("ffe3033b-a210-4d67-b1c2-0e0aaddd713b");

        private List<PropertyMetadata> properties = new List<PropertyMetadata>();

        public SettingsModel()
        {
            properties.Add(new PropertyMetadata(ProtectorWidthKey, "ProtectorWidth", "Protector width"));
            properties.Add(new PropertyMetadata(ProfileHeightKey, "ProfileHeight", "Profile height"));
            properties.Add(new PropertyMetadata(BoreDiameterKey, "BoreDiameter", "Bore diameter"));
            properties.Add(new PropertyMetadata(TyreDiameterKey, "TyreDiameter", "Tyre diameter"));

            InitializeItems();
        }

        private void InitializeItems()
        {
            Items = new SettingItemsCollection();
            properties.ForEach(p => Items.Add(new SettingsItem() { Key = p.Key, Name = p.Name, DisplayName = p.DisplayName }));
        }

        public void SetPropertyValue(Guid key, double? value, SettingsMode mode)
        {
            SettingsItem item;
            if (!Items.Any(i => i.Key == key))
            {
                var newItem = new SettingsItem() { Key = key };
                var propertyMetadata = properties.FirstOrDefault(pm => pm.Key == key);
                if (propertyMetadata != null)
                {
                    newItem.Name = propertyMetadata.Name;
                    newItem.DisplayName = propertyMetadata.DisplayName;
                }

                Items.Add(newItem);

                item = newItem;
            }
            else item = Items.First(i => i.Key == key);

            bool isPropertyChanged = false;
            if (mode == SettingsMode.Current && item.Old != value)
            {
                item.Old = value;
                isPropertyChanged = true;
            }
            else if (mode == SettingsMode.New && item.New != value)
            {
                item.New = value;
                isPropertyChanged = true;
            }

            if (isPropertyChanged)
                NotifyPropertyChanged(item.Name);
        }

        public DoublePair ProtectorWidth
        {
            get { return GetPropertyValue(ProtectorWidthKey); }
        }

        public DoublePair ProfileHeight
        {
            get { return GetPropertyValue(ProfileHeightKey); }
        }

        public DoublePair BoreDiameter
        {
            get { return GetPropertyValue(BoreDiameterKey); }
        }

        public DoublePair TyreDiameter
        {
            get { return GetPropertyValue(TyreDiameterKey); }
        }

        private DoublePair GetPropertyValue(Guid key)
        {
            var value = Items.FirstOrDefault(i => i.Key == key);
            return value == null ? null : new DoublePair() { Item1 = value.Old.ToDouble(), Item2 = value.New.ToDouble() };
        }

        public SettingItemsCollection Items { get; set; }

        public enum SettingsMode
        {
            Current,
            New
        }
    }
}
