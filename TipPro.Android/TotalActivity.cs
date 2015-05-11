
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
using TipPro.Core;

namespace TipPro.Android
{
	[Activity (Label = "TotalActivity")]			
	public class TotalActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Total);

			TextView lblClose = FindViewById<TextView> (Resource.Id.lblClose);
			TextView lblTip = FindViewById<TextView> (Resource.Id.lblTip);
			Button btnExit = FindViewById<Button> (Resource.Id.btnExit);

			string costString = Intent.GetStringExtra("cost") ?? "0";
			string percentString = Intent.GetStringExtra ("percent") ?? "0";

			double cost;
			double percent;
			double tip;
			cost = double.Parse (costString);
			percent = double.Parse (percentString);
			tip = cost * percent;
			lblTip.Text = tip.ToString ("C");
		}
	}
}

