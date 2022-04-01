using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApiCommon
{
    public class Filter
    {
        public Guid FilterId { get; set; } = Guid.Empty;
        public string FilterName { get; set; } = string.Empty;
        public string FilterAdress { get; set; } = string.Empty;
        public long FilterOib { get; set; } = 0;
    }
}
