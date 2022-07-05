using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LibUtils
{
    public class Core
    {
        public static Object GetAppKey(string section, string key, string file = "appsettings.json")
        {
            string appFile = Directory.GetCurrentDirectory() + @"\" + file;
            return new ConfigurationBuilder().AddJsonFile(appFile).Build().GetSection(section)[key];
        }
    }
}
