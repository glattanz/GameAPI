using GameAPI.Models;
using GameAPI.Utilities;

namespace GameAPI.Persistence
{
    public class DeveloperPersistence : IDeveloperPersistence
    {
        private readonly string _connectionString;

        public DeveloperPersistence(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Developer Get(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Developers_Get");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Developer.Create(reader);
            }

            return null;
        }

        public IEnumerable<Developer> List()
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Developers_List");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return Developer.Create(reader);
            }
        }

        public Developer Create(string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Developers_Create");

            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Developer.Create(reader);
            }

            return null;
        }

        public Developer Delete(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Developers_Delete");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Developer.Create(reader);
            }

            return null;
        }

        public Developer Update(
            int id,
            string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Developers_Update");

            command.CreateIntInputParameter("@Id", id);
            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Developer.Create(reader);
            }

            return null;
        }
    }
}