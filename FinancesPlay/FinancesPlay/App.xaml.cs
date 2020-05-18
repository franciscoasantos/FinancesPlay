using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancesPlay
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU4NjcxQDMxMzgyZTMxMmUzMFd5RlpnbW4raGhMYSs3TkZUVUVrdlVHb1IybllEYThLUmttWUxZMUJ1R3M9");
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
