namespace GiftOrganizer.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public bool Reminder { get; set; }
    }
}
