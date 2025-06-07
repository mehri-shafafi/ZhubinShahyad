namespace EventBus.Messages.Events.News
{
    public class AddEducationEvent : IntegrationBaseEvent
    {
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
