using Syncfusion.XForms.ProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Fim : ContentPage
    {
        public Fim()
        {
            InitializeComponent();
            var conhecimento = MainPage.conhecimento;

            flexLayoutStatus.Children.Add(new SfCircularProgressBar
            {
                Progress = conhecimento * 100,
                IndicatorInnerRadius = 0.65,
                IndicatorOuterRadius = 0.7,
                ShowProgressValue = true,
                EasingEffect = EasingEffects.Linear
            });


            if (conhecimento < 25)
            {

            }
            else if (conhecimento >= 25 && conhecimento < 50)
            {

            }
            else if (conhecimento >= 50 && conhecimento < 75)
            {

            }
            else if (conhecimento >= 75)
            {

            }
        }
    }
}