namespace EventBus.Messages.Events.News
{
    public class AddNewsCommentEvent : IntegrationBaseEvent
    {
        public int NewsArticleID { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
