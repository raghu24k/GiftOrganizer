namespace GiftOrganizer.Models
{
    public class Person
    {
        public int Id { get; set; } // For MySQL primary key
        public string Name { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
