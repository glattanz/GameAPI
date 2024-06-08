namespace GameAPI.Persistence
{
    public class Repository : IRepository
    {
        public Lazy<IGamePersistence> _Games;
        public Lazy<IGenrePersistence> _Genres;
        public Lazy<IGamePersistence> _Games;

        public Repository(string connectionString)
        {
            _Games = new Lazy<IGamePersistence>(() => new GamePersistence(connectionString));
            _Genres = new Lazy<IGenrePersistence>(() => new GenrePersistence(connectionString));
        }

        public IGamePersistence Games => _Games.Value;
        public IGenrePersistence Genres => _Genres.Value;
    }
}
