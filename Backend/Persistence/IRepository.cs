namespace GameAPI.Persistence
{
    public interface IRepository
    {
        public IGamePersistence Games { get; }
    }
}
