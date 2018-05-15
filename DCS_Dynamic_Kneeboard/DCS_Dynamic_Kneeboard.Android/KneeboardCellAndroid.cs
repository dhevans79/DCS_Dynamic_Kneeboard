using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace DCS_Dynamic_Kneeboard.Droid
{
    internal class KneeboardCellAndroid : LinearLayout, INativeElementView
    {
        public ImageView ImageView { get; set; }
        public TextView  HeadingTextView { get; set; }

        public KneeboardCell KneeboardCell { get; set; }
        public Element Element => KneeboardCell;

        public KneeboardCellAndroid(Context context, KneeboardCell cell) : base(context)
        {
            KneeboardCell = cell;

            var view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.KneeboardCellAndroid, null);
            HeadingTextView = view.FindViewById<TextView>(Resource.Id.Text);
            ImageView = view.FindViewById<ImageView>(Resource.Id.Image);

            AddView(view);
        }

        public void UpdateCell(KneeboardCell cell)
        {
            //HeadingTextView.Text = cell.Name;

            var item = cell.BindingContext as MyListItem;
            HeadingTextView.Text = item.Text;


            // Dispose of the old image
            /*
            if (ImageView.Drawable != null)
            {
                using (var image = ImageView.Drawable as BitmapDrawable)
                {
                    if (image != null)
                    {
                        if (image.Bitmap != null)
                        {
                            image.Bitmap.Dispose();
                        }
                    }
                }
            }

            SetImage(cell.ImageFilename);*/
        }
    }
}