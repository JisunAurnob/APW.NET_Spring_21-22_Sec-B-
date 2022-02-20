using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CartView
    {
        public long CID { get; set; }
        public string Pname { get; set; }
        public string Pprice { get; set; }
        public int Cqty { get; set; }
        public int CTotalPrice { get; set; }
        public long PID { get; set; }
    }
}