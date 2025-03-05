namespace Models
{
    public abstract class Person
    {
        public string name { get; } = "John";
        public string surname { get; } = "Doe";
        public int age { get; } = 18;
        protected Person(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
        public override string ToString()
        {
            return $"{name} {surname} {age}";
        }
    }
    public class Programmer : Person
    {
        public Position positionInCompany;
        public Programmer(Position positionInCompany, string name, string surname, int age) : base(name, surname, age)
        {
            this.positionInCompany = positionInCompany;
        }
        public override string ToString()
        {
            return $"{positionInCompany.ToString()}***{name}***{surname}***{age}";
        }
    }
    public enum Position
    {
        Junior,
        Middle,
        Senior,
        TeamLead,
        None
    }
}
