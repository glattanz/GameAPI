using GameAPI.Utilities;
using Newtonsoft.Json;
using System.Data;

namespace GameAPI.Models
{
    public class Language
    {
        [JsonConstructor]
        private Language(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        public static Language Create(IDataRecord reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            return new Language(
                reader.GetInt32("Id"),
                reader.GetString("Name"));
        }
    }
}
