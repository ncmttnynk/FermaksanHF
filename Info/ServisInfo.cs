using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class ServisInfo
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public bool Cevaplandi { get; set; }
        public int DilKod { get; set; }
    }
}
