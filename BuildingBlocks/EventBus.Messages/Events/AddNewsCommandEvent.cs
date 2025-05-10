using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class AddNewsCommandEvent: IntegrationBaseEvent
    {
        public int NewsArticleID { get; set; }
        public string Content { get; set; }
    }
}
