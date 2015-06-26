namespace DKO.EQualy.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}