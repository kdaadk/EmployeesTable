using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using TinyStore.Attributes;
using TinyStore.Core;

namespace TinyStore
{
    public class Store
    {
        private readonly TinyFs fs;
        private readonly bool useTypeNameForCollection;
        private readonly CachedStore cachedStore;

        public Store(string dbPath = null, bool useTypeNameForCollection = true, bool keepDbInMemory = true)
        {
            this.useTypeNameForCollection = useTypeNameForCollection;
            this.fs = new TinyFs(dbPath);
            if (!keepDbInMemory)
                return;
            this.cachedStore = new CachedStore(this.fs);
        }

        public void Save<T>(string id, T document, string collectionName = null)
        {
            collectionName = this.GetCollectionName(typeof(T), collectionName);
            this.fs.SaveToCollection(JsonConvert.SerializeObject((object)document), id, collectionName);
            CachedStore cachedStore = this.cachedStore;
            if (cachedStore == null)
                return;
            cachedStore.Save(collectionName, id, (object)document, (string)null);
        }

        public T FindById<T>(string id, string collectionName = null)
        {
            collectionName = this.GetCollectionName(typeof(T), collectionName);
            if (this.cachedStore != null)
                return this.cachedStore.Get<T>(collectionName, (IEnumerable<string>)new string[1]
                {
          id
                }).SingleOrDefault<T>();
            string fromCollection = this.fs.GetFromCollection(id, collectionName);
            return fromCollection != null ? JsonConvert.DeserializeObject<T>(fromCollection) : default(T);
        }

        public IEnumerable<T> FindByQuery<T>(Func<T, bool> filter, string collectionName = null)
        {
            collectionName = this.GetCollectionName(typeof(T), collectionName);
            if (this.cachedStore != null)
                return this.cachedStore.GetCollection<T>(collectionName).Where<T>(filter);
            return this.fs.GetCollection(collectionName).Select<string, T>((Func<string, T>)(x => JsonConvert.DeserializeObject<T>(x))).Where<T>(filter);
        }

        public void DeleteById<T>(string id, string collectionName = null)
        {
            collectionName = this.GetCollectionName(typeof(T), collectionName);
            this.fs.Delete(id, collectionName);
            CachedStore cachedStore = this.cachedStore;
            if (cachedStore == null)
                return;
            cachedStore.Delete(collectionName, (IEnumerable<string>)new string[1]
            {
        id
            });
        }

        public void DeleteByQuery<T>(Func<T, bool> filter, string collectionName = null)
        {
            collectionName = this.GetCollectionName(typeof(T), collectionName);
            foreach (ValueTuple<string, T> filteredPair in this.GetFilteredPairs<T>(filter, collectionName))
            {
                this.fs.Delete(filteredPair.Item1, collectionName);
                CachedStore cachedStore = this.cachedStore;
                if (cachedStore != null)
                    cachedStore.Delete(collectionName, (IEnumerable<string>)new string[1]
                    {
            filteredPair.Item1
                    });
            }
        }

        public void ModifyById<T>(string id, Action<T> modify, string collectionName = null)
        {
            collectionName = this.GetCollectionName(typeof(T), collectionName);
            T byId = this.FindById<T>(id, collectionName);
            if ((object)byId == null)
                return;
            modify(byId);
            this.Save<T>(id, byId, collectionName);
        }

        public void ModifyByQuery<T>(Func<T, bool> filter, Action<T> modify, string collectionName = null)
        {
            collectionName = this.GetCollectionName(typeof(T), collectionName);
            foreach (ValueTuple<string, T> filteredPair in this.GetFilteredPairs<T>(filter, collectionName))
            {
                modify(filteredPair.Item2);
                this.Save<T>(filteredPair.Item1, filteredPair.Item2, collectionName);
            }
        }

        private IEnumerable<(string id, T obj)> GetFilteredPairs<T>(Func<T, bool> filter, string collectionName)
        {
            return this.fs.GetCollectionFiles(collectionName).Select<string, ValueTuple<string, T>>((Func<string, ValueTuple<string, T>>)(x => new ValueTuple<string, T>(x, JsonConvert.DeserializeObject<T>(this.fs.GetFromCollection(x, collectionName))))).Where<ValueTuple<string, T>>((Func<ValueTuple<string, T>, bool>)(x => filter(x.Item2)));
        }

        private string GetCollectionNameFromAttribute(Type type)
        {
            CollectionNameAttribute customAttribute = Attribute.GetCustomAttribute((MemberInfo)type, typeof(CollectionNameAttribute)) as CollectionNameAttribute;
            if (customAttribute == null)
                return (string)null;
            return customAttribute.Name;
        }

        private string GetCollectionName(Type type, string collectionName)
        {
            string str = collectionName ?? this.GetCollectionNameFromAttribute(type) ?? (this.useTypeNameForCollection ? type.Name : (string)null);
            if (str == null)
                throw new ArgumentException("No collection name was provided and type had no CollectionNameAttribute and UseTypeNameForCollection was false");
            return str;
        }
    }
}