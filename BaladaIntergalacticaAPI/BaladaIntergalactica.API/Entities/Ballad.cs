namespace BaladaIntergalactica.API.Entities
{
    public class Ballad
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Ballad(int id, string name)
        {
            Id = id;
            Name = name;

        }

    }
}
