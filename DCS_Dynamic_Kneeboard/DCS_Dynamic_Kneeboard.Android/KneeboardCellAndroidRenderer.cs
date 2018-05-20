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

[assembly: ExportRenderer(typeof(KneeboardCell), typeof(KneeboardCellAndroidRenderer))]
namespace DCS_Dynamic_Kneeboard.Droid
{
    public class KneeboardCellAndroidRenderer : ViewCellRenderer
    {
        KneeboardCellAndroid cell;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var kneeboardCell = (KneeboardCell)item;
            Console.WriteLine("\t\t" + kneeboardCell.Name);

            cell = convertView as KneeboardCellAndroid;
            if (cell == null)
            {
                cell = new KneeboardCellAndroid(context, kneeboardCell);
            }
            else
            {
                cell.KneeboardCell.PropertyChanged -= OnKneeboardCellPropertyChanged;
            }

            kneeboardCell.PropertyChanged += OnKneeboardCellPropertyChanged;

            cell.UpdateCell(kneeboardCell);
            return cell;
        }

        void OnKneeboardCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var kneeboardCell = (KneeboardCell)sender;
            if (e.PropertyName == KneeboardCell.NameProperty.PropertyName)
            {
                cell.HeadingTextView.Text = kneeboardCell.Name;
            }
        }

    }
}