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

namespace XamHangman2020
{
    [Activity(Label = "UserProfileActivity", Theme = "@style/AppTheme")]
    public class UserProfileActivity : Activity
    {
        TextView Name;
        TextView Coins;
        TextView XP;
        TextView Wins;
        TextView Loses;

        List<tblProfile> userData;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.UserProfile);

            // Create your application here
            Init();
        }
        private void Init()
        {
            Name = FindViewById<TextView>(Resource.Id.txtUserProfile_Name);
            Coins = FindViewById<TextView>(Resource.Id.txtUserProfile_Coins);
            XP = FindViewById<TextView>(Resource.Id.txtUserProfile_XP);
            Wins = FindViewById<TextView>(Resource.Id.txtUserProfile_Wins);
            Loses = FindViewById<TextView>(Resource.Id.txtUserProfile_Loses);

            userData = Database.LoadUserProfile();

            Name.Text = userData[0].username;
            Coins.Text = userData[0].coins.ToString();
            XP.Text = userData[0].xp.ToString();
            Wins.Text = userData[0].wins.ToString();
            Loses.Text = userData[0].loses.ToString();
        }
    }
}