using GameAPI.Models;
using GameAPI.Utilities;

namespace GameAPI.Persistence
{
    public class GamePersistence : IGamePersistence
    {
        private readonly string _connectionString;

        public GamePersistence(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Game Create(Game game)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Game Get(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Game> List()
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return Game.Create(reader);
            }
        }

        public Game Update(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
