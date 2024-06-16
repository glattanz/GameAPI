using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface IDeveloperPersistence
    {
        public Developer Get(int id);

        public IEnumerable<Developer> List();

        public Developer Create(string name);

        public Developer Delete(int id);

        public Developer Update(
            int id,
            string name);
    }
}
