namespace DummyQuizbBoxApi.Models
{
    public class Portfolio
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
