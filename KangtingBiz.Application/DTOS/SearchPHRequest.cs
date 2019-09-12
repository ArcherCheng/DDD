using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Application.DTOS
{
    class SearchPHRequest
    {
        public int SearchID { get; set; }
        public string SearchName { get; set; }
        public int PHLevel { get; set; }
    }
}
