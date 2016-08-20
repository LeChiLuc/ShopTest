using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTest.Common
{
    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            //Add references System.configuration
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
