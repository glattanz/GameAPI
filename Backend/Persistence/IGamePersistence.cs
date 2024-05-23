using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface IGamePersistence
    {
        public IEnumerable<Game> List();

        public Game Create(
            string title,
            string description,
            string genre,
            int developerId,
            int publisherId,
            double? rating,
            DateTime releaseDate,
            bool? isAvaliable,
            double size,
            List<string> tags,
            List<string> subgenres,
            List<string> avaliableLanguages,
            List<string> avaliablePlatforms);

        public Game Get(int id);

        public Game Update(
            int id,
            string title,
            string description,
            string genre,
            int developerId,
            int publisherId,
            double rating,
            DateTime releaseDate,
            bool isAvaliable,
            double size,
            List<string> tags,
            List<string> subgenres,
            List<string> avaliableLanguages,
            List<string> avaliablePlatforms);

        public Game Disable(int id);
    }
}
