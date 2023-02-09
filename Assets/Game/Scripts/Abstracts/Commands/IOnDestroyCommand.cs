namespace Abstracts.Commands
{
    public interface IOnDestroyCommand<in TEntity>
    {
        void OnDestroy(TEntity entity);
    }
}