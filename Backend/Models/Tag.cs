using GameAPI.Utilities;
using Newtonsoft.Json;
using System.Data;

namespace GameAPI.Models
{
    public class Tag
    {
        [JsonConstructor]
        public Tag(
            int id,
            string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }
        public string Description { get; }

        public static Tag Create(IDataRecord reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            return new Tag(
                reader.GetInt32("Id"),
                reader.GetString("Description"));
        }
    }
}
