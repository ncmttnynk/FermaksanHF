using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class MakineInfo
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Detaylar { get; set; }
        public string Ozellikler { get; set; }
        public string Video { get; set; }
        public string Katalog { get; set; }
        public bool Goster { get; set; }
        public int Oncelik { get; set; }
        public int DilKod { get; set; }
    }
}
