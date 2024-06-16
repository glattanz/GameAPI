using GameAPI.Utilities;
using Newtonsoft.Json;
using System.Data;

namespace GameAPI.Models
{
    public class Developer
    {
        [JsonConstructor]
        private Developer(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        public static Developer Create(IDataRecord reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            return new Developer(
                reader.GetInt32("Id"),
                reader.GetString("Name"));
        }
    }
}
