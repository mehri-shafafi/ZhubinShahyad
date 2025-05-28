using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class AddCategoryProductEvent : IntegrationBaseEvent
    {
        public string Name_FA { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Permalink { get; set; }
        public bool Active { get; set; }
        public int Priority { get; set; }
        public string BannerUrl { get; set; }
        public string IconUrl { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
