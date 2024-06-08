using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface IGenrePersistence
    {
        public Genre Get(int id);

        public IEnumerable<Genre> List();

        public Genre Create(
            string name);
        
        public Genre Delete(int id);

        public Genre Update(
            int id,
            string name);
    }
}
