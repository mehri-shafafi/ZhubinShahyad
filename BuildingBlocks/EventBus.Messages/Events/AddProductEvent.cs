using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class AddProductEvent:IntegrationBaseEvent
    {
        public string Name_FA { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string Description_FA { get; set; }
        public string Description_EN { get; set; }
        public string Description_AR { get; set; }
        public decimal Price { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string StockQuantity { get; set; }
        public string SKU { get; set; }
        public string ImageURL { get; set; }
        public string Warranty { get; set; }
        public int Rating { get; set; }
    }
}
