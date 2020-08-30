using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;

namespace XamHangman2020
{
    public static class Database
    {
        public static SQLiteConnection Con;
        public static string dbPath;
        public static string dbName;

        static Database()
        {
            dbName = "hangmanDB.sqlite";
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);// Documents folder
            if (dbPath != null)
            {
                Con = new SQLiteConnection(dbPath);
            }
        }

        public static void InitDB()
        {
            Con.CreateTable<tblLeaderboard>();
        }

        public static void AddItem(string username, int wins, int loses)
        {
            try
            {
                var insertData = new tblLeaderboard() { Username = username, Wins = wins, Loses = loses };
                Con.Insert(insertData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        public static void CreateProfile(string username)
        {
            try
            {
                var insertData = new tblProfile() { username = username, wins = 0, loses = 0, xp = 0, coins = 0 };
                Con.Insert(insertData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        public static void UpdateUserProfile(List<tblProfile> userData)
        {
            try
            {
                var editData = new tblProfile() { username = userData[0].username, wins = userData[0].wins, loses = userData[0].loses, xp = userData[0].xp, coins = userData[0].coins, userId = userData[0].userId };

                Con.Update(editData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Error:" + e.Message);
            }
        }


        public static List<tblProfile> LoadUserProfile()
        {
            // Create Database if it doesn't already exist
            Con.CreateTable<tblProfile>();

            return Con.Table<tblProfile>().ToList();
        }

        public static List<tblLeaderboard> ViewTable()
        {
            Console.WriteLine("Creating database, if it doesn't already exist");
            Con.CreateTable<tblLeaderboard>();
            if (Con.Table<tblLeaderboard>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newLeaderboard = new tblLeaderboard();
                newLeaderboard.Username = "Test 1";
                newLeaderboard.Wins = 13;
                newLeaderboard.Loses = 2;
                Con.Insert(newLeaderboard);
            }
            Console.WriteLine("Reading data");
            return Con.Table<tblLeaderboard>().ToList();
        }
    }
}