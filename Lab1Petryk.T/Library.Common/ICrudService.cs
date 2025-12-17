namespace Library.Common;


    public interface ICrudService<T> where T : Identifiable
    {
        void Create(T element);
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Update(T element);
        void Remove(T element);
    }
