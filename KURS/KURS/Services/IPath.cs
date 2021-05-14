using System;
using System.Collections.Generic;
using System.Text;

namespace KURS.Services
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
