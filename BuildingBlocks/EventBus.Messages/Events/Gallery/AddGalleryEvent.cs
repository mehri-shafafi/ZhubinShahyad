namespace EventBus.Messages.Events.Gallery
{
    public class AddGalleryEvent : IntegrationBaseEvent
    {
        public string Title_FA { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public string CreationDateTimeShamsi { get; set; }
        public string ModificationDateTimeShamsi { get; set; }
    }
}
