using Newtonsoft.Json;

namespace TinyStore.Core
{
    internal class CachedObject
    {
        public string Json { get; set; }

        public object Object { get; set; }

        public T Value<T>()
        {
            if (this.Object != null)
                return (T)this.Object;
            T obj = JsonConvert.DeserializeObject<T>(this.Json);
            this.Object = (object)obj;
            return obj;
        }
    }
}