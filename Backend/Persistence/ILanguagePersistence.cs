using GameAPI.Models;

namespace GameAPI.Persistence
{
    public interface ILanguagePersistence
    {
        public Language Get(int id);

        public IEnumerable<Language> List();

        public Language Create(string name);

        public Language Delete(int id);

        public Language Update(
            int id,
            string name);
    }
}
