using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events.News
{
    public class AddAuthorEvent : IntegrationBaseEvent
    {
        public string Name { get; set; }

        public string Bio { get; set; }
        public string ProfilePictureURL { get; set; }
    }
}
