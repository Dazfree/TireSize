using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TyresCalculator.Resources;
using TyresCalculator.Models;
using TyresCalculator.Common;
using TyresCalculator.BusinessLogic;

namespace TyresCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        private SettingsCalculator settingsCalculator = new SettingsCalculator();
        private InfluenceCalculator influenceCalculator = new InfluenceCalculator();

        public MainPage()
        {
            InitializeComponent();

            DataContext = new MainModel();

            settings.Model = new SettingsModel();

            analyze.Model = new AnalyzeModel();
        }

        private MainModel Model 
        {
            get
            {
                return DataContext as MainModel;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DoStep(Model.Step, Model.Step - 1);
            Model.Step--;
        }

        private void DoStep(int currentStep, int stepToLoad)
        {
            SaveStep(currentStep);
            LoadStep(stepToLoad);
        }

        private void LoadStep(int stepToLoad)
        {
            if (stepToLoad != 2)
            {
                var currentMode = stepToLoad == 0 ? SettingsModel.SettingsMode.Current : SettingsModel.SettingsMode.New;

                var protectorWidth = currentMode == SettingsModel.SettingsMode.Current ? settings.Model.ProtectorWidth.Item1 : settings.Model.ProtectorWidth.Item2;
                var profileHeight = currentMode == SettingsModel.SettingsMode.Current ? settings.Model.ProfileHeight.Item1 : settings.Model.ProfileHeight.Item2;
                var boreDiameter = currentMode == SettingsModel.SettingsMode.Current ? settings.Model.BoreDiameter.Item1 : settings.Model.BoreDiameter.Item2;

                sProtectorWidth.Model.CurrentItem = protectorWidth;
                sProfileHeight.Model.CurrentItem = settingsCalculator.GetProfileHeightPercents(protectorWidth, profileHeight);
                sBoreDiameter.Model.CurrentItem = settingsCalculator.GetBoreInchDiameter(boreDiameter);
            }
            else
            {
                analyze.Model.ClearanceChange = influenceCalculator.GetClearanceChange(settings.Model.TyreDiameter.Item1, settings.Model.TyreDiameter.Item2);
                analyze.Model.RecommendedDiscHeight = influenceCalculator.GetRecommendedDiscHeight(settings.Model.BoreDiameter.Item2);
                analyze.Model.RecommendedDiscWidth = influenceCalculator.GetRecommendedDiscWidth(settings.Model.ProtectorWidth.Item2);
                analyze.Model.TyreDiameter = settings.Model.TyreDiameter;
            }
        }

        private void SaveStep(int currentStep)
        {
            if (currentStep != 2)
            {
                var settingsMode = currentStep == 0 ? SettingsModel.SettingsMode.Current : SettingsModel.SettingsMode.New;

                var protectorWidth = sProtectorWidth.Model.CurrentItem.ToDouble();
                var profileHeight = sProfileHeight.Model.CurrentItem.ToDouble();
                var boreDiameter = sBoreDiameter.Model.CurrentItem.ToDouble();

                settings.Model.SetPropertyValue(settings.Model.ProtectorWidthKey, protectorWidth, settingsMode);
                settings.Model.SetPropertyValue(settings.Model.ProfileHeightKey, settingsCalculator.GetRoundedProfileHeight(protectorWidth, profileHeight), settingsMode);
                settings.Model.SetPropertyValue(settings.Model.BoreDiameterKey, settingsCalculator.GetMmBoreDiameter(boreDiameter), settingsMode);
                settings.Model.SetPropertyValue(settings.Model.TyreDiameterKey, settingsCalculator.GetTyreDiameter(protectorWidth, profileHeight, boreDiameter), settingsMode);
            }
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            DoStep(Model.Step, Model.Step + 1);
            Model.Step++;
        }
    }
}