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
            int genreId,
            int developerId,
            int publisherId,
            float rating,
            DateTime releaseDate,
            bool isAvaliable)
        {
            Id = id;
            Title = title;
            Description = description;
            GenreId = genre;
            DeveloperId = developerId;
            PublisherId = publisherId;
            Rating = rating;
            ReleaseDate = releaseDate;
            IsAvaliable = isAvaliable;
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
                reader.GetInt32("GenreId"),
                reader.GetInt32("DeveloperId"),
                reader.GetInt32("PublisherId"),
                reader.GetFloat("Rating"),
                reader.GetDateTime("ReleaseDate"),
                reader.GetBooleanFromBit("IsAvaliable"));
        }
    }
}