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
    public partial class AddNewKneeboard : ContentPage
    {
        public AddNewKneeboard()
        {
            InitializeComponent();

            PopulatePages();
        }

        public void PopulatePages()
        {
            PagesStore pagesStore = PagesStore.Instance;
            Dictionary<string, Page> pages = pagesStore.GetAllPages();

            ListViewX.ItemsSource = pages;
            ListViewX.ItemTemplate = new DataTemplate(typeof(ManageKneeboardViewCell));
        }
    }
}
