//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PESA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yayin
    {
        public int Yayin_ID { get; set; }
        public int YayinTip_ID { get; set; }
        public string Yayin_Baslik { get; set; }
        public string Yayin_Foto { get; set; }
        public string Yayin_Icerik { get; set; }
        public string Yayin_Ozet { get; set; }
        public string YayinEtiket { get; set; }
        public string Yayin_Yazar { get; set; }
        public string Yayin_Dosya { get; set; }
        public string Yayin_Tarih { get; set; }
    
        public virtual YayinTip YayinTip { get; set; }
    }
}
