namespace Task.Domain
{
    public class CheckList : BaseEntity
    {
        
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}