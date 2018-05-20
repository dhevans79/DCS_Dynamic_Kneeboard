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
    internal class ManageKneeboardViewCellAndroid : LinearLayout, INativeElementView
    {
        public ImageView ImageViewActive { get; set; }
        public ImageView ImageViewEdit { get; set; }
        public ImageView ImageViewDelete { get; set; }
        public TextView HeadingTextView { get; set; }

        public ManageKneeboardViewCell mkvCell { get; set; }
        public Element Element => mkvCell;

        public ManageKneeboardViewCellAndroid(Context context, ManageKneeboardViewCell cell) : base(context)
        {
            mkvCell = cell;

            var view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.ManageKneeboardViewCellAndroid, null);
            HeadingTextView = view.FindViewById<TextView>(Resource.Id.MKPageLabel);
            ImageViewActive = view.FindViewById<ImageView>(Resource.Id.ImageActive);
            ImageViewEdit = view.FindViewById<ImageView>(Resource.Id.ImageEdit);
            ImageViewDelete = view.FindViewById<ImageView>(Resource.Id.ImageDelete);

            AddView(view);
        }

        public void UpdateCell(ManageKneeboardViewCell cell)
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