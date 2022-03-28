using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAPI_list_.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Iban { get; set; }
    }
}