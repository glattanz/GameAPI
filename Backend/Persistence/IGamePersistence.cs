using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface IGamePersistence
    {
        public Game Get(int id);

        public IEnumerable<Game> List();

        public Game Disable(int id);

        public Game Create(
            string title,
            string description,
            int genreId,
            int developerId,
            int publisherId,
            double? rating,
            DateTime releaseDate,
            bool? isAvaliable);

        public Game Update( 
            int id,
            string title,
            string description,
            int genreId,
            int developerId,
            int publisherId,
            double rating,
            DateTime releaseDate,
            bool isAvaliable);

        public Game AddTag(int tagId);
    }
}
