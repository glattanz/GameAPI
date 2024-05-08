using GameAPI.Utilities;
using System.Data;
using System.Text.Json.Serialization;

namespace GameAPI.Models
{
    public class Game
    {
        [JsonConstructor]
        public Game(
            int id,
            string title,
            string description,
            int developerId,
            int publisherId,
            int rating,
            DateTime releaseDate,
            bool isAvaliable)
        {
            Id = id;
            Title = title;
            Description = description;
            DeveloperId = developerId;
            PublisherId = publisherId;
            Rating = rating;
            ReleaseDate = releaseDate;
            IsAvaliable = isAvaliable;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsAvaliable { get; set; }

        public static Game Create(IDataRecord reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            return new Game(
                reader.GetInt32("Id"),
                reader.GetString("Title"),
                reader.GetString("Description"),
                reader.GetInt32("DeveloperId"),
                reader.GetInt32("PublisherId"),
                reader.GetInt32("Rating"),
                reader.GetDateTime("ReleaseDate"),
                reader.GetBooleanFromBit("IsAvaliable"));
        }
    }
}