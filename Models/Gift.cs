namespace GiftOrganizer.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Given, Planned, Received
        public decimal Cost { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
