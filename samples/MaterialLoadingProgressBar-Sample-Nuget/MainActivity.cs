using Android.Support.V7.App;
using Android.Views;
using Android.App;

namespace MaterialLoadingProgressBarSample
{
  using Lsjwzh.Widget.MaterialLoadingProgressBar;
  using Android.OS;

  [Activity(MainLauncher = true, Theme = "@style/Theme.AppCompat", Label = "@string/app_name")]
  public class MainActivity : ActionBarActivity
  {
    private Handler handler;
    CircleProgressBar progress1;
    CircleProgressBar progress2;
    CircleProgressBar progressWithArrow;
    CircleProgressBar progressWithoutBg;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.activity_main);
      progress1 = FindViewById<CircleProgressBar>(Resource.Id.progress1);
      progress2 = FindViewById<CircleProgressBar>(Resource.Id.progress2);
      progressWithArrow = FindViewById<CircleProgressBar>(Resource.Id.progressWithArrow);
      progressWithoutBg = FindViewById<CircleProgressBar>(Resource.Id.progressWithoutBg);


//        progress1.setColorSchemeResources(android.R.color.holo_blue_bright);
      progress2.SetColorSchemeResources(Android.Resource.Color.HoloGreenLight, 
                                        Android.Resource.Color.HoloOrangeLight, 
                                        Android.Resource.Color.HoloRedLight);

      progressWithArrow.SetColorSchemeResources(Android.Resource.Color.HoloOrangeLight);
      progressWithoutBg.SetColorSchemeResources(Android.Resource.Color.HoloRedLight);

      handler = new Handler();
      for(int i = 0; i < 10; i++)
      {
        int finalI = i;
        handler.PostDelayed(() =>
          {
            if(finalI * 10 >= 90)
            {
              progress1.Visibility = ViewStates.Visible;
              progress2.Visibility = ViewStates.Invisible;
            }
            else
            {
              progress2.Progress = finalI * 10;
            }          
          }, 1000 * (i + 1));
      }

    }

    public override bool OnCreateOptionsMenu(IMenu menu)
    {
      // Inflate the menu; this adds items to the action bar if it is present.
      MenuInflater.Inflate(Resource.Menu.menu_main, menu);
      return true;
    }

    public override bool OnOptionsItemSelected(IMenuItem item)
    {
      // Handle action bar item clicks here. The action bar will
      // automatically handle clicks on the Home/Up button, so long
      // as you specify a parent activity in AndroidManifest.xml.
      int id = item.ItemId;

      //noinspection SimplifiableIfStatement
      if(id == Resource.Id.action_settings)
      {
        return true;
      }

      return base.OnOptionsItemSelected(item);
    }
  }
}