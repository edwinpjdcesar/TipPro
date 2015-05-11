
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

namespace TipPro.Android
{
	[Activity (Label = "PercentActivity")]			
	public class PercentActivity : Activity
	{
		TextView lblQuestion;
		TextView lblComment;
		TextView lblPercent;
		SeekBar seekBarPercent;
		Button btnCalculate;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Percent);

			lblQuestion = FindViewById<TextView> (Resource.Id.lblQuestion);
			lblComment = FindViewById<TextView> (Resource.Id.lblComment);
			lblPercent = FindViewById<TextView> (Resource.Id.lblPercent);
			seekBarPercent = FindViewById<SeekBar> (Resource.Id.seekBarPercent);
			btnCalculate = FindViewById<Button> (Resource.Id.btnCalculate);

			seekBarPercent.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => 
			{
				lblPercent.Text = string.Format ("{0}", seekBarPercent.Progress);

				if(seekBarPercent.Progress == 0) 
					lblComment.Text = "They're probably going to spit in your food, just saying..";
				else if(seekBarPercent.Progress >= 10)
					lblComment.Text = "Wow, don't be so stingy!";
				else if(seekBarPercent.Progress >= 15)
					lblComment.Text = "Congraulations, Average Joe. You've reached an average tip.";
				else if(seekBarPercent.Progress >= 25)
					lblComment.Text = "Now that's more like it!";
				else if(seekBarPercent.Progress >= 50)
					lblComment.Text = "You're the man!";
				else if(seekBarPercent.Progress >= 75)
					lblComment.Text = "Ok buddy, let's take it easy..";
				else if(seekBarPercent.Progress >= 100)
					lblComment.Text = "Where's mine?";
			};

			btnCalculate.Click += delegate {

				double percent;
				percent = double.Parse (lblPercent.Text);

				var ii = new Intent (this, typeof(TotalActivity));
				ii.PutExtra ("percent", percent);
				StartActivity(ii);
			};
		}
	}
}

