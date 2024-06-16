using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface IPublisherPersistence
    {
        public Publisher Get(int id);

        public IEnumerable<Publisher> List();

        public Publisher Create(string name);

        public Publisher Delete(int id);

        public Publisher Update(
            int id,
            string name);
    }
}
