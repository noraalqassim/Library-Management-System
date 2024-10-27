namespace LibraryManagementSystem
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            
        }
    }
}