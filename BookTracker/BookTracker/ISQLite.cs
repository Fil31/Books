using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace BookTracker
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}