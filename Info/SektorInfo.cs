using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class SektorInfo
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Fotograf { get; set; }
        public int Oncelik { get; set; }
        public bool Goster { get; set; }
        public int DilKod { get; set; }
    }
}
