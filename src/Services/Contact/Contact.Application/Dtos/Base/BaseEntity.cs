
namespace Contact.Domain.Base
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModificationDateTime { get; set; } = DateTime.UtcNow;
        public string CreationDateTimeShamsi { get; set; }
        public string ModificationDateTimeShamsi { get; set; }

    }
    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}
