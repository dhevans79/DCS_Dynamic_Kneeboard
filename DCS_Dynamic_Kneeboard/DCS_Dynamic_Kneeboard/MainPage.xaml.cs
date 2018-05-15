using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DCS_Dynamic_Kneeboard
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            PopulateListView();
		}

        public void PopulateListView()
        {
            MyListItem [] myListItem = new MyListItem []
            {
                 new MyListItem {Name = "Check Gear", Text = "Check Landing Gear Switch", Type = "CheckBox" },
                 new MyListItem {Name = "Check Flaps", Text = "Check Flap Switch", Type = "CheckBox" }
            };

            ListViewX.ItemsSource = myListItem;
            ListViewX.ItemTemplate = new DataTemplate(typeof(TextCell));
            ListViewX.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
        }
	}
}
