namespace EventBus.Messages.Events.Gallery
{
    public class AddGalleryEvent : IntegrationBaseEvent
    {
        public required string Title_FA { get; set; }
        public required string Title_EN { get; set; }
        public required string Title_AR { get; set; }
        public required string ImageUrl { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required DateTime ModificationDateTime { get; set; }
        public required string CreationDateTimeShamsi { get; set; }
        public required string ModificationDateTimeShamsi { get; set; }
    }
}
