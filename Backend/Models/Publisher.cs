using GameAPI.Utilities;
using Newtonsoft.Json;
using System.Data;

namespace GameAPI.Models
{
    public class Publisher
    {
        [JsonConstructor]
        private Publisher(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        public static Publisher Create(IDataRecord reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            return new Publisher(
                reader.GetInt32("Id"),
                reader.GetString("Name"));
        }
    }
}
