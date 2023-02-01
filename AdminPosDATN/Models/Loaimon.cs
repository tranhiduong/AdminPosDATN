using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPosDATN.Models
{
    public class Loaimon
    {
        public string Maloai { get; set; }
        public string Tenloai { get; set; }
        public override string ToString()
        {
            return Tenloai;
        }
    }
}
