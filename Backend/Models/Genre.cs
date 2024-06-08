using GameAPI.Utilities;
using System.Data;
using System.Text.Json.Serialization;

namespace GameAPI.Models
{
    public class Genre
    {
        [JsonConstructor]
        private Genre(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        public static Genre Create(IDataRecord reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            return new Genre(
                reader.GetInt32("Id"),
                reader.GetString("Name"));
        }
    }
}