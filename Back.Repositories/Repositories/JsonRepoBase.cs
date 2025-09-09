using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repositories.Repositories
{
    public abstract class JsonRepoBase<T> where T : class
    {
        private readonly string _filePath;
        protected List<T> _items;

        protected JsonRepoBase(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

            var json = File.ReadAllText(_filePath);
            _items = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        protected void SaveChanges()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_items, Formatting.Indented));
        }
    }
}
