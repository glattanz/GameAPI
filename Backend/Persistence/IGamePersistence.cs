using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface IGamePersistence
    {
        public IEnumerable<Game> List();

        public Game Create(
            string title,
            string description,
            int genreId,
            int developerId,
            int publisherId,
            double? rating,
            DateTime releaseDate,
            bool? isAvaliable);

        public Game Get(int id);

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

        public Game Disable(int id);
    }
}
