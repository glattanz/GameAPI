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

        public void AddTag(
            int gameId,
            int tagId)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_AddTag");

            command.CreateIntInputParameter("@GameId", gameId);
            command.CreateIntInputParameter("@TagId", tagId);

            var reader = command.ExecuteNonQuery();
        }

        public void AddSubgenre(
            int gameId,
            int subgenreId)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_AddSubgenre");

            command.CreateIntInputParameter("@GameId", gameId);
            command.CreateIntInputParameter("@SubgenreId", subgenreId);

            var reader = command.ExecuteNonQuery();
        }

        public void AddPlatform(
            int gameId, 
            int platformId)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_AddPlatform");

            command.CreateIntInputParameter("@GameId", gameId);
            command.CreateIntInputParameter("@PlatformId", platformId);

            var reader = command.ExecuteNonQuery();
        }

        public void AddLanguage(
            int gameId, 
            int languageId)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_AddLanguage");

            command.CreateIntInputParameter("@GameId", gameId);
            command.CreateIntInputParameter("@LanguageId", languageId);

            var reader = command.ExecuteNonQuery();
        }
    }
}