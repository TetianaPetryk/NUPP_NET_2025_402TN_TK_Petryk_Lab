using System;
using System.Collections.Generic;

namespace Library.Common
{
    public interface ICrudService<T> where T : Identifiable
    {
        void Create(T element);
        T Read(Guid id);
        IEnumerable<T> ReadAll();
        void Update(T element);
        void Remove(T element);
    }
}
