using GameAPI.Models;
using GameAPI.Utilities;

namespace GameAPI.Persistence
{
    public class PlatformPersistence : IPlatformPersistence
    {
        private readonly string _connectionString;

        public PlatformPersistence(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Platform Get(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Platforms_Get");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Platform.Create(reader);
            }

            return null;
        }

        public IEnumerable<Platform> List()
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Platforms_List");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return Platform.Create(reader);
            }
        }

        public Platform Create(string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Platforms_Create");

            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Platform.Create(reader);
            }

            return null;
        }

        public Platform Delete(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Platforms_Delete");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Platform.Create(reader);
            }

            return null;
        }

        public Platform Update(
            int id,
            string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Platforms_Update");

            command.CreateIntInputParameter("@Id", id);
            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Platform.Create(reader);
            }

            return null;
        }
    }
}