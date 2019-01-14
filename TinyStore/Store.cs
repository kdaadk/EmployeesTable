using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TinyStore.Attributes;
using TinyStore.Core;

namespace TinyStore
{
    public class Store
    {
        private readonly CachedStore cachedStore;
        private readonly TinyFs fs;
        private readonly bool useTypeNameForCollection;

        public Store(string dbPath = null, bool useTypeNameForCollection = true, bool keepDbInMemory = true)
        {
            this.useTypeNameForCollection = useTypeNameForCollection;
            fs = new TinyFs(dbPath);
            if (!keepDbInMemory)
                return;
            cachedStore = new CachedStore(fs);
        }

        public void Save<T>(string id, T document, string collectionName = null)
        {
            collectionName = GetCollectionName(typeof(T), collectionName);
            fs.SaveToCollection(JsonConvert.SerializeObject(document), id, collectionName);
            var cachedStore = this.cachedStore;
            if (cachedStore == null)
                return;
            cachedStore.Save(collectionName, id, document, null);
        }

        public T FindById<T>(string id, string collectionName = null)
        {
            collectionName = GetCollectionName(typeof(T), collectionName);
            if (cachedStore != null)
                return cachedStore.Get<T>(collectionName, new string[1]
                {
                    id
                }).SingleOrDefault();
            var fromCollection = fs.GetFromCollection(id, collectionName);
            return fromCollection != null ? JsonConvert.DeserializeObject<T>(fromCollection) : default(T);
        }

        public IEnumerable<T> FindByQuery<T>(Func<T, bool> filter, string collectionName = null)
        {
            collectionName = GetCollectionName(typeof(T), collectionName);
            if (cachedStore != null)
                return cachedStore.GetCollection<T>(collectionName).Where(filter);
            return fs.GetCollection(collectionName).Select(x => JsonConvert.DeserializeObject<T>(x)).Where(filter);
        }

        public void DeleteById<T>(string id, string collectionName = null)
        {
            collectionName = GetCollectionName(typeof(T), collectionName);
            fs.Delete(id, collectionName);
            var cachedStore = this.cachedStore;
            if (cachedStore == null)
                return;
            cachedStore.Delete(collectionName, new string[1]
            {
                id
            });
        }

        public void DeleteByQuery<T>(Func<T, bool> filter, string collectionName = null)
        {
            collectionName = GetCollectionName(typeof(T), collectionName);
            foreach (ValueTuple<string, T> filteredPair in GetFilteredPairs(filter, collectionName))
            {
                fs.Delete(filteredPair.Item1, collectionName);
                var cachedStore = this.cachedStore;
                if (cachedStore != null)
                    cachedStore.Delete(collectionName, new string[1]
                    {
                        filteredPair.Item1
                    });
            }
        }

        public void ModifyById<T>(string id, Action<T> modify, string collectionName = null)
        {
            collectionName = GetCollectionName(typeof(T), collectionName);
            var byId = FindById<T>(id, collectionName);
            if (byId == null)
                return;
            modify(byId);
            Save(id, byId, collectionName);
        }

        public void ModifyByQuery<T>(Func<T, bool> filter, Action<T> modify, string collectionName = null)
        {
            collectionName = GetCollectionName(typeof(T), collectionName);
            foreach (ValueTuple<string, T> filteredPair in GetFilteredPairs(filter, collectionName))
            {
                modify(filteredPair.Item2);
                Save(filteredPair.Item1, filteredPair.Item2, collectionName);
            }
        }

        private IEnumerable<(string id, T obj)> GetFilteredPairs<T>(Func<T, bool> filter, string collectionName)
        {
            return fs.GetCollectionFiles(collectionName).Select(x =>
                    new ValueTuple<string, T>(x,
                        JsonConvert.DeserializeObject<T>(fs.GetFromCollection(x, collectionName))))
                .Where(x => filter(x.Item2));
        }

        private string GetCollectionNameFromAttribute(Type type)
        {
            var customAttribute =
                Attribute.GetCustomAttribute(type, typeof(CollectionNameAttribute)) as CollectionNameAttribute;
            if (customAttribute == null)
                return null;
            return customAttribute.Name;
        }

        private string GetCollectionName(Type type, string collectionName)
        {
            var str = collectionName ??
                      GetCollectionNameFromAttribute(type) ?? (useTypeNameForCollection ? type.Name : null);
            if (str == null)
                throw new ArgumentException(
                    "No collection name was provided and type had no CollectionNameAttribute and UseTypeNameForCollection was false");
            return str;
        }
    }
}