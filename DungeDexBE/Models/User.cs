namespace DungeDexBE.Models
{
    public class User
    {
        public  int Id { get; set; }
        public string UserName { get; set; } = null!;
        public virtual List<Monster> Creations { get; set; } = [];

    }
}
