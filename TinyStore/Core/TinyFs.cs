using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TinyStore.Core
{
    internal class TinyFs
    {
        private readonly string rootDirectory;

        public TinyFs(string dbPath)
        {
            this.rootDirectory = dbPath != null ? Path.Combine(dbPath, "tinyDb") : "tinyDb";
            if (Directory.Exists(this.rootDirectory))
                return;
            Directory.CreateDirectory(this.rootDirectory);
        }

        private void EnsureCollectionFolder(string name)
        {
            string path = Path.Combine(this.rootDirectory, name);
            if (Directory.Exists(path))
                return;
            Directory.CreateDirectory(path);
        }

        public bool SaveToCollection(string json, string id, string collectionName)
        {
            this.EnsureCollectionFolder(collectionName);
            File.WriteAllText(Path.Combine(this.rootDirectory, collectionName, id), json);
            return true;
        }

        public string GetFromCollection(string id, string collectionName)
        {
            string path = Path.Combine(this.rootDirectory, collectionName, id);
            if (File.Exists(path))
                return File.ReadAllText(path);
            return (string)null;
        }

        public void Delete(string id, string collectionName)
        {
            string path = Path.Combine(this.rootDirectory, collectionName, id);
            if (!File.Exists(path))
                return;
            File.Delete(path);
        }

        public IEnumerable<string> GetCollectionFiles(string collectionName)
        {
            return Directory.EnumerateFiles(Path.Combine(this.rootDirectory, collectionName)).Select<string, string>((Func<string, string>)(x => Path.GetFileName(x)));
        }

        public IEnumerable<(string Id, string CollectionName, string Content)> GetAllEntities()
        {
            foreach (string enumerateDirectory in Directory.EnumerateDirectories(this.rootDirectory))
            {
                string directoryPath = enumerateDirectory;
                foreach (string enumerateFile in Directory.EnumerateFiles(directoryPath))
                {
                    string filePath = enumerateFile;
                    yield return new ValueTuple<string, string, string>(Path.GetFileName(filePath), Path.GetFileName(directoryPath), File.ReadAllText(filePath));
                    filePath = (string)null;
                }
                directoryPath = (string)null;
            }
        }

        public IEnumerable<string> GetCollection(string collectionName)
        {
            return Directory.EnumerateFiles(Path.Combine(this.rootDirectory, collectionName)).Select<string, string>((Func<string, string>)(x => File.ReadAllText(x)));
        }
    }
}
