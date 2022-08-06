using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.CORE.Entities
{
    public class ProductFeatureMapping
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductFeatureId { get; set; }
        public string FeatureValue { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
    }
}
