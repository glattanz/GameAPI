using GameAPI.Models;
using GameAPI.Utilities;

namespace GameAPI.Persistence
{
    public class LanguagePersistence : ILanguagePersistence
    {
        private readonly string _connectionString;

        public LanguagePersistence(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Language Get(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Languages_Get");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Language.Create(reader);
            }

            return null;
        }

        public IEnumerable<Language> List()
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Languages_List");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return Language.Create(reader);
            }
        }

        public Language Create(string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Languages_Create");

            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Language.Create(reader);
            }

            return null;
        }

        public Language Delete(int id)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Languages_Delete");

            command.CreateIntInputParameter("@Id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Language.Create(reader);
            }

            return null;
        }

        public Language Update(
            int id,
            string name)
        {
            using var connection = _connectionString.CreateOpenConnection();
            var command = connection.CreateCommand(System.Data.CommandType.StoredProcedure, "dbo.sp_Languages_Update");

            command.CreateIntInputParameter("@Id", id);
            command.CreateStringInputParameter("@Name", name);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Language.Create(reader);
            }

            return null;
        }
    }
}