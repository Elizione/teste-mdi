using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.Data;
using SQLite;

namespace App2.Droid
{
    public class SQLite_Android : ISQlite
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "Paciente.db3";
            var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documents, fileName);

            return new SQLiteConnection(path);
        }
    }
}