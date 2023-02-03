namespace Services

{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public DateTimeOffset addedDate { get; set; }
    }
}
