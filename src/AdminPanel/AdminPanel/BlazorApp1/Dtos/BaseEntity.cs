namespace BlazorApp.Dtos
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public string CreationDateTimeShamsi { get; set; }
        public string ModificationDateTimeShamsi { get; set; }

    }

}
