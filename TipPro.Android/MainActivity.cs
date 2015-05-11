using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TipPro.Android
{
	[Activity (Label = "Tip Professional", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		TextView lblQuestion;
		EditText txtCost;
		Button btnNext;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			lblQuestion = FindViewById<TextView> (Resource.Id.lblQuestion);
			txtCost = FindViewById<EditText> (Resource.Id.txtCost);
			btnNext = FindViewById<Button> (Resource.Id.btnNext);

			btnNext.Click += delegate {

				double cost;
				cost = double.Parse(txtCost.Text);

				if(cost > 0)
				{
					var i = new Intent(this, typeof(PercentActivity));
					i.PutExtra("cost", cost);
					StartActivity(i);
				}
				else
				{
					var errorDialog = new AlertDialog.Builder(this);
					errorDialog.SetMessage("If the meal was free you wouldn't be here..");
					errorDialog.SetNeutralButton("OK", delegate {
						txtCost.RequestFocus();
					});

					errorDialog.Show();
				}
			};
		}
	}
}


