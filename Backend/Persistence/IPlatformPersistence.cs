using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface IPlatformPersistence
    {
        public Platform Get(int id);

        public IEnumerable<Platform> List();

        public Platform Create(string name);

        public Platform Delete(int id);

        public Platform Update(
            int id,
            string name);
    }
}
