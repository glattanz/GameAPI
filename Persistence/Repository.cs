namespace GameAPI.Persistence
{
    public class Repository : IRepository
    {
        public Lazy<IGamePersistence> _Games;

        public Repository(string connectionString)
        {
            _Games = new Lazy<IGamePersistence>(() => new GamePersistence(connectionString));
        }

        public IGamePersistence Games => _Games.Value;
    }
}
