using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookTracker.Droid
{
    public SQLiteConnection GetConnection()
    {
        var sqliteFilename = "BooksDB.db3";
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var path = Path.Combine(documentsPath, sqliteFilename);
        var conn = new SQLiteConnection(path);
        return conn;
    }
}