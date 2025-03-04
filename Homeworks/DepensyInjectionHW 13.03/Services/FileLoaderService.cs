using Models;

namespace Services
{
    public class FileLoaderService
    {
        private readonly string filePath;
        private readonly IPersonFormatter formatter;

        public FileLoaderService(string filePath, IPersonFormatter formatter)
        {
            this.filePath = filePath;
            this.formatter = formatter;
        }
        public void Save(IEnumerable<Person> persons)
        {
            File.WriteAllText(filePath, formatter.Serialize(persons));
        }
        public IEnumerable<Person> Load()
        {
            if (!File.Exists(filePath)) return new List<Person>();
            var data = File.ReadAllText(filePath);
            return formatter.Deserialize(data);
        }
    }
}
