using GameAPI.Models;
using GameAPI.Utilities;

namespace GameAPI.Persistence
{
    public class GenrePersistence : IGenrePersistence
    {
        private readonly string _connectionString;

        public GenrePersistence(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Genre Get(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Genres_Get");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Genre.Create(reader);
            }

            return null;
        }

        public IEnumerable<Genre> List()
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Genres_List");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return Genre.Create(reader);
            }
        }

        public Genre Create(string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Genre_Create");

            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Genre.Create(reader);
            }

            return null;
        }

        public Genre Delete(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Genres_Delete");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Genre.Create(reader);
            }

            return null;
        }

        public Genre Update(
            int id,
            string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Genres_Update");

            command.CreateIntInputParameter("@Id", id);
            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Genre.Create(reader);
            }

            return null;
        }
    }
}