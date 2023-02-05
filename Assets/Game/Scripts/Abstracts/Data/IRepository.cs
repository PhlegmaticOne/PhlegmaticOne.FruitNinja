namespace Abstracts.Data
{
    public interface IRepository<T>
    {
        void AddOrUpdate(T item);
        T Get();
    }
}