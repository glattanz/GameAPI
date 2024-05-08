using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface IGamePersistence
    {
        public IEnumerable<Game> List();

        public Game Create(Game game);

        public Game Get(int id);

        public Game Update(Game game);

        public void Delete(int id);
    }
}
