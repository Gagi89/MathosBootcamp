using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApiCommon
{
    public class Filter
    {
        public string FilterName { get; set; } = string.Empty;
        public string FilterAdress { get; set; } = string.Empty;
        public long FilterOib { get; set; } = 0;
    }
}
