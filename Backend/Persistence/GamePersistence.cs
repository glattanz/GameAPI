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

        public Game Get(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_Get");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
        }

        public IEnumerable<Game> List()
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_List");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return Game.Create(reader);
            }
        }

        public Game Disable(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_Disable");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
        }

        public Game Create(
            string title,
            string description,
            int genreId,
            int developerId,
            int publisherId,
            double? rating,
            DateTime releaseDate,
            bool? isAvaliable)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_Create");

            command.CreateStringInputParameter("@Title", title);
            command.CreateStringInputParameter("@Description", description);
            command.CreateIntInputParameter("@GenreId", genreId);
            command.CreateIntInputParameter("@DeveloperId", developerId);
            command.CreateIntInputParameter("@PublisherId", publisherId);
            command.CreateDoubleInputParameter("@Rating", rating ?? 0);
            command.CreateDateTimeInputParameter("@ReleaseDate", releaseDate);
            command.CreateBooleanInputParameter("@IsAvaliable", isAvaliable ?? true);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
        }

        public Game Update(
            int id,
            string title,
            string description,
            int genreId,
            int developerId,
            int publisherId,
            double rating,
            DateTime releaseDate,
            bool isAvaliable)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_Update");

            command.CreateIntInputParameter("@Id", id);
            command.CreateStringInputParameter("@Title", title);
            command.CreateStringInputParameter("@Description", description);
            command.CreateIntInputParameter("@GenreId", genreId);
            command.CreateIntInputParameter("@DeveloperId", developerId);
            command.CreateIntInputParameter("@PublisherId", publisherId);
            command.CreateDoubleInputParameter("@Rating", rating);
            command.CreateDateTimeInputParameter("@ReleaseDate", releaseDate);
            command.CreateBooleanInputParameter("@IsAvaliable", isAvaliable );

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
        }

        public Game AddTag(int tagId)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_AddTag");

            command.CreateIntInputParameter("@TagId", tagId);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
        }

        public Game AddSubgenre(int tagId)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.AddSubgenre");

            command.CreateIntInputParameter("@SubgenreId", tagId);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
        }

        public Game AddPlatform(int tagId)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.AddSubgenre");

            command.CreateIntInputParameter("@SubgenreId", tagId);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
        }
    }
}