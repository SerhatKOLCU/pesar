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
    
    public partial class Duyuru
    {
        public int Duyuru_ID { get; set; }
        public string Duyuru_Baslik { get; set; }
        public string Duyuru_Icerik { get; set; }
        public byte[] Duyuru_Foto { get; set; }
        public byte[] Duyuru_Dosya { get; set; }
        public System.DateTime Duyuru_Tarih { get; set; }
    }
}