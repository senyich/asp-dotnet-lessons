using Models;

namespace Services
{
    public interface IPersonFormatter
    {
        string Serialize(IEnumerable<Person> persons);
        IEnumerable<Person> Deserialize(string data);
        Position GetPosition(string data);
    }
    public class StarsPersonFormatter : IPersonFormatter //для разделителя ***
    {
        public string Serialize(IEnumerable<Person> persons)
        {
            return string.Join("\n***\n", persons.Select(p => $"{p.ToString}"));
        }
        public Position GetPosition(string pos)
        {
            switch (pos)
            {
                case "Junior":
                    return Position.Junior;
                case "Middle":
                    return Position.Middle;
                case "Senior":
                    return Position.Senior;
                case "TeamLead":
                    return Position.TeamLead;
            }
            return Position.None;
        }
        public IEnumerable<Person> Deserialize(string data)
        {
            var persons = new List<Person>();
            var entries = data.Split("\n***\n");
            foreach (var entry in entries)
            {
                var parts = entry.Split(',');
                if (parts.Length < 4) continue;
                persons.Add(new Programmer(GetPosition(parts[0]), parts[1], parts[2], int.Parse(parts[3])));
            }
            return persons;
        }
        public class PercentPersonFormatter : IPersonFormatter //для разделителя %%%
        {
            public Position GetPosition(string pos)
            {
                switch (pos)
                {
                    case "Junior":
                        return Position.Junior;
                    case "Middle":
                        return Position.Middle;
                    case "Senior":
                        return Position.Senior;
                    case "TeamLead":
                        return Position.TeamLead;
                }
                return Position.None;
            }
            public string Serialize(IEnumerable<Person> persons)
            {
                return string.Join("\n%%%\n", persons.Select(p => $"{p.ToString}"));
            }
            public IEnumerable<Person> Deserialize(string data)
            {
                var persons = new List<Person>();
                var entries = data.Split("\n%%%\n");
                foreach (var entry in entries)
                {
                    var parts = entry.Split(',');
                    if (parts.Length < 4) continue;
                    persons.Add(new Programmer(GetPosition(parts[0]), parts[1], (parts[2]), int.Parse(parts[3])));
                }
                return persons;
            }
        }
    }
}
