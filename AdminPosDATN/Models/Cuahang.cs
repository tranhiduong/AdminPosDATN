using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPosDATN.Models
{
    public class Cuahang
    {
        public string Mach { get; set; }
        public string Tench { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public override string ToString()
        {
            return Mach;
        }
    }
}
