using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Common
{
    public class CrudService<T> : ICrudService<T> where T : Identifiable
    {
        private readonly List<T> _items = new List<T>();

        public void Create(T element)
        {
            _items.Add(element);
        }

        public T Read(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> ReadAll()
        {
            return _items;
        }

        public void Update(T element)
        {
            var index = _items.FindIndex(x => x.Id == element.Id);
            if (index >= 0)
                _items[index] = element;
        }

        public void Remove(T element)
        {
            _items.RemoveAll(x => x.Id == element.Id);
        }
    }
}
