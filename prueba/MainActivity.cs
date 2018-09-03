using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Com.Airbnb.Lottie;
using System.Timers;

namespace prueba
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        bool contador = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            

            LottieAnimationView downloadAnimation = (LottieAnimationView)FindViewById(Resource.Id.animation_view);
            downloadAnimation.SetAnimation("download_icon.json");
            downloadAnimation.Click += delegate {
                
                downloadAnimation.PlayAnimation();

                #region comentarios
                //Timer t = new Timer();
                //t.Interval = 6000;
                //t.Enabled = true;

                //t.Elapsed += delegate {

                //    RunOnUiThread(() =>
                //    {
                //        if (!contador)
                //            downloadAnimation.PlayAnimation();
                //        else
                //            downloadAnimation.SetBackgroundResource(Resource.Drawable.descarga);
                //        contador = true;
                //    });

                //};

                //t.Start();

                //int milliseconds = 6000;
                //System.Threading.Thread.Sleep(milliseconds);
                #endregion;
            };
            //downloadAnimation.Loop = true;
        }
    }
}

