using System;
using System.Text.Json;

namespace TesteDiaADia.Modules
{
    internal static class Conversor
    {
        internal static bool TryDeserialize<T>(string contentJson, out T result) 
            where T : class, new()
        {
            bool isSuccess = false;

            try
            {
                result = JsonSerializer.Deserialize<T>(contentJson);
                isSuccess = true;
            }
            catch
            {
                result = null;
            }

            return isSuccess;
        }
    }
}
