using System.Collections.Generic;
using System.Text.Json;
using TesteDiaADia.Modules;

namespace TesteDiaADia
{
    internal class AppBag
    {
        private readonly Dictionary<string, string> appBag;

        internal AppBag()
        {
            appBag = new Dictionary<string, string>();
        }


        public bool TryAdd(string key, object content)
        {
            bool isSuccess = false;

            bool hasKey = Check.HasKey(key, appBag);

            if (!hasKey)
            {
                Add(key, content);
                isSuccess = true;
            }

            return isSuccess;
        }

        public void Add(string key, object content)
        {
            string contentJson = JsonSerializer.Serialize(content);

            appBag.Add(key, contentJson);
        }

        public void Push(string key, object content)
        {
            bool hasKey = appBag.ContainsKey(key);

            if (!hasKey)
            {
                Add(key, content);
            }
            else
            {
                string contentJson = JsonSerializer.Serialize(content);

                appBag[key] = contentJson;
            }
        }

        public bool TryGet<T>(string key, out T result)
            where T : class, new()
        {
            bool isSuccess = false;

            bool hasKey = Check.HasKey(key, appBag);
            bool hasDeserialized = Conversor.TryDeserialize(appBag[key], out T deserialized);

            if (hasKey && hasDeserialized)
            {
                result = deserialized;
                isSuccess = true;
            }
            else
            {
                result = null;
            }

            return isSuccess;
        }

        public T Get<T>(string key)
            where T : class, new()
        {
            string contentJson = appBag[key];

            return JsonSerializer.Deserialize<T>(contentJson);
        }

        public bool TryUpdate(string key, object content)
        {
            bool isSuccess = false;

            bool hasKey = Check.HasKey(key, appBag);

            if (hasKey)
            {
                Update(key, content);
                isSuccess = true;
            }

            return isSuccess;
        }

        public void Update(string key, object content)
        {
            appBag[key] = JsonSerializer.Serialize(content);
        }

        public bool TryRemove(string key)
        {
            bool isSuccess = false;

            bool hasKey = Check.HasKey(key, appBag);

            if (hasKey)
            {
                Remove(key);
                isSuccess = true;
            }

            return isSuccess;
        }

        public void Remove(string key)
        {
            appBag.Remove(key);
        }

        public void Clear()
        {
            appBag.Clear();
        }
    }
}
