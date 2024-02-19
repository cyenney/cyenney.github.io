namespace webapi.Models.NewFolder
{
    public class Survey
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public List<string> Questions { get; set; }

    }
}
