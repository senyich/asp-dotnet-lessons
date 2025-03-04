using Models;
using Services;

namespace Middlewares
{
    public class PersonFormatterMiddleware
    {
        public readonly RequestDelegate next;
        public PersonFormatterMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, IPersonFormatter formatter, ILoggerService logger)
        {
            //пример глупый, но наглядный
            string filePath = "info.txt";
            FileLoaderService repository = new FileLoaderService(filePath, formatter);//раз по заданию сказано работать с файлом, то решил не заморачиваться с базой
            var persons = new List<Person>
            {
                new Programmer(Position.None, "Ваня", "В Душе Синьор",10),
                new Programmer(Position.TeamLead, "Костя", "Уставший",10),
                new Programmer(Position.Junior, "Алексий", "Маленький",10),
            };
            repository.Save(persons);
            logger.Log("Данные сохранены");
            var loadedPersons = repository.Load();
            logger.Log("Загружены данные");
            foreach (var person in loadedPersons)
            {
                logger.Log(person.ToString());
            }
            await next.Invoke(context);
        }
    }
}
