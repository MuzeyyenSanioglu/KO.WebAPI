using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.CORE.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
