using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using DCS_Dynamic_Kneeboard;
using DCS_Dynamic_Kneeboard.Droid;

[assembly: ExportRenderer(typeof(ManageKneeboardViewCell), typeof(ManageKneeboardViewCellAndroidRenderer))]
namespace DCS_Dynamic_Kneeboard.Droid
{
    class ManageKneeboardViewCellAndroidRenderer : ViewCellRenderer
    {
        ManageKneeboardViewCellAndroid cell;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var kneeboardCell = (ManageKneeboardViewCell)item;
            Console.WriteLine("\t\t" + kneeboardCell.Title);

            cell = convertView as ManageKneeboardViewCellAndroid;
            if (cell == null)
            {
                cell = new ManageKneeboardViewCellAndroid(context, kneeboardCell);
            }
            else
            {
                cell.mkvCell.PropertyChanged -= OnManageKneeboardViewCellPropertyChanged;
            }

            kneeboardCell.PropertyChanged += OnManageKneeboardViewCellPropertyChanged;

            cell.UpdateCell(kneeboardCell);
            return cell;
        }

        void OnManageKneeboardViewCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var kneeboardCell = (KneeboardCell)sender;
            if (e.PropertyName == KneeboardCell.NameProperty.PropertyName)
            {
                cell.HeadingTextView.Text = kneeboardCell.Name;
            }
        }
    }
}