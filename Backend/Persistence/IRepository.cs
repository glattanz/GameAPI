namespace GameAPI.Persistence
{
    public interface IRepository
    {
        public IGamePersistence Games { get; }
        public IGenrePersistence Genres { get; }
        public ITagPersistence Tags { get; }
        public IPlatformPersistence Platforms { get; }
        public ILanguagePersistence Languages { get; }
        public IDeveloperPersistence Developers { get; }
    }
}