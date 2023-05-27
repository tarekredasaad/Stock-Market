using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Models.Model
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Stock")]
        public int StockID { get; set; }
        public virtual Stock? Stock { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }
    }
}
