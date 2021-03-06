using System;
using System.Collections.Generic;

namespace TesteDiaADia.Modules
{
    internal static class Check
    {
        internal static bool HasKey(string key, Dictionary<string, string> appBag)
        {
            return appBag.ContainsKey(key);
        }
    }
}
