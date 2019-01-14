using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyStore.Core
{
    internal class CachedStore
    {
        private readonly Dictionary<string, Dictionary<string, CachedObject>> collections = new Dictionary<string, Dictionary<string, CachedObject>>();

        public CachedStore(TinyFs fs)
        {
            foreach (ValueTuple<string, string, string> allEntity in fs.GetAllEntities())
                this.Save(allEntity.Item2, allEntity.Item1, (object)null, allEntity.Item3);
        }

        public void Save(string collectionName, string id, object obj, string json = null)
        {
            if (this.collections.ContainsKey(collectionName))
            {
                this.collections[collectionName][id] = new CachedObject()
                {
                    Object = obj,
                    Json = json
                };
            }
            else
            {
                this.collections[collectionName] = new Dictionary<string, CachedObject>();
                this.collections[collectionName][id] = new CachedObject()
                {
                    Object = obj,
                    Json = json
                };
            }
        }

        public IEnumerable<T> Get<T>(string collectionName, IEnumerable<string> ids)
        {
            foreach (string id1 in ids)
            {
                string id = id1;
                if (this.collections.ContainsKey(collectionName) && this.collections[collectionName].ContainsKey(id))
                    yield return this.collections[collectionName][id].Value<T>();
                id = (string)null;
            }
        }

        public void Delete(string collectionName, IEnumerable<string> ids)
        {
            foreach (string id in ids)
            {
                if (this.collections.ContainsKey(collectionName) && this.collections[collectionName].ContainsKey(id))
                    this.collections[collectionName].Remove(id);
            }
        }

        public IEnumerable<T> GetCollection<T>(string collectionName)
        {
            if (this.collections.ContainsKey(collectionName))
                return this.collections[collectionName].Values.Select<CachedObject, T>((Func<CachedObject, T>)(x => x.Value<T>()));
            return Enumerable.Empty<T>();
        }
    }
}