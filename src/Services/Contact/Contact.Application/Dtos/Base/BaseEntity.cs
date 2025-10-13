
using BaseProject.Domain.Common.Extensions;

namespace Contact.Domain.Base
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModificationDateTime { get; set; } = DateTime.UtcNow;
        public string CreationDateTimeShamsi { get; set; } = DateTime.UtcNow.ToShamsiString();
        public string ModificationDateTimeShamsi { get; set; } = DateTime.UtcNow.ToShamsiString();

    }
    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}
