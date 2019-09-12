using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Application.DTOS
{
    public class SearchProductResponse
    {
        public int ProductID { get; set;  }
        public string ProductName { get; set; }
        public int SalePrice { get; set; }
        public int Quantity { get; set; }
       
        //Search PH
        public int ReorderLevel { get; set; }
    }
}
