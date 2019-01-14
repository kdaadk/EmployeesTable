using Newtonsoft.Json;

namespace TinyStore.Core
{
    internal class CachedObject
    {
        public string Json { get; set; }

        public object Object { get; set; }

        public T Value<T>()
        {
            if (Object != null)
                return (T) Object;
            var obj = JsonConvert.DeserializeObject<T>(Json);
            Object = obj;
            return obj;
        }
    }
}