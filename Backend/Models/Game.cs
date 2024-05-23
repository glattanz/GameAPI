using GameAPI.Utilities;
using Newtonsoft.Json;
using System.Data;

namespace GameAPI.Models
{
    public class Game
    {
        [JsonConstructor]
        public Game(
            int id,
            string title,
            string description,
            string genre,
            int developerId,
            int publisherId,
            float rating,
            DateTime releaseDate,
            bool isAvaliable,
            float size,
            List<string> tags,
            List<string> subgenres,
            List<string> avaliableLanguages,
            List<string> avaliablePlatforms)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
            DeveloperId = developerId;
            PublisherId = publisherId;
            Rating = rating;
            ReleaseDate = releaseDate;
            IsAvaliable = isAvaliable;
            Size = size;
            Tags = tags;
            Subgenres = subgenres;
            AvaliableLanguages = avaliableLanguages;
            AvaliablePlatforms = avaliablePlatforms;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string Genre { get; }
        public int DeveloperId { get; }
        public int PublisherId { get; }
        public float Rating { get; }
        public DateTime ReleaseDate { get; }
        public bool IsAvaliable { get; }
        public float Size { get; } //In megabytes
        public List<string> Tags { get; }
        public List<string> Subgenres { get; }
        public List<string> AvaliableLanguages { get; }
        public List<string> AvaliablePlatforms { get; }

        public static Game Create(IDataRecord reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            var tagsJSON = reader.GetString("Tags");
            var tags = string.IsNullOrEmpty(tagsJSON)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(tagsJSON);

            var subgenresJSON = reader.GetString("Subgenres");
            var subgenres = string.IsNullOrEmpty(subgenresJSON)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(subgenresJSON);

            var avaliableLanguagesJSON = reader.GetString("AvaliableLanguages");
            var avaliableLanguages = string.IsNullOrEmpty(avaliableLanguagesJSON)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(avaliableLanguagesJSON);

            var avaliablePlatformsJSON = reader.GetString("AvaliablePlatforms");
            var avaliablePlatforms = string.IsNullOrEmpty(avaliablePlatformsJSON)
                ? new List<string>()
                : JsonConvert.DeserializeObject<List<string>>(avaliablePlatformsJSON);

            return new Game(
                reader.GetInt32("Id"),
                reader.GetString("Title"),
                reader.GetString("Description"),
                reader.GetString("Genre"),
                reader.GetInt32("DeveloperId"),
                reader.GetInt32("PublisherId"),
                reader.GetFloat("Rating"),
                reader.GetDateTime("ReleaseDate"),
                reader.GetBooleanFromBit("IsAvaliable"),
                reader.GetFloat("Size"),
                tags,
                subgenres,
                avaliableLanguages,
                avaliablePlatforms);
        }
    }
}