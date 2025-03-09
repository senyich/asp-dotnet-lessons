namespace EndpointsHW_16._03.Data
{
    public class GameModel
    {
        public GameModel(string name, string genre, string author)
        {
            Name = name;
            Genre = genre;
            Author = author;
        }

        public int Id {  get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Author {  get; set; }
    }
}
