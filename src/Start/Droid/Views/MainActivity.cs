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
using Android.Views.InputMethods;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Binding;

using XamAppCenterSample2018.ViewModels;

namespace XamAppCenterSample2018.Droid
{
    [Activity(Label = "XamAppCenterSample2018", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        InputMethodManager inputMethodManager;
        LinearLayout mainLayout;
        EditText editText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);

            editText = (EditText)FindViewById(Resource.Id.inputText);
            mainLayout = (LinearLayout)FindViewById(Resource.Id.mainLayout);
            inputMethodManager = (InputMethodManager)GetSystemService(Context.InputMethodService);

            var button = (Button)FindViewById(Resource.Id.translateButton);
            button.Click += (s, e) => HideSoftInput();

            var textView = (TextView)FindViewById(Resource.Id.translatedText);
            textView.Click += (s, e) => HideSoftInput();
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            HideSoftInput();
            return false;
        }

        void HideSoftInput()
        {
            inputMethodManager.HideSoftInputFromWindow(mainLayout.WindowToken, HideSoftInputFlags.NotAlways);
            mainLayout.RequestFocus();
        }
    }


}

