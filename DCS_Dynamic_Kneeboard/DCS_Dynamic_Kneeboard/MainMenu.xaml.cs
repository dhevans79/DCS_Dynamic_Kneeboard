using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCS_Dynamic_Kneeboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        void OnManageKneeboards(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageKneeboards());

        }

        /*async void OnManageKneeboards(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenu());
        }*/

    }
}