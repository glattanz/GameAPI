namespace GameAPI.Persistence
{
    public class Repository : IRepository
    {
        public Lazy<IGamePersistence> _Games;
        public Lazy<IGenrePersistence> _Genres;
        public Lazy<ITagPersistence> _Tags;
        public Lazy<IPlatformPersistence> _Platforms;

        public Repository(string connectionString)
        {
            _Games = new Lazy<IGamePersistence>(() => new GamePersistence(connectionString));
            _Genres = new Lazy<IGenrePersistence>(() => new GenrePersistence(connectionString));
            _Tags = new Lazy<ITagPersistence>(() => new TagPersistence(connectionString));
            _Platforms = new Lazy<IPlatformPersistence>(() => new PlatformPersistence(connectionString));
        }

        public IGamePersistence Games => _Games.Value;
        public IGenrePersistence Genres => _Genres.Value;
        public ITagPersistence Tags => _Tags.Value;
        public IPlatformPersistence Platforms => _Platforms.Value;
    }
}
