using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface ITagPersistence
    {
        public Tag Get(int id);

        public IEnumerable<Tag> List();

        public Tag Create(
            string name);

        public Tag Delete(int id);

        public Tag Update(
            int id,
            string name);
    }
}
