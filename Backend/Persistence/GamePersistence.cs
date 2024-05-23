using GameAPI.Models;
using GameAPI.Utilities;
using Newtonsoft.Json;
namespace GameAPI.Persistence
{
    public class GamePersistence : IGamePersistence
    {
        private readonly string _connectionString;

        public GamePersistence(string connectionString)
        {
            _connectionString = connectionString;
        }

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
            List<string> avaliablePlatforms)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_Create");

            var tagsJSON = JsonConvert.SerializeObject(tags);
            var subgenresJSON = JsonConvert.SerializeObject(tags);
            var avaliableLanguagesJSON = JsonConvert.SerializeObject(tags);
            var avaliablePlatformsJSON = JsonConvert.SerializeObject(tags);

            command.CreateStringInputParameter("@Title", title);
            command.CreateStringInputParameter("@Description", description);
            command.CreateStringInputParameter("@Genre", genre);
            command.CreateIntInputParameter("@DeveloperId", developerId);
            command.CreateIntInputParameter("@PublisherId", publisherId);
            command.CreateDoubleInputParameter("@Rating", rating ?? 0);
            command.CreateDateTimeInputParameter("@ReleaseDate", releaseDate);
            command.CreateBooleanInputParameter("@IsAvaliable", isAvaliable ?? true);
            command.CreateDoubleInputParameter("@Size", size);
            command.CreateStringInputParameter("@Tags", tagsJSON);
            command.CreateStringInputParameter("@Subgenres", subgenresJSON);
            command.CreateStringInputParameter("@AvaliableLanguages", avaliableLanguagesJSON);
            command.CreateStringInputParameter("@AvaliablePlatforms", avaliablePlatformsJSON);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
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
            List<string> avaliablePlatforms)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Games_Update");

            var tagsJSON = JsonConvert.SerializeObject(tags);
            var subgenresJSON = JsonConvert.SerializeObject(tags);
            var avaliableLanguagesJSON = JsonConvert.SerializeObject(tags);
            var avaliablePlatformsJSON = JsonConvert.SerializeObject(tags);

            command.CreateIntInputParameter("@Id", id);
            command.CreateStringInputParameter("@Title", title);
            command.CreateStringInputParameter("@Description", description);
            command.CreateStringInputParameter("@Genre", genre);
            command.CreateIntInputParameter("@DeveloperId", developerId);
            command.CreateIntInputParameter("@PublisherId", publisherId);
            command.CreateDoubleInputParameter("@Rating", rating);
            command.CreateDateTimeInputParameter("@ReleaseDate", releaseDate);
            command.CreateBooleanInputParameter("@IsAvaliable", isAvaliable );
            command.CreateDoubleInputParameter("@Size", size);
            command.CreateStringInputParameter("@Tags", tagsJSON);
            command.CreateStringInputParameter("@Subgenres", subgenresJSON);
            command.CreateStringInputParameter("@AvaliableLanguages", avaliableLanguagesJSON);
            command.CreateStringInputParameter("@AvaliablePlatforms", avaliablePlatformsJSON);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Game.Create(reader);
            }

            return null;
        }
    }
}
