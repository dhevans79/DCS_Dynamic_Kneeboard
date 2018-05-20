using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DCS_Dynamic_Kneeboard
{
    class ManageKneeboardViewCell : ViewCell
    {
        public static readonly BindableProperty IDProperty =
            BindableProperty.Create("ID", typeof(string), typeof(KneeboardCell), "");

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(KneeboardCell), "");

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(KneeboardCell), "");

        public static readonly BindableProperty PagesProperty =
            BindableProperty.Create("Pages", typeof(string), typeof(KneeboardCell), "");

        public string ID
        {
            get { return (string)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public string Pages
        {
            get { return (string)GetValue(PagesProperty); }
            set { SetValue(PagesProperty, value); }
        }


        public ManageKneeboardViewCell()
        {
            // Empty constructor as we will use the OnBindingContextChanged 
            // to build the Layout as required.
            // Because we do not have access to a sender object
            // to be able to get the BindingContext

        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();

            if (BindingContext == null)
                return;

            /*KneeboardCell theCell = ((KneeboardCell)sender);
            //theCell.View = new StackLayout();
            var item = theCell.BindingContext as MyListItem;

            if (item.Type == "CheckBox")
            {
                Image checkbox = new Image
                {
                    //HorizontalOptions = LayoutOptions.Start,
                    WidthRequest = 50,
                    HeightRequest = 50
                };
                //checkbox.Source = "checkbox_checked.png";
                checkbox.Source = "right_arrow.png";

                Label textout = new Label
                {
                    //HorizontalOptions = LayoutOptions.FillAndExpand
                };
                textout.SetBinding(Label.TextProperty, "Text");

                View = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { checkbox, textout }
                };
            }
            else if (item.Type == "Image")
            {

            }*/

        }
    }
}
