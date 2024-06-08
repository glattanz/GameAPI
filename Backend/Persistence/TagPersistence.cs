using GameAPI.Models;
using GameAPI.Utilities;

namespace GameAPI.Persistence
{
    public class TagPersistence : ITagPersistence
    {
        private readonly string _connectionString;

        public TagPersistence(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Tag Get(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Tags_Get");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Tag.Create(reader);
            }

            return null;
        }

        public IEnumerable<Tag> List()
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Tags_List");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return Tag.Create(reader);
            }
        }

        public Tag Create(string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Tags_Create");

            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Tag.Create(reader);
            }

            return null;
        }

        public Tag Delete(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Tags_Delete");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Tag.Create(reader);
            }

            return null;
        }

        public Tag Update(
            int id,
            string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Tags_Update");

            command.CreateIntInputParameter("@Id", id);
            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Tag.Create(reader);
            }

            return null;
        }
    }
}
