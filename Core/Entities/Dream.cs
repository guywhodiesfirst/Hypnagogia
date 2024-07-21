namespace Core.Entities
{
    public class Dream
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DreamMood { get; set; }
        public DateTime CreatedAt  { get; set; }
    }
}