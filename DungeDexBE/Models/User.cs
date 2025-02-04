namespace DungeDexBE.Models
{
    public class User
    {
        public  int Id { get; set; }
        public string UserName { get; set; } = null!;
        public List<int> DungeMonIds { get; set; } = new List<int>();
        public virtual List<DungeMon> DungMons { get; set; } = [];

    }
}
