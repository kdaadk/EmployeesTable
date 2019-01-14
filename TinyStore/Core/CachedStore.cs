﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyStore.Core
{
    internal class CachedStore
    {
        private readonly Dictionary<string, Dictionary<string, CachedObject>> collections =
            new Dictionary<string, Dictionary<string, CachedObject>>();

        public CachedStore(TinyFs fs)
        {
            foreach (ValueTuple<string, string, string> allEntity in fs.GetAllEntities())
                Save(allEntity.Item2, allEntity.Item1, null, allEntity.Item3);
        }

        public void Save(string collectionName, string id, object obj, string json = null)
        {
            if (collections.ContainsKey(collectionName))
            {
                collections[collectionName][id] = new CachedObject
                {
                    Object = obj,
                    Json = json
                };
            }
            else
            {
                collections[collectionName] = new Dictionary<string, CachedObject>();
                collections[collectionName][id] = new CachedObject
                {
                    Object = obj,
                    Json = json
                };
            }
        }

        public IEnumerable<T> Get<T>(string collectionName, IEnumerable<string> ids)
        {
            foreach (var id1 in ids)
            {
                var id = id1;
                if (collections.ContainsKey(collectionName) && collections[collectionName].ContainsKey(id))
                    yield return collections[collectionName][id].Value<T>();
                id = null;
            }
        }

        public void Delete(string collectionName, IEnumerable<string> ids)
        {
            foreach (var id in ids)
                if (collections.ContainsKey(collectionName) && collections[collectionName].ContainsKey(id))
                    collections[collectionName].Remove(id);
        }

        public IEnumerable<T> GetCollection<T>(string collectionName)
        {
            if (collections.ContainsKey(collectionName))
                return collections[collectionName].Values.Select(x => x.Value<T>());
            return Enumerable.Empty<T>();
        }
    }
}