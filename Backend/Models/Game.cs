using GameAPI.Utilities;
using Newtonsoft.Json;
using System.Data;

namespace GameAPI.Models
{
    public class Game
    {
        [JsonConstructor]
        private Game(
            int id,
            string title,
            string description,
            int genreId,
            int developerId,
            int publisherId,
            float rating,
            DateTime releaseDate,
            bool isAvaliable,
            List<Tag> tags,
            List<Genre> subgenres)
        {
            Id = id;
            Title = title;
            Description = description;
            GenreId = genreId;
            DeveloperId = developerId;
            PublisherId = publisherId;
            Rating = rating;
            ReleaseDate = releaseDate;
            IsAvaliable = isAvaliable;
            Tags = tags;
            Subgenres = subgenres;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public int GenreId { get; }
        public int DeveloperId { get; }
        public int PublisherId { get; }
        public float Rating { get; }
        public DateTime ReleaseDate { get; }
        public bool IsAvaliable { get; }
        public IEnumerable<Tag> Tags { get; }
        public IEnumerable<Genre> Subgenres { get; }

        public static Game Create(IDataRecord reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            var tagsJSON = reader.GetString("Tags");
            var tags = string.IsNullOrEmpty(tagsJSON)
                ? new List<Tag>()
                : JsonConvert.DeserializeObject<List<Tag>>(tagsJSON);

            var subgenresJSON = reader.GetString("Subgenres");
            var subgenres = string.IsNullOrEmpty(subgenresJSON)
                ? new List<Genre>()
                : JsonConvert.DeserializeObject<List<Genre>>(subgenresJSON);

            return new Game(
                reader.GetInt32("Id"),
                reader.GetString("Title"),
                reader.GetString("Description"),
                reader.GetInt32("GenreId"),
                reader.GetInt32("DeveloperId"),
                reader.GetInt32("PublisherId"),
                reader.GetFloat("Rating"),
                reader.GetDateTime("ReleaseDate"),
                reader.GetBooleanFromBit("IsAvaliable"),
                tags,
                subgenres);
        }
    }
}