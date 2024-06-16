namespace GameAPI.Persistence
{
    public class Repository : IRepository
    {
        public Lazy<IGamePersistence> _Games;
        public Lazy<IGenrePersistence> _Genres;
        public Lazy<ITagPersistence> _Tags;
        public Lazy<IPlatformPersistence> _Platforms;
        public Lazy<ILanguagePersistence> _Languages;
        public Lazy<IDeveloperPersistence> _Developers;
        public Lazy<IPublisherPersistence> _Publishers;

        public Repository(string connectionString)
        {
            _Games = new Lazy<IGamePersistence>(() => new GamePersistence(connectionString));
            _Genres = new Lazy<IGenrePersistence>(() => new GenrePersistence(connectionString));
            _Tags = new Lazy<ITagPersistence>(() => new TagPersistence(connectionString));
            _Platforms = new Lazy<IPlatformPersistence>(() => new PlatformPersistence(connectionString));
            _Languages = new Lazy<ILanguagePersistence>(() => new LanguagePersistence(connectionString));
            _Developers = new Lazy<IDeveloperPersistence>(() => new DeveloperPersistence(connectionString));
            _Publishers = new Lazy<IPublisherPersistence>(() => new PublisherPersistence(connectionString));
        }

        public IGamePersistence Games => _Games.Value;
        public IGenrePersistence Genres => _Genres.Value;
        public ITagPersistence Tags => _Tags.Value;
        public IPlatformPersistence Platforms => _Platforms.Value;
        public ILanguagePersistence Languages => _Languages.Value;
        public IDeveloperPersistence Developers => _Developers.Value;
        public IPublisherPersistence Publishers => _Publishers.Value;
    }
}