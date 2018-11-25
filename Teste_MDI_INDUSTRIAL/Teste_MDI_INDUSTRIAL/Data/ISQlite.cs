using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Data
{
    public interface ISQlite
    {
        SQLiteConnection GetConnection();
        
    }
}
