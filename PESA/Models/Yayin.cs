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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yayin()
        {
            this.Etiket = new HashSet<Etiket>();
        }
    
        public int Yayin_ID { get; set; }
        public int YayinTip_ID { get; set; }
        public string Yayin_Baslik { get; set; }
        public byte[] Yayin_Foto { get; set; }
        public string Yayin_Icerik { get; set; }
        public string Yayin_Ozet { get; set; }
        public int Yazar_ID { get; set; }
        public int Etiket_ID { get; set; }
        public byte[] Yayin_Dosya { get; set; }
        public string Yayin_Tarih { get; set; }
        public string Slider_Baslik { get; set; }
        public string Slider_Ozet { get; set; }
    
        public virtual YayinTip YayinTip { get; set; }
        public virtual Yazar Yazar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiket> Etiket { get; set; }
    }
}
