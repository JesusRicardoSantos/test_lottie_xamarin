using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Com.Airbnb.Lottie;
using System.Timers;
using com.refractored;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Java.Lang;

namespace prueba
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        bool contador = false;

        PagerSlidingTabStrip tabStrip;
        ViewPager viewPager;
        MyAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            tabStrip = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);

            adapter = new MyAdapter(SupportFragmentManager);


            viewPager.Adapter = adapter;
            tabStrip.SetViewPager(viewPager);
            tabStrip.SetBackgroundColor(Android.Graphics.Color.Black);

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

public class MyAdapter : FragmentPagerAdapter
{
    int tabCount = 2;

    public MyAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm) { }

    public override int Count {
        get {
            return tabCount;
        }
    }

    public override ICharSequence GetPageTitleFormatted(int position)
    {
        ICharSequence charSequence = new String("HOLA");
        switch (position)
        {
            case 1: {
                    charSequence = new String("Tab1");
                }
                break;
            case 2: {
                    charSequence = new String("Tab2");
                }
                break;
        }
        return charSequence;
    }

    public override Android.Support.V4.App.Fragment GetItem(int position)
    {
        return ContentFragment.NewInstance(position);
    }
}


public class ContentFragment : Android.Support.V4.App.Fragment
{
    public int position;

    public static ContentFragment NewInstance(int position)
    {
        var contentFragment = new ContentFragment();
        var _bundle = new Bundle();
        _bundle.PutInt("position", position);
        contentFragment.Arguments = _bundle;
        return contentFragment;
    }

    public override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        position = Arguments.GetInt("position");
    }
}