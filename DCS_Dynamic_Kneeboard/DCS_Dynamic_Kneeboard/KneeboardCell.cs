using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DCS_Dynamic_Kneeboard
{
    class KneeboardCell : ViewCell
    {

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name", typeof(string), typeof(KneeboardCell), "");

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(KneeboardCell), "");

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create("Type", typeof(string), typeof(KneeboardCell), "");

        public static readonly BindableProperty ObjDataProperty =
            BindableProperty.Create("ObjData", typeof(string), typeof(KneeboardCell), "");

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public string ObjData
        {
            get { return (string)GetValue(ObjDataProperty); }
            set { SetValue(ObjDataProperty, value); }
        }


        public KneeboardCell()
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

            KneeboardCell theCell = ((KneeboardCell)sender);
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

            }
            
        }
    }
}
