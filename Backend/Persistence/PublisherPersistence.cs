using GameAPI.Models;
using GameAPI.Utilities;

namespace GameAPI.Persistence
{
    public class PublisherPersistence : IPublisherPersistence
    {
        private readonly string _connectionString;

        public PublisherPersistence(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Publisher Get(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Publishers_Get");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Publisher.Create(reader);
            }

            return null;
        }

        public IEnumerable<Publisher> List()
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Publishers_List");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return Publisher.Create(reader);
            }
        }

        public Publisher Create(string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Publishers_Create");

            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Publisher.Create(reader);
            }

            return null;
        }

        public Publisher Delete(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Publishers_Delete");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Publisher.Create(reader);
            }

            return null;
        }

        public Publisher Update(
            int id,
            string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Publishers_Update");

            command.CreateIntInputParameter("@Id", id);
            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Publisher.Create(reader);
            }

            return null;
        }
    }
}