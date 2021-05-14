using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KURS.UWP;
using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using KURS.Services;

[assembly: Dependency(typeof(UwpDbPath))]
namespace KURS.UWP
{
    class UwpDbPath :IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
        }
    }
}
