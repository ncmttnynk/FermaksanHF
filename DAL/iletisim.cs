//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class iletisim
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        public string Aciklama { get; set; }
        public System.DateTime Tarih { get; set; }
        public bool Cevaplandi { get; set; }
        public int DilKod { get; set; }
    }
}